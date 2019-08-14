using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.MasterData
{
    public class TipoMaterialManager
    {
        //todo: intentar unificar con MaterialTypeManager class
        public List<T0012_TIPO_MATERIAL> GetAllTipoMaterial(bool onlyActive = false)
        {

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive == true)
                {
                    return db.T0012_TIPO_MATERIAL.ToList();
                }
                else
                {
                    return db.T0012_TIPO_MATERIAL.ToList();
                }
            }
        }
        public T0012_TIPO_MATERIAL GetTipoMaterialData(string tipoMaterial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0012_TIPO_MATERIAL.SingleOrDefault(c => c.TIPO_MATERIAL.Equals(tipoMaterial));
            }
        }
        public List<T0012_TIPO_MATERIAL> GetAllTipoMaterialForAKA()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0012_TIPO_MATERIAL.Where(c => c.MM_AKA).ToList();
            }

        }

    }
}
