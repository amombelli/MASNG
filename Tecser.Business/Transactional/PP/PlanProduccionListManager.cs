using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.PP
{
    public class PlanProduccionListManager
    {

        public List<T0070_PLANPRODUCCION> GetMiniListMaterialToMfg(string material, int idOFActual)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.Where(c =>
                    c.MATERIAL == material && c.IDPLAN != idOFActual && (c.STATUS == "Pendiente" || c.STATUS == "Proceso" ||
                                               c.STATUS == "Formulada" || c.STATUS == "StandBy" ||
                                               c.STATUS == "Planeado")).ToList();
                return data.OrderByDescending(c => c.IDPLAN).ToList();
            }
        }
        public List<T0070_PLANPRODUCCION> GetListPFPorEstado(bool[] ckstatus, string material = null, int numeroOF = 0,
            int top = 100)
        {
            var statusList = new PlanProduccionStatusManager().CompletaStatusList(ckstatus);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (numeroOF == 0)
                {
                    if (string.IsNullOrEmpty(material))
                    {
                        var x =
                            (from of in db.T0070_PLANPRODUCCION
                                where statusList.Contains(of.STATUS.ToUpper())
                                orderby of.IDPLAN descending
                                select of).Take(top).ToList();
                        return x;
                    }
                    else
                    {
                        var x = (from of in db.T0070_PLANPRODUCCION
                            where
                                statusList.Contains(of.STATUS.ToUpper()) &&
                                of.MATERIAL.ToUpper().Contains(material.ToUpper())
                            orderby of.IDPLAN descending
                            select of).Take(top).ToList();
                        return x;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(material))
                    {
                        //solo por OF
                        var x = (from of in db.T0070_PLANPRODUCCION
                            where statusList.Contains(of.STATUS.ToUpper()) && of.IDPLAN == numeroOF
                            orderby of.IDPLAN descending
                            select of).Take(top).ToList();
                        return x;
                    }
                    else
                    {
                        var x = (from of in db.T0070_PLANPRODUCCION
                            where
                                statusList.Contains(of.STATUS.ToUpper()) &&
                                of.MATERIAL.ToUpper().Contains(material.ToUpper()) && of.IDPLAN == numeroOF
                            orderby of.IDPLAN descending
                            select of).Take(top).ToList();
                        return x;
                    }
                }
            }
        }

        public List<T0070_PLANPRODUCCION> GetListPFPorEstado2(bool[] ckstatus, string material = null, int numeroOF = 0,
            int top = 100, int numeroRecurso = -1)
        {
            var statusList = new PlanProduccionStatusManager().CompletaStatusList(ckstatus);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (numeroRecurso > 0)
                {
                    if (numeroOF == 0)
                    {
                        if (string.IsNullOrEmpty(material))
                        {
                            var x =
                                (from of in db.T0070_PLANPRODUCCION
                                    where statusList.Contains(of.STATUS.ToUpper()) && of.RECURSO == numeroRecurso
                                    orderby of.IDPLAN descending
                                    select of).Take(top).ToList();
                            return x;
                        }
                        else
                        {
                            var x = (from of in db.T0070_PLANPRODUCCION
                                where
                                    statusList.Contains(of.STATUS.ToUpper()) &&
                                    of.MATERIAL.ToUpper().Contains(material.ToUpper()) && of.RECURSO == numeroRecurso
                                orderby of.IDPLAN descending
                                select of).Take(top).ToList();
                            return x;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(material))
                        {
                            //solo por OF
                            var x = (from of in db.T0070_PLANPRODUCCION
                                where
                                    statusList.Contains(of.STATUS.ToUpper()) && of.IDPLAN == numeroOF &&
                                    of.RECURSO == numeroRecurso
                                orderby of.IDPLAN descending
                                select of).Take(top).ToList();
                            return x;
                        }
                        else
                        {
                            var x = (from of in db.T0070_PLANPRODUCCION
                                where
                                    statusList.Contains(of.STATUS.ToUpper()) &&
                                    of.MATERIAL.ToUpper().Contains(material.ToUpper()) && of.IDPLAN == numeroOF &&
                                    of.RECURSO == numeroRecurso
                                orderby of.IDPLAN descending
                                select of).Take(top).ToList();
                            return x;
                        }
                    }
                }
                else
                {
                    /**funcion original ANTES de Agregar el NUMERO RECURSO **/
                    if (numeroOF == 0)
                    {
                        if (string.IsNullOrEmpty(material))
                        {
                            var x =
                                (from of in db.T0070_PLANPRODUCCION
                                    where statusList.Contains(of.STATUS.ToUpper())
                                    orderby of.IDPLAN descending
                                    select of).Take(top).ToList();
                            return x;
                        }
                        else
                        {
                            var x = (from of in db.T0070_PLANPRODUCCION
                                where
                                    statusList.Contains(of.STATUS.ToUpper()) &&
                                    of.MATERIAL.ToUpper().Contains(material.ToUpper())
                                orderby of.IDPLAN descending
                                select of).Take(top).ToList();
                            return x;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(material))
                        {
                            //solo por OF
                            var x = (from of in db.T0070_PLANPRODUCCION
                                where statusList.Contains(of.STATUS.ToUpper()) && of.IDPLAN == numeroOF
                                orderby of.IDPLAN descending
                                select of).Take(top).ToList();
                            return x;
                        }
                        else
                        {
                            var x = (from of in db.T0070_PLANPRODUCCION
                                where
                                    statusList.Contains(of.STATUS.ToUpper()) &&
                                    of.MATERIAL.ToUpper().Contains(material.ToUpper()) && of.IDPLAN == numeroOF
                                orderby of.IDPLAN descending
                                select of).Take(top).ToList();
                            return x;
                        }
                    }
                }
            }
        }


        public static T0070_PLANPRODUCCION GetOFData(int idplan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idplan);
            }
        }
    }
}
