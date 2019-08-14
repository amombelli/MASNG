using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;
using Tecser.Business.MainApp;

namespace Tecser.Business.SuperMD
{
    public class MaterialTypeManager
    {
        public List<T0012_TIPO_MATERIAL> GetAllAvailableMaterialType()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0012_TIPO_MATERIAL.ToList();
            }
        }

        public T0012_TIPO_MATERIAL GetMaterialTypeData(string tipoMaterial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0012_TIPO_MATERIAL.SingleOrDefault(c => c.TIPO_MATERIAL.ToUpper().Equals(tipoMaterial.ToUpper()));
            }
        }

        public int SaveMaterialTypeData(T0012_TIPO_MATERIAL data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataDb =
                    db.T0012_TIPO_MATERIAL.SingleOrDefault(
                        c => c.TIPO_MATERIAL.ToUpper().Equals(data.TIPO_MATERIAL.ToUpper()));
                if (dataDb == null)
                {
                    db.T0012_TIPO_MATERIAL.Add(data);
                }
                else
                {
                    db.Entry(dataDb).CurrentValues.SetValues(data);
                }
                return db.SaveChanges();
            }
        }
    }
}
