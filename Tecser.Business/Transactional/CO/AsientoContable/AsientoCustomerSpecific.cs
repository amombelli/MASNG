namespace Tecser.Business.Transactional.CO.AsientoContable
{
    public abstract class AsientoCustomerSpecific:AsientoBase
    {
        protected AsientoCustomerSpecific(string tcode):base(tcode)
        {
            
        }

        protected abstract void LoadHeaderData();
        protected int IdCliente;
        protected string RazonSocial;
        
        protected void GeneraSegmentoAR(string tipoDocumento,string numeroDocumento,string tipoLx, DebeHaber DH, string moneda, decimal importe,string tableName, int idTableName)
        {
            var GLAR = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.AR);
            var descripcion1 = "A/R" + RazonSocial;
            string descripcion2;

            switch (tipoDocumento)
            {
                case "CO":
                    descripcion2 = "Cobranza " + RazonSocial;
                    break;
                case "FA":
                    descripcion2 = "Factura " + RazonSocial;
                    break;
                case "NC":
                    descripcion2 = "Nota Credito " + RazonSocial;
                    break;
                case "ND":
                    descripcion2 = "Nota Debito " + RazonSocial;
                    break;
                default:
                    descripcion2 = "???????? " + RazonSocial;
                    break;
            }

            AddGenericCompleteSegment(tipoDocumento, numeroDocumento, tipoLx, GLAR, descripcion1, descripcion2, moneda,
                DH, importe, Tcode, IdCliente, 0, tableName, idTableName);
        }
    }
}
