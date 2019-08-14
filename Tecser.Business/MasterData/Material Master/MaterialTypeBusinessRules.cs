using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.Material_Master
{
    /// <summary>
    /// Nueva clase para manejo de reglas de negocio de materiales
    /// 2020.05.21
    /// Listados, Validaciones
    /// </summary>

    public enum MaterialOrigen
    {
        Fab,
        Nac,
        Imp,
        Nod
    };



    public class MaterialTypeBusinessRules
    {

        public List<T0011_MaterialType> GetListMtype(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0011_MaterialType.Where(c => c.Activo).ToList();
                return db.T0011_MaterialType.ToList();
            }
        }
        public T0011_MaterialType GetMtype(string mtype)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0011_MaterialType.SingleOrDefault(c => c.Mtype == mtype);
            }
        }








        public void GetMaterialesDisponibleVenta()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
        }
        public void GetMaterialsDisponibleCompra()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
        }


    }
}
