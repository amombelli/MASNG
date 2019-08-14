namespace Tecser.Business.Transactional.CO.CostManager
{
    public class CostBase
    {

        public enum CostType
        {
            Standard,
            UltimaCompra,
            PromedioPonderado,
        };

        protected string Material;
        protected decimal CostoARS;
        protected decimal CostoUSD;



        public static decimal GetCostoMercaderiaVendidaInARS(string material)
        {
            return 0;
        }

        public static decimal GetCostoMercaderiaVendidaInUSD(string material)
        {
            return 0;
        }

    }
}
