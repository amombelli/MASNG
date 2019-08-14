using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.PP
{

    //to-do lo relacionado con la adminsitracion de la selecicon del material para descontar stock, etc.

    public enum StatusStockDescuento
    {
        Confirmado,
        Unknown,
        StockOK,
        SinStock,
    };

    
    public class ProductionPlanningStockManager
    {
        public ProductionPlanningStockManager(int idPlan)
        {
            _idPlan = idPlan;
        }

        //---------------------------------------------------------------------------------------------------
        private readonly int _idPlan;
        private const string Pltn = "CERR";
        //---------------------------------------------------------------------------------------------------

        public static StatusStockDescuento MapStatusOfFromText(string statusOf)
        {
            if (string.IsNullOrEmpty(statusOf))
                statusOf = statusOf = StatusStockDescuento.Unknown.ToString();

            if (statusOf == "??")
                statusOf = StatusStockDescuento.Unknown.ToString();

            if (statusOf == "EN STOCK")
                statusOf = StatusStockDescuento.StockOK.ToString();

            if (statusOf == "NO STOCK")
                statusOf = StatusStockDescuento.SinStock.ToString();



#pragma warning disable CS0168 // The variable 'st' is declared but never used
            StatusStockDescuento st;
#pragma warning restore CS0168 // The variable 'st' is declared but never used
            try
            {
                return (StatusStockDescuento)Enum.Parse(typeof(StatusStockDescuento), statusOf, true);
            }
            catch (Exception)
            {
                return StatusStockDescuento.Unknown;
                throw;
            }
        }





        /// <summary>
        /// Chequea si hay stock suficiente para fabricar
        /// </summary>
        public bool ChequeaStockDisponibleMateriaPrimaOrdenFabricacion()
        {
            bool disponible = true;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataOF = db.T0072_FORMULA_TEMP.Where(c => c.OF == _idPlan);
                foreach (var i in dataOF)
                {
                    if (ChequeaStockDisponibleMateriaPrima(i.Primario, i.CantidadKGReal.Value) == false)
                        disponible = false;
                }
            }
            return disponible;
        }

        /// <summary>
        /// 20170707
        /// Chequea si el material que se habia reservado en la orden de fabricacion aun existe
        /// </summary>
        private bool CheckMaterialReservadoOF_Existe(int idplan, int? idstock)
        {
            if (idstock == null)
                return false;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock && c.ReservaOF == idplan);
                if (x == null)
                    return false;
                return true;
            }
        }

        /// <summary>
        /// Devuelve true si hay stock suficiente para fabricar -
        /// </summary>
        /// <returns></returns>
        private bool ChequeaStockDisponibleMateriaPrima(string material, decimal stockNecesario, string planta = "CERR")
        {
            var kgDisponible = new StockList().GetKgStockDisponibleProduccion(material, planta);

            if (kgDisponible >= stockNecesario)
                return true;
            return false;
        }
        

        /// <summary>
        /// Revisa una orden de fabricacion y completa el campo ST con EN STOCK / NO STOCK / CONFIRMADO / NO CONFIRMADO
        /// y devuelve false si algun elemento no existe.
        /// Numero Linea =-1 >> Todas las lineas
        /// </summary>
        public bool SetAndCheckStatusStockMateriasPrimasOF(int numeroLinea=-1)
        {
            var respuesta = true;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = new List<T0072_FORMULA_TEMP>();
                if (numeroLinea == -1)
                {
                    items = db.T0072_FORMULA_TEMP.Where(c => c.OF == _idPlan).ToList();
                }
                else
                {
                    items = db.T0072_FORMULA_TEMP.Where(c => c.OF == _idPlan && c.idItemFormula==numeroLinea).ToList();
                }

                foreach (var item in items)
                {
                    if (item.idStockReservado == null)
                    {
                        //No tiene stock reservado - chequea que haya stock suficiente
                        if (ChequeaStockDisponibleMateriaPrima(item.Primario, item.CantidadKGReal.Value, Pltn) == true)
                        {
                            item.StatusStock = StatusStockDescuento.StockOK.ToString();
                        }
                        else
                        {
                            item.StatusStock = StatusStockDescuento.SinStock.ToString();
                            respuesta = false;
                        }
                    }
                    else
                    {
                        if (CheckMaterialReservadoOF_Existe(_idPlan, (int) item.idStockReservado))
                        {
                            item.StatusStock = StatusStockDescuento.Confirmado.ToString();
                        }
                        else
                        {
                            item.StatusStock = StatusStockDescuento.Unknown.ToString();
                            respuesta = false;
                        }
                    }
                    item.LogUltimoChequeo = DateTime.Now;
                }
                db.SaveChanges();
                return respuesta;
            }
        }

    }
}
