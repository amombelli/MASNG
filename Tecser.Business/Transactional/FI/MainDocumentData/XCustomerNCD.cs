namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class XCustomerNcd:XCustomerDocumentBase
    {
        public XCustomerNcd(int idCliente, string tcode):base(idCliente,tcode)
        {
            //se usa para iniciar 
        }

        public XCustomerNcd(int idFactura):base(idFactura)
        {
            //se usa para recuperar datos
        }


    }
}
