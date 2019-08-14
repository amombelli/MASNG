using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class CostoBaseManager
    {
        public enum TipoCosto
        {
            MfgRepo,
            MfgHisto,
            Reposicion,
            Standard,
            PPP,
            Operacion
        }

        public struct Costo
        {
            public decimal CostoARS;
            public decimal CostoUSD;
            public string Moneda;
            public decimal TcConversion;
            public DateTime FechaCosto;
            public string UsuarioLog;
            public string CostDetermination;
        }

        public struct CostMini
        {
            public decimal ARS;
            public decimal USD;
            public decimal Porcentaje;
            public DateTime Fecha;
            public int LevelMax;
        }
        protected const decimal ValorCostoMaximo=999999;

    }
}
