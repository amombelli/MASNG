using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.MasterData.BOM
{
    public class ZRLBManager
    {
        public int CreaZRLBBOM(string primario, string aka)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataPrimario = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == primario);
                if (dataPrimario == null)
                    return -1;

                var dataTipo = db.T0012_TIPO_MATERIAL.SingleOrDefault(c => c.TIPO_MATERIAL == dataPrimario.TIPO_MATERIAL);

                if (dataTipo?.DISPO_BOM == null)
                    return -1;

                if (dataTipo.DISPO_BOM == false)
                    return -1;

                if (BOMManagerMD.CheckIfBOMExist(aka))
                    return -1;

                //Se crea el material (AKA) en T0010 con tipo ZRLB de uso interno para lograr integridad referencial
                var existeprimario = new MaterialMasterManager().CheckIfMaterialExistInT0010(aka);
                if (existeprimario == false)
                {
                    //si no se puede crear el primario ZRLB -regresa -1
                    if (!new MaterialMasterManager().CreatePrimarioForZRLB(aka, primario))
                        return -1;
                }

                var bom = new BOMCreateUpdateManager(aka,"0","Formula ZRLB de " +primario,"Uso Interno");
                var numeroItem=bom.AddItem(primario, 1);
                if (numeroItem > 0)
                {
                    return bom.UpdateCreateBomFromMemory();
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
