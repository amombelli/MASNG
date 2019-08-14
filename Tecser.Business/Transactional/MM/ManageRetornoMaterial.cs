using System;
using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.MM
{
    public static class MotivoDevolucion
    {
        public enum Motivo
        {
            ErrorAdmnitrativo,
            SobranteCliente,
            FE,
            PedidoIncorrecto,
            Otro
        };

        public static Motivo MapStatusFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return MotivoDevolucion.Motivo.Otro;

            //Mapeo to fix errores
            if (status.ToUpper().Equals("@@") || status.ToUpper().Equals("@@@"))
                return MotivoDevolucion.Motivo.Otro;

            try
            {
                return (Motivo)Enum.Parse(typeof(Motivo), status, true);
            }
            catch (Exception)
            {
                return MotivoDevolucion.Motivo.Otro;
                throw;
            }
        }
    }

    public class ManageRetornoMaterial
    {
        public void UpdateId40(int idH, int id40)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0360_RTN.SingleOrDefault(c => c.IDX == idH);
                data.NID40 = id40;
                db.SaveChanges();
            }
        }
        public int GuardaRtn(T0360_RTN data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (data.IDX == 0)
                {
                    data.IDX = db.T0360_RTN.Max(c => c.IDX) + 1;
                    data.LogCreadoEn =DateTime.Now;
                    data.LogCreadoPor = Environment.UserName;
                    db.T0360_RTN.Add(data);
                    return db.SaveChanges() > 0 ? data.IDX : 0;
                }
                else
                {
                   //editar 
                    return 1;
                }
            }
        }

        public List<T0360_RTN> GetDevolucionesFromCustomer(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0360_RTN.Where(c => c.IDCLI == idCliente).ToList();
            }
        }

        public void UpdateNumeroNc(int idRetorno, string numeroNc, decimal kg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0360_RTN.SingleOrDefault(c => c.IDX == idRetorno);
                if (data == null)
                    return;

                data.NumeroNC = numeroNc;
                if (data.KgNC > 0)
                {
                    data.KgNC += kg;
                }
                else
                {
                    data.KgNC = kg;
                }
                db.SaveChanges();
            }
        }
    }
}
