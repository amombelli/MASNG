using System;
using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.SuperMD
{

    public class HumanResourcesManager
    {

        //-----------------------------------------------------------------------------------------------------------------
        public List<T0085_PERSONAL> PersonalDataSource = new List<T0085_PERSONAL>();

        //-----------------------------------------------------------------------------------------------------------------
        public bool SetInactivo(string shortname, DateTime fechaBaja)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var emp = db.T0085_PERSONAL.SingleOrDefault(c => c.SHORTNAME.ToUpper().Equals(shortname.ToUpper()));
                if (emp == null)
                    return false;

                emp.ACTIVO = false;
                emp.FechaBaja = fechaBaja;
                return db.SaveChanges() > 0;
            }
        }
        public static T0086_HHRR_POSICIONES GetPosicioneData(int idPosicion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0086_HHRR_POSICIONES.SingleOrDefault(c => c.IDPOSICION == idPosicion);
            }
        }
        public List<T0086_HHRR_POSICIONES> GetPosicionesList()
        {
            return new TecserData(GlobalApp.CnnApp).T0086_HHRR_POSICIONES.Where(c => c.Activo).ToList();
        }
        public bool CreateUpdateGeneralData(T0085_PERSONAL d)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0085_PERSONAL.SingleOrDefault(c => c.ID_VEND == d.ID_VEND);
                if (x == null)
                {
                    db.T0085_PERSONAL.Add(d);
                }
                else
                {
                    db.Entry(x).CurrentValues.SetValues(d);
                }
                return db.SaveChanges() > 0;
            }
        }
        public bool CreateUpdatePersonalData(T0085_HHRR_DATOSPERSONALES p)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0085_HHRR_DATOSPERSONALES.SingleOrDefault(c => c.IDEMPLEADO == p.IDEMPLEADO);
                if (x == null)
                {
                    db.T0085_HHRR_DATOSPERSONALES.Add(p);
                    p.UltimaActualizacionDireccion = DateTime.Now;
                }
                else
                {
                    if (x.DireccionCalle != p.DireccionCalle)
                    {
                        p.UltimaActualizacionDireccion = DateTime.Now;
                    }
                    db.Entry(x).CurrentValues.SetValues(p);
                }
                return db.SaveChanges() > 0;
            }
        }

        public bool CreateGLAccountsForEmployees(string idEmpleadoInicial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var empl = db.T0085_PERSONAL.SingleOrDefault(c => c.ID_VEND == idEmpleadoInicial);
                if (empl == null)
                    return false;

                var shortname = empl.SHORTNAME;
                var terminacionGL = empl.GL;

                new GlAccountStructureManager().CreateNewGLAccount("5.1.14." + terminacionGL,
                    "Adelantos y Devoluciones -" + shortname);
                new GlAccountStructureManager().CreateNewGLAccount("5.1.2." + terminacionGL, "Sueldo -" + shortname);
                new GlAccountStructureManager().CreateNewGLAccount("5.1.3." + terminacionGL, "HHEE -" + shortname);
                new GlAccountStructureManager().CreateNewGLAccount("5.1.4." + terminacionGL, "Comision -" + shortname);
                new GlAccountStructureManager().CreateNewGLAccount("5.1.5." + terminacionGL, "Vacaciones -" + shortname);
                new GlAccountStructureManager().CreateNewGLAccount("5.1.6." + terminacionGL,
                    "Bonificaciones -" + shortname);
                new GlAccountStructureManager().CreateNewGLAccount("5.1.7." + terminacionGL,
                    "Capacitacion -" + shortname);
                new GlAccountStructureManager().CreateNewGLAccount("5.1.9." + terminacionGL, "SAC -" + shortname);
            }

            return true;
        }


        public bool BajaCuentasGLEmpleados(string incialEmpleado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var empl = db.T0085_PERSONAL.SingleOrDefault(c => c.ID_VEND == incialEmpleado);
                if (empl == null)
                    return false;

                var shortname = empl.SHORTNAME;
                var terminacionGL = empl.GL;
                var gl4 = db.T0133_GLL3.SingleOrDefault(c => c.IDC == "5.1.14." + terminacionGL);
                if (gl4 != null)
                    gl4.ACTIVO = false;

                gl4 = db.T0133_GLL3.SingleOrDefault(c => c.IDC == "5.1.2." + terminacionGL);
                if (gl4 != null)
                    gl4.ACTIVO = false;

                gl4 = db.T0133_GLL3.SingleOrDefault(c => c.IDC == "5.1.3." + terminacionGL);
                if (gl4 != null)
                    gl4.ACTIVO = false;

                gl4 = db.T0133_GLL3.SingleOrDefault(c => c.IDC == "5.1.4." + terminacionGL);
                if (gl4 != null)
                    gl4.ACTIVO = false;

                gl4 = db.T0133_GLL3.SingleOrDefault(c => c.IDC == "5.1.5." + terminacionGL);
                if (gl4 != null)
                    gl4.ACTIVO = false;

                gl4 = db.T0133_GLL3.SingleOrDefault(c => c.IDC == "5.1.6." + terminacionGL);
                if (gl4 != null)
                    gl4.ACTIVO = false;

                gl4 = db.T0133_GLL3.SingleOrDefault(c => c.IDC == "5.1.7." + terminacionGL);
                if (gl4 != null)
                    gl4.ACTIVO = false;

                gl4 = db.T0133_GLL3.SingleOrDefault(c => c.IDC == "5.1.9." + terminacionGL);
                if (gl4 != null)
                    gl4.ACTIVO = false;


                var gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.14." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);

                gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.1." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);


                gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.2." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);

                gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.3." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);

                gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.4." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);

                gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.5." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);

                gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.6." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);

                gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.7." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);

                gl135 = db.T0135_GLX.SingleOrDefault(c => c.GL == "5.1.9." + terminacionGL);
                if (gl135 != null)
                    db.T0135_GLX.Remove(gl135);


                return db.SaveChanges()>1;
                
            }
        }

        //desde aca no revisado


        //public bool CreateUpdatePosition(T0087_REGISTROPOSICION rp)
        //{
        //    return true;
        //}

        public List<T0085_PERSONAL> GetListaEmpleadosQuincena()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0085_PERSONAL.Where(c => c.ACTIVO == true && c.SYJQ==true).ToList();
            }
        }

        public List<T0085_PERSONAL> GetListaEmpleadosMensual()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0085_PERSONAL.Where(c => c.ACTIVO == true && c.SYJ == true).ToList();
            }
        }


        public List<T0085_PERSONAL> GetListEmployees(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                {
                    return db.T0085_PERSONAL.Where(c => c.ACTIVO == true).ToList();
                }
                else
                {
                    return db.T0085_PERSONAL.ToList();
                }
            }
        }
        public T0085_PERSONAL GetEmployeeData(string idEmpleadoInicial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0085_PERSONAL.SingleOrDefault(c => c.ID_VEND.ToUpper().Equals(idEmpleadoInicial.ToUpper()));
                
            }
        }

        public T0085_PERSONAL GetEmployeeDataByShortname(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0085_PERSONAL.SingleOrDefault(c => c.SHORTNAME.ToUpper().Equals(shortname.ToUpper()));
            }
        }
        public static bool CheckIfShornameAlreadyExist(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0085_PERSONAL.SingleOrDefault(c => c.SHORTNAME.ToUpper().Equals(shortname.ToUpper()));
                return data != null;
            }
        }
        public static bool CheckIfInicialAlreadyExist(string inicial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0085_PERSONAL.SingleOrDefault(c => c.ID_VEND.ToUpper().Equals(inicial.ToUpper()));
                return data != null;
            }
        }

        /// <summary>
        /// El legajo tecser es la terminacion de la cuenta GL.- 
        /// </summary>
        /// <param name="terminacionGL"></param>
        /// <returns></returns>
        public static bool CheckIfLegajoIdAlreadyExist(int terminacionGL)
        {
            var legajo = terminacionGL.ToString();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0085_PERSONAL.SingleOrDefault(c => c.GL.Equals(legajo));
                return data != null;
            }
        }
        public T0085_HHRR_DATOSPERSONALES GetDatosPersonales(string idEmpleadoInicial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0085_HHRR_DATOSPERSONALES.SingleOrDefault(c => c.IDEMPLEADO == idEmpleadoInicial);
                return data;
            }
        }
        public List<T0085_PERSONAL> GetListAutorizaOperacionesSinCargo()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.AutorizaSinCargo.Value == true)
                    .OrderBy(c => c.SHORTNAME).ToList();
        }
        //de aca para abajo son viejas...
        public List<T0085_PERSONAL> GetListPermiteDespacho()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(
                    c => c.ACTIVO == true && c.PERMITE_DESPACHO.Value == true)
                    .OrderBy(c => c.SHORTNAME)
                    .ToList();
        }
        public List<T0085_PERSONAL> GetListAllActiveVendedor()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.PERMITE_VENTA == true)
                    .OrderBy(c => c.SHORTNAME)
                    .ToList();
        }
        public List<T0085_PERSONAL> GetListAllActiveOperario()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.PERMITE_OPERARIO == true)
                    .OrderBy(c => c.SHORTNAME)
                    .ToList();
        }
        public List<T0085_PERSONAL> GetListAllActiveCobrador()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.PERMITE_COBRANZA == true)
                    .OrderBy(c => c.SHORTNAME)
                    .ToList();
        }
        public List<T0085_PERSONAL> GetListAllActivePermiteControlIc()
        {
            return
                new Repository<T0085_PERSONAL>(new TecserData(GlobalApp.CnnApp)).Find(c => c.ACTIVO == true && c.PermiteIngresoIC == true)
                    .OrderBy(c => c.SHORTNAME).ToList();
        }
        
    }
}
