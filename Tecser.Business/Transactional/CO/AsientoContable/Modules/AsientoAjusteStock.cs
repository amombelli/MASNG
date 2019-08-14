using System;
using Tecser.Business.Transactional.CO.CostManager;

namespace Tecser.Business.Transactional.CO.AsientoContable.Modules
{
    public class AsientoAjusteStock:AsientoMateriales
    {
        public AsientoAjusteStock(string tcode):base(tcode)
        {
            
        }

        /// <summary>
        /// Ajuste de Stock
        /// Tipo AI
        /// </summary>
        public IdentificacionAsiento Ajuste(string material, decimal kgAjuste, string comentario)
        {
            string comentarioH;
            glInventario = GLAccountManagement.GetGLInventarioMaterialMaster(material);
            var glPerdida = "5.9";
            var costoInventario = new CostGetData(material, CostBase.CostType.Standard).GetCostoStandardMaterial("ARS");
            var tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);

            if (string.IsNullOrEmpty(comentario))
            {
                comentarioH = "Ajuste Stock CQ";
            }
            else
            {
                comentarioH = comentario;
            }
            base.CreacionHeaderAsiento("L1", DateTime.Now, "AI", "0000-00000000", comentarioH, "ARS", costoInventario,
                tc);

            AddGenericCompleteSegment("AI", Header.REFE, "L1", glInventario, "Ajuste Inventario CQ", comentarioH, "ARS",
                DebeHaber.Debe, costoInventario*kgAjuste, Tcode, kgMaterial: kgAjuste, material: material);

            AddGenericCompleteSegment("AI", Header.REFE, "L1", glPerdida, "Ajuste Inventario CQ", comentarioH, "ARS",
                DebeHaber.Haber, costoInventario*kgAjuste, Tcode, kgMaterial: kgAjuste, material: material);

            return GrabaAsiento();



        }
    }
}
