using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MasterData;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.CO.AsientoContable
{
    /// <summary>
    /// Clase principal (Base) de manejo de asientos contables
    /// Esta nueva estructura tiene que reemplazar a all clases asiento que no hereden de esta
    /// Fecha Update 2018.01.31
    /// </summary>
    public abstract class AsientoBase
    {
        protected AsientoBase(string tCode)
        {
            Tcode = tCode;
        }
        protected T0601_DOCU_H Header { get; set; }
        protected readonly List<T0602_DOCU_S> Items = new List<T0602_DOCU_S>();
        protected readonly string Tcode;
        protected string TipoDocumento;
        protected string NumeroDocumento;
        public struct IdentificacionAsiento
        {
            public int IdDocu { get; set; }
            public decimal NasX1 { get; set; }
            public decimal NasX2 { get; set; }
        }
        protected enum DebeHaber
        {
            Debe,
            Haber
        };


        //-------------------------------------------------------------------------------------------------------//
        //Funciones optimizadas 2018.03.12
        //Genera asiento nuevo con los datos reversados y comentario >> Cancelacion Documento <<
        //-------------------------------------------------------------------------------------------------------//
        internal IdentificacionAsiento ReversaAsiento(int numeroAsientoOriginal,string comentario=null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string coment = "Cancelacion Documento";
                if (!string.IsNullOrEmpty(comentario))
                {
                    coment = comentario;
                }

                var ori = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == numeroAsientoOriginal);
                CreacionHeaderAsiento(ori.TIPO, ori.FECHA.Value,"CAN", ori.REFE, coment, ori.MONE_ORI,
                    ori.TOT_ORI.Value, ori.TC.Value);

                Header.ALINK = numeroAsientoOriginal;

                var lst = db.T0602_DOCU_S.Where(c => c.IDDOCU == numeroAsientoOriginal).ToList();
                foreach (var i in lst)
                {
                    int idCliente = 0;
                    int idProveedor = 0;

                    if (i.CLIENTE != null)
                        idCliente = Convert.ToInt32(i.CLIENTE);

                    if (i.PROV != null)
                        idProveedor = Convert.ToInt32(i.PROV);
                    if (i.DEBE.Value > 0)
                    {
                        AddGenericCompleteSegment(i.DOCUTIPO, i.REFE, i.TIPO, i.GL, coment, "", null,
                            DebeHaber.Haber, i.DEBE.Value, i.TCODE, idCliente, idProveedor);
                    }
                    else
                    {
                        AddGenericCompleteSegment(i.DOCUTIPO, i.REFE, i.TIPO, i.GL, coment, "",null,
                            DebeHaber.Debe,i.HABER.Value, i.TCODE, idCliente,idProveedor);
                    }
                }
            }
            return GrabaAsiento();
        }

        /// <summary>
        /// Funcion que inicializa el Header del asiento en memoria.
        /// Los id del asiento se generan al grabarlo en memoria. Importe ARS si no se provee se calcula automaticamente (sentido solo en USD)
        /// </summary>
        protected virtual void CreacionHeaderAsiento(string lx, DateTime fechaDocumento, string tipoDocumento, string numeroDocumento, string textoHeader, string moneda,decimal importeMonedaOrigen,
            decimal xchangeRate,decimal importeARS=0)
        {
            Header = new T0601_DOCU_H
            {
                TIPO = lx,
                FECHA = fechaDocumento.Date,
                MES = new PeriodoConversion().GetMesMm(fechaDocumento),
                YEAR = new PeriodoConversion().GetYearYyyy(fechaDocumento),
                DOCUTIPO = tipoDocumento,
                MONE_ORI = moneda,
                TOT_ORI = importeMonedaOrigen,
                REFE = numeroDocumento,
                HeaderText = textoHeader,
                TC = xchangeRate,

                //default values
                CK = false,
                StatusCancel = false,
                ALINK = null,

                //values to update before save
                FECHA_HOY = null,
                FechaOP = null,
                LOG_USER = Environment.UserDomainName,
                OR = null,
                RE = false,
                ST = "INI",
                IDDOCU = 0,
                NASX1 = 0,
                NASX2 = 0,
                ID = "-",
                //ZTERM = todo DELETE THIS FIELD               
            };
            if (moneda == "ARS")
            {
                Header.TOT_ARS = Header.TOT_ORI;
            }
            else
            {
                if (importeARS == 0)
                {
                    Header.TOT_ARS = Header.TOT_ORI*xchangeRate;
                }
                else
                {
                    Header.TOT_ARS = importeARS;
                }
            }
        }

        /// <summary>
        /// Metodo completo para cargar todos los datos de un segmento
        /// sino que solo lo completa en memoria. Usar metodo AddSegmentoToAsientoList.
        /// IdCliente = 0 no es cliente
        /// IdProveedor = 0 no es proveedor
        /// </summary>
        protected int AddGenericCompleteSegment(string tipoDocumento, string numeroDocumento, string lx, string gl, string descripcion1,
            string descripcion2, string moneda, DebeHaber debeHaber, decimal importeDebeHaber, string tcode,
            int idCliente = 0, int idProveedor = 0, string nombreTabla = null, int? idNumerico = null,
            string idTexto = null, decimal? kgMaterial = null, string material = null, int? idTabla40 =null)
        {
            var seg = new T0602_DOCU_S
            {
                DOCUTIPO = tipoDocumento,
                REFE = numeroDocumento,
                TIPO = lx,
                GL = gl,
                SEGTEXT = descripcion1,
                SEGTEXT2 = descripcion2,
                MONE_ORI = moneda,
                DC = debeHaber.ToString(),
                TCODE = tcode,
                HORA_OP = DateTime.Now,

                //CUENTA = null, todo eliminar este campo
                //CC todo eliminar este campo

                FECHA_HOY = DateTime.Now,
                IMPORTE_ORI = importeDebeHaber,

                //mantenido default
                ALINK = 0,
                GLL3 = null,
                GLORI = null,
                ST = null,
                CK = false,
            };

            if (idTabla40 != null)
                seg.ID40 = idTabla40;
            
            if (kgMaterial != null)
                seg.KGMAT = kgMaterial;
           
            if (moneda == "ARS")
            {
                seg.IMPORTE_ARS = importeDebeHaber;
            }
            else
            {
                seg.IMPORTE_ARS = importeDebeHaber*Header.TC;
            }

            if (string.IsNullOrEmpty(nombreTabla) == false)
            {
                seg.REF_ALT_TBLID = nombreTabla;
            }

            if (idNumerico > 0)
            {
                seg.REF_ALT_IDNUM = idNumerico.ToString();
            }

            if (string.IsNullOrEmpty(idTexto) == false)
            {
                seg.REF_ALT_IDTXT = idTexto;
            }

            if (string.IsNullOrEmpty(material) == false)
            {
                seg.MATERIAL = material;
            }

            if (debeHaber == DebeHaber.Debe)
            {
                seg.DEBE = importeDebeHaber;
                seg.HABER = 0;
            }
            else
            {
                seg.DEBE = 0;
                seg.HABER = importeDebeHaber;
            }

            //Si el IdCliente o el IdProveedor es provisto se completa
            if (idCliente > 0)
            {
                seg.CLIENTE = idCliente.ToString();
                var cli = new CustomerManager().GetCustomerBillToData(idCliente);
                if (cli != null)
                    seg.CLIPROV_DESC = cli.cli_rsocial;
            }
            else
            {
                if (idProveedor > 0)
                {
                    seg.PROV = idProveedor.ToString();
                    var pro = new VendorManager().GetSpecificVendor(idProveedor);
                    if (pro != null)
                    {
                        seg.CLIPROV_DESC = pro.prov_rsocial;
                    }
                }
            }

            //Mantenido al Agregar Segmento a la lista
            seg.YEAR = "0";
            seg.MES = "0";
            seg.PERIODO = null;
            seg.TC = 0;
            seg.IDSEG = 0;

            //Mantenido al Grabar
            seg.IDDOCU = 0;
            seg.NASX1 = 0;
            seg.NASX2 = 0;
            seg.LOG_USER = null;
            seg.UPDUSER = null;
            return AddGenericCompleteSegment(seg);
        }

        /// <summary>
        /// funcion que agrega el item de un asiento a la lista en memoria
        /// Retorna la cantidad de items del Asiento
        /// </summary>
        private int AddGenericCompleteSegment(T0602_DOCU_S s)
        {
            s.IDSEG = Items.Count() + 1;
            s.MES = Header.MES;
            s.YEAR = Header.YEAR;
            s.TC = Header.TC;
            s.PERIODO = Header.YEAR + Header.MES;
            Items.Add(s);
            return Items.Count;
        }
        protected IdentificacionAsiento GrabaAsiento()
        {
            if (CheckIfAsientoIsOK())
            {
                return new AsientoDbManager().GrabaAsientoEnDatabase(Header, Items);
            }
            else
            {
                var resultado = new AsientoBase.IdentificacionAsiento
                {
                    IdDocu = 0,
                    NasX1 = 0,
                    NasX2 = 0
                };
                return resultado;
            }
        }


        /// <summary>
        /// Validacion de DEBE = HABER
        /// </summary>
        private bool CheckIfAsientoIsOK()
        {
            //todo: Completar la funcion con otras validaciones en caso de ser necesario

            decimal sumaDebe = 0;
            decimal sumaHaber = 0;
            foreach (var item in Items)
            {
                sumaDebe = sumaDebe + Convert.ToDecimal(item.DEBE);
                sumaHaber = sumaHaber + Convert.ToDecimal(item.HABER);
            }

            if (sumaDebe != sumaHaber)
            {
                if (Math.Abs(sumaDebe - sumaHaber) > (sumaDebe*(decimal) 0.05))
                {
                    return false;
                }
                else
                {
                    var dif = sumaDebe - sumaHaber;
                    if (sumaDebe<sumaHaber)
                    {
                        AddGenericCompleteSegment("DIF", Header.REFE, Header.TIPO, "0.0.0.0", "Diferencia Redondeo", "-",
                            "ARS", DebeHaber.Debe, Math.Abs(dif), Tcode);
                    }
                    else
                    {
                        AddGenericCompleteSegment("DIF", Header.REFE, Header.TIPO, "0.0.0.0", "Diferencia Redondeo", "-",
                            "ARS", DebeHaber.Haber, Math.Abs(dif), Tcode);
                    }

                }
            }


            Header.TOT_ORI = sumaDebe;
            if (Header.MONE_ORI == "ARS")
            {
                Header.TOT_ARS = sumaDebe;
            }
            else
            {
                Header.TOT_ARS = sumaDebe * Header.TC.Value;
            }
            return true;
        }

        protected string GetSystemDocumentType(ManageDocumentType.TipoDocumento tipo)
        {
            return ManageDocumentType.GetSystemDocumentType(tipo);
        }
    }
}
