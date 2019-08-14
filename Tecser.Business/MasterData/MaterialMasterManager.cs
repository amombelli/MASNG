using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.MasterData
{
    public class RetornoMMSearch
    {
        public bool T0010 { get; set; }
        public bool T0011 { get; set; }
        public bool ActivoT0010 { get; set; }
        public bool ActivoT0011 { get; set; }
        public string TipoT0010 { get; set; }
        public string TipoT0011 { get; set; }
        public string CodigPrimario { get; set; }
        public string CodigoAKA { get; set; }   
    }

    public class RtnMaterialVerySimple
    {
        public bool Activo { get; set; }
        public string Material { get; set; }
        public string Descripcion { get; set; }
        public string Primario { get; set; }
        public string CodigoCliente { get; set; }
    }

    public partial class MaterialMasterManager
    {
        public List<RtnMaterialVerySimple> GetMaterialesVentaVerySimple()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = (from a in db.T0011_MATERIALES_AKA
                    where a.ACTIVO == true
                    select new RtnMaterialVerySimple()
                    {
                        Activo = a.ACTIVO,    
                        Descripcion = a.MAT_DESC2,
                        Material = a.CODVENTA,
                        Primario = a.PRIMARIO,
                        CodigoCliente = ""
                    });
                return result.ToList();
            }
        }

        /// <summary>
        /// Creacion de primario para ZRLB
        /// NO debe ser utilizado para nada salvo para crear integridad referencial
        /// </summary>
        public bool CreatePrimarioForZRLB(string codigoVenta, string codigoPrimario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == codigoVenta.ToUpper());
                if (data != null)
                    return true;

                //Creacion de Fake Primario
                var material = new T0010_MATERIALES()
                {
                    IDMATERIAL = codigoVenta.ToUpper(),
                    ACTIVO = false,
                    BATCHMNG = false,
                    MonedaCosto = @"USD",
                    ORIGEN = "FAB",
                    COLOR = null,
                    COMPUESTO_BASE = data.COMPUESTO_BASE,
                    CONCENTRACION = data.CONCENTRACION,
                    DescripcionFormulacion = @"Uso Interno Sistema - ZRLB>" + codigoPrimario,
                    DescripcionTecnicaLab  = @"Uso Interno Sistema - ZRLB>" + codigoPrimario,
                    FORM_COSTO = null,
                    MATERIAL_STATUS = "ZRLB-OK",
                    //MAT_DESC = "USO INTERNO DEL SISTEMA - ZRLB>" + codigoVenta,
                    //MAT_DESC2 = "USO INTERNO DEL SISTEMA - ZRLB>" + codigoVenta,
                    LogCreadoFecha = DateTime.Today,
                    LogCreadoUser = GlobalApp.AppUsername,
                    TIPO_MATERIAL = "ZRLB",
                    UNIDAD = data.UNIDAD,
                    

                    Status = "OK"
                };
                db.T0010_MATERIALES.Add(material);
                return db.SaveChanges() > 0;
            }
        }

        public bool CheckIfMaterialExistInT0010(string primario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(primario.ToUpper()));
                return x != null;
            }
        }

        public bool CheckIfMaterialExistInT0011(string codigoVenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0011_MATERIALES_AKA.SingleOrDefault(c =>
                    c.CODVENTA.ToUpper().Equals(codigoVenta.ToUpper()));
                return x != null;
            }
        }

        public int GetNumberOfAkaFromPrimario(string primario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x =
                    db.T0011_MATERIALES_AKA.Where(c => c.PRIMARIO.ToUpper().Equals(primario.ToUpper())).ToList();
                return x.Count;
            }
        }

        public T0010_MATERIALES GetPrimarioInfo(string primario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(primario.ToUpper()));
            }
        }
        public static List<string> GetMaterialList(bool soloActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloActivo)
                    return db.T0010_MATERIALES.Where(c => c.ACTIVO == soloActivo).OrderBy(c => c.IDMATERIAL)
                        .Select(c => c.IDMATERIAL).ToList();
                return db.T0010_MATERIALES.OrderBy(c => c.IDMATERIAL).Select(c => c.IDMATERIAL).ToList();
            }
        }
        public static List<string> GetMfgMaterialList(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                {
                    var lista = from primario in db.T0010_MATERIALES
                        where primario.ORIGEN.ToUpper() == "FAB" && primario.ACTIVO == true &&
                              primario.T0012_TIPO_MATERIAL.DISPO_OF == true
                        select primario.IDMATERIAL;
                    return lista.ToList();
                }
                else
                {
                    var lista = from primario in db.T0010_MATERIALES
                        where primario.ORIGEN.ToUpper() == "FAB" && primario.ACTIVO == true &&
                              primario.T0012_TIPO_MATERIAL.DISPO_OF == true
                        select primario.IDMATERIAL;
                    return lista.ToList();
                }
            }
        }
        public static List<string> GetCompraMaterialList(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                {
                    var lista = from primario in db.T0010_MATERIALES
                        where primario.ORIGEN.ToUpper() != "FAB" && primario.ACTIVO == true &&
                              primario.T0012_TIPO_MATERIAL.DISPO_OC== true
                        select primario.IDMATERIAL;
                    return lista.ToList();
                }
                else
                {
                    var lista = from primario in db.T0010_MATERIALES
                        where primario.ORIGEN.ToUpper() != "FAB" && primario.T0012_TIPO_MATERIAL.DISPO_OC == true
                        select primario.IDMATERIAL;
                    return lista.ToList();
                }
            }
        }
        public List<string> GetCompleteListMaterialAvailable()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lstPrimario = from primario in db.T0010_MATERIALES
                    select primario.IDMATERIAL;

                var lstAka = from aka in db.T0011_MATERIALES_AKA
                    select aka.CODVENTA;

                return lstPrimario.Union(lstAka).Distinct().ToList();
            }
        }
        public RetornoMMSearch BuscaMaterialSearch(string material)
        {
            var rtn = new RetornoMMSearch();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var T10 = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(material.ToUpper()));
                if (T10 == null)
                {
                    rtn.ActivoT0010 = false;
                    rtn.T0010 = false;
                    rtn.TipoT0010 = null;
                    rtn.CodigPrimario = null;
                }
                else
                {
                    if (T10.ACTIVO == null)
                        T10.ACTIVO = false;

                    rtn.ActivoT0010 = T10.ACTIVO;
                    rtn.T0010 = true;
                    rtn.TipoT0010 = T10.TIPO_MATERIAL;
                    rtn.CodigPrimario = material.ToUpper();
                }

                var T11 = db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(material.ToUpper()));
                if (T11 == null)
                {
                    rtn.ActivoT0011 = false;
                    rtn.T0011 = false;
                    rtn.TipoT0011 = null;
                }
                else
                {
                    if (T11.ACTIVO == null)
                        T11.ACTIVO = false;
                    rtn.T0011 = true;
                    rtn.ActivoT0011 = T11.ACTIVO;
                    rtn.TipoT0011 = T11.TIPO_MATERIAL;
                    rtn.CodigPrimario = T11.PRIMARIO.ToUpper();
                    rtn.CodigoAKA = T11.CODVENTA.ToUpper();
                }
            }
            return rtn;
        }

        //-------------------------------------------------------------------------------------
        //de aca para abajo revisar
        //-------------------------------------------------------------------------------------

        public List<T0010_MATERIALES> GetCompleteListofMaterial(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0010_MATERIALES.Where(c => c.ACTIVO).ToList();
                return db.T0010_MATERIALES.ToList();
            }
        }
        public List<T0010_MATERIALES> GetListMaterialAvailableToManufacture()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0010_MATERIALES.Where(c => c.ACTIVO == true && c.T0012_TIPO_MATERIAL.DISPO_OF).ToList();
            }
        }
        public List<T0010_MATERIALES> GetListMaterialAvailableAsBOMComponenet(bool onlyActive=true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0010_MATERIALES.Where(c => c.ACTIVO == true && c.T0012_TIPO_MATERIAL.DISPO_BOM).ToList();
                return db.T0010_MATERIALES.Where(c => c.T0012_TIPO_MATERIAL.DISPO_BOM).ToList();
            }
        }
        public IList<T0010_MATERIALES> GetListMaterialAvailableToBuy()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0010_MATERIALES.Where(c => c.T0012_TIPO_MATERIAL.DISPO_OC).ToList();
            }
        }
        public IList<T0010_MATERIALES> GetListMaterialSuppliedByVendor(int idProveedor)
        {
            return
                new TecserData(GlobalApp.CnnApp).T0010_MATERIALES.Where(
                    c => c.T0065_MATERIAL_PROVEEDOR.Any(x => x.ACTIVO == true && x.PROVEEDOR == idProveedor)).ToList();
        }
        public static T0010_MATERIALES GetSpecificPrimaryInformation(string primario)
        {
            return new Repository<T0010_MATERIALES>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(primario.ToUpper()));
        }
        public IList<T0010_MATERIALES> GetListMaterialFromMaterialType(string materialType)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0010_MATERIALES.Where(c => c.TIPO_MATERIAL == materialType).OrderBy(c => c.IDMATERIAL).ToList();
            }
        }
        public List<T0011_MATERIALES_AKA> GetCompleteListofAka(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive == true)
                {
                    return db.T0011_MATERIALES_AKA.Where(c => c.ACTIVO).OrderBy(c => c.CODVENTA).ToList();
                }
                else
                {
                    return db.T0011_MATERIALES_AKA.OrderBy(c => c.CODVENTA).ToList();
                }
            }

        }

        public List<T0010_MATERIALES> GetListaEnvases()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0010_MATERIALES.Where(c => c.TIPO_MATERIAL == "ENVA").ToList();
            }
        }



        public IList<T0011_MATERIALES_AKA> GetListMaterialAvailableSell()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0011_MATERIALES_AKA.Where(c => c.T0012_TIPO_MATERIAL.DISPO_FA==true).ToList();

            }
        }
        public T0011_MATERIALES_AKA GetSpecificAkaInformation(string materialAka)
        {
            return new Repository<T0011_MATERIALES_AKA>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c=>c.CODVENTA.ToUpper().Equals(materialAka.ToUpper()));
        }
        public List<T0011_MATERIALES_AKA> GetListOfAvailableAkaFromPrimario(string materialPrimario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var mat =
                    db.T0011_MATERIALES_AKA.Where(c => c.PRIMARIO.ToUpper().Equals(materialPrimario.ToUpper())).ToList();
                return mat;
            }
        }
        public string GetPrimarioFromAka(string materialAka)
        {
            var query =
                new Repository<T0011_MATERIALES_AKA>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                    c => c.CODVENTA.ToUpper().Equals(materialAka.ToUpper()));
            if (query != null)
            {
                return query.PRIMARIO;
            }
            else
            {
                var query2 =
                    new Repository<T0010_MATERIALES>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                        c => c.IDMATERIAL.ToUpper().Equals(materialAka.ToUpper()));
                if (query2 != null)
                {
                    return query2.IDMATERIAL;
                }
                else
                {
                    return "@";
                }
            }
        }
        public string GetDescripcionItemVenta(string material, string tipoRemitoLX, string tipoSolx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(material.ToUpper()));
                if (item != null)
                {
                    if (tipoSolx == "L5")
                    {
                        switch (tipoRemitoLX.ToUpper())
                        {
                            case "L1":
                                return item.MAT_DESC_L5; //Cuando es una Orden de Venta L5 en tipo L1 se devuelve la descripcion L5 (disp.....)

                            case "L2":
                                string descripcion =  "Dif.Precio " + item.MAT_DESC2;
                                return descripcion.Length <= 50 ? descripcion : descripcion.Substring(0, 50);

                            default:
                                return "ITEM";
                        }
                    }
                    else
                    {
                        //sin importar el tipo de remito siempre devuelve MAT_DESC2
                        return item.MAT_DESC2;
                    }
                }
                return "ITEM";
            }
        }
        public bool UpdateAKAInfo(T0011_MATERIALES_AKA aka)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(aka.CODVENTA.ToUpper()));
                if (data == null)
                {
                    aka.FECHA = DateTime.Now;
                    aka.LOGUSER = Environment.UserName;
                    db.T0011_MATERIALES_AKA.Add(aka);
                }
                else
                {
                    var olduser = data.LOGUSER;
                    var olddatelog = data.FECHA;
                    db.Entry(data).CurrentValues.SetValues(aka);
                    data.LOGUSER = olduser;
                    data.FECHA = olddatelog;
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool CreateUpdateMaterialT0010(T0010_MATERIALES mat)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == mat.IDMATERIAL.ToUpper());

                //Si GLI/GLV es igual al GL default by type lo borra para que quede a nivel de tipo material
                var dataTipo = new TipoMaterialManager().GetTipoMaterialData(mat.TIPO_MATERIAL);
                if (mat.GL == dataTipo.GLV)
                    mat.GL = null;

                if (mat.GLI == dataTipo.GL)
                    mat.GLI = null;

                if (data == null)
                {
                    //Creando el Material
                    mat.LogCreadoUser = GlobalApp.AppUsername;
                    mat.LogCreadoFecha = DateTime.Now;
                    mat.LogUpdateDate = null;
                    mat.LogUpdateUser = null;
                    db.T0010_MATERIALES.Add(mat);
                }
                else
                {
                    db.Entry(data).CurrentValues.SetValues(mat);
                    if (string.IsNullOrEmpty(data.LogCreadoUser))
                        data.LogCreadoUser = @"TecserEnt";

                    data.LogUpdateUser = GlobalApp.AppUsername;
                    data.LogUpdateDate = DateTime.Today;
                }
                return db.SaveChanges() > 0;
            }
        }
        public List<T0010_MATERIALES> GetListMaterialsAvailableForZRLB()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lst =
                    db.T0010_MATERIALES.Where(
                        c =>
                            c.TIPO_MATERIAL.StartsWith("MP") || c.TIPO_MATERIAL.StartsWith("PM") ||
                            c.TIPO_MATERIAL.Equals("MAST")).ToList();
                return lst;
            }
        }
   
    }
}

