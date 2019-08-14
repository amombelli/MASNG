using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Security;
using TecserEF.Entity;
using T0001_TRANSACTIONS = TecserSQL.Data.EDMX.TSSecurity.T0001_TRANSACTIONS;

namespace Tecser.Business.MainApp
{
    public class TcodeManager
    {
        public TcodeManager()
        {

        }
        public TcodeManager(string tcode)
        {
            _tcode = tcode;
        }

        public enum TcodeResponse
        {
            TxInvalida,
            SinPermisos,
            ErrorConfig,
            TxOK
        }

        //---------------------------------------------------------------------------------
        private string _tcode;
        private T0001_TRANSACTIONS _tx;
        private bool _validadoToRun = false;
        private Type _myType;
        //---------------------------------------------------------------------------------

        public T0001_TRANSACTIONS GetTcodeData(string tcode)
        {
            using (var db = new TecserSQL.Data.EDMX.TSSecurity.TecserDataS(GlobalApp.CnnSec))
            {
                return db.T0001_TRANSACTIONS.SingleOrDefault(c => c.TCode.ToUpper().Equals(tcode.ToUpper()));
            }
        }

        public T0001_TRANSACTIONS GetTcodeDataFromFormName(string nameFormulario, string namespaceName)
        {
            var fname = nameFormulario.ToUpper();
            var nameSpace = namespaceName.ToUpper();
            using (var db = new TecserSQL.Data.EDMX.TSSecurity.TecserDataS(GlobalApp.CnnSec))
            {
                return db.T0001_TRANSACTIONS.SingleOrDefault(c =>
                    c.FormToCall.ToUpper() == fname && c.Namespace.ToUpper() == nameSpace);
            }
        }

        public void SetType(Type tipo)
        {
            _myType = tipo;
        }

        public string GetFormPath()
        {
            return _tx.Namespace.Trim() + "." + _tx.FormToCall.Trim();
        }
        
        public TcodeResponse ValidateTransactionBeforeRun(string tcode)
        {
            _tcode = tcode.ToUpper();
            _validadoToRun = false;
            using (var db = new TecserSQL.Data.EDMX.TSSecurity.TecserDataS(GlobalApp.CnnSec))
            {
                _tx = db.T0001_TRANSACTIONS.SingleOrDefault(c => c.TCode.ToUpper().Equals(_tcode));
                if (_tx == null)
                    return TcodeResponse.TxInvalida;

                if (_tx.CheckPermission)
                {
                    var resp = TsSecurityMng.CheckifRoleIsGrantedToRun(_tx.TCode, _tx.TCode);
                    if (resp == false)
                    {
                        return TcodeResponse.SinPermisos;
                    }
                }

                if (_tx.Type.Trim().ToUpper() != "FORM")
                {
                    //funcion
                    _myType = Type.GetType(_tx.Namespace.Trim() + "." + _tx.FormToCall.Trim());
                    if (_myType == null)
                    {
                        return TcodeResponse.ErrorConfig;
                    }
                }
                else
                {
                    //Form lunch
                }
            }

            _validadoToRun = true;
            return TcodeResponse.TxOK;
        }

        public string TipoTransaccion()
        {
            return _tx.Type.Trim().ToUpper();
        }

        public Form LunchFormOpen()
        {
            if (!_validadoToRun)
                return null;

            switch (_tx.NumberOfParameters)
            {
                case -1:
                    return Activator.CreateInstance(_myType) as Form;
                case 0:
                    return Activator.CreateInstance(_myType, _tx.Modo) as Form;
                case 1:
                    return Activator.CreateInstance(_myType, _tx.Modo, _tx.Arg1) as Form;
                case 2:
                    return Activator.CreateInstance(_myType, _tx.Modo, _tx.Arg1, _tx.Arg2) as Form;
                default:
                    return null;
            }
        }

        public void LunchFunctionExecution()
        {
            //aca va el codigo para ejeuctar funciones de business
        }
    }
}


