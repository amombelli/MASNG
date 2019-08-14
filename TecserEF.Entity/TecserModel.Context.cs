﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TecserEF.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TecserData : DbContext
    {
        public TecserData()
            : base("name=TecserData")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomerMensajes> CustomerMensajes { get; set; }
        public virtual DbSet<T_AFIP_CAE> T_AFIP_CAE { get; set; }
        public virtual DbSet<T000> T000 { get; set; }
        public virtual DbSet<T0001_TRAN> T0001_TRAN { get; set; }
        public virtual DbSet<T0001_TRANSACTIONS> T0001_TRANSACTIONS { get; set; }
        public virtual DbSet<T0004_ASN> T0004_ASN { get; set; }
        public virtual DbSet<T0005_MPROVEEDORES> T0005_MPROVEEDORES { get; set; }
        public virtual DbSet<T0006_MCLIENTES> T0006_MCLIENTES { get; set; }
        public virtual DbSet<T0007_CLI_ENTREGA> T0007_CLI_ENTREGA { get; set; }
        public virtual DbSet<T0008_REGION> T0008_REGION { get; set; }
        public virtual DbSet<T0009_MATERIALSPEC> T0009_MATERIALSPEC { get; set; }
        public virtual DbSet<T0010_LOCALIDAD> T0010_LOCALIDAD { get; set; }
        public virtual DbSet<T0010_PARTIDO> T0010_PARTIDO { get; set; }
        public virtual DbSet<T0013_COLORES> T0013_COLORES { get; set; }
        public virtual DbSet<T0014_TIPO_PROVEEDOR> T0014_TIPO_PROVEEDOR { get; set; }
        public virtual DbSet<T0015_TIPO_FACTURA> T0015_TIPO_FACTURA { get; set; }
        public virtual DbSet<T0016_PLANTAS> T0016_PLANTAS { get; set; }
        public virtual DbSet<T0017_CONDIVA> T0017_CONDIVA { get; set; }
        public virtual DbSet<T0018_TIPORESP> T0018_TIPORESP { get; set; }
        public virtual DbSet<T0019_ZTERM> T0019_ZTERM { get; set; }
        public virtual DbSet<T0021_FORMULA_I> T0021_FORMULA_I { get; set; }
        public virtual DbSet<T0027_ORIGEN> T0027_ORIGEN { get; set; }
        public virtual DbSet<T0028_SLOC> T0028_SLOC { get; set; }
        public virtual DbSet<T0029_ESTADO_STOCK> T0029_ESTADO_STOCK { get; set; }
        public virtual DbSet<T0030_STOCK> T0030_STOCK { get; set; }
        public virtual DbSet<T0032_RECURSOS> T0032_RECURSOS { get; set; }
        public virtual DbSet<T0033_COSTL0> T0033_COSTL0 { get; set; }
        public virtual DbSet<T0033_COSTL1> T0033_COSTL1 { get; set; }
        public virtual DbSet<T0033_COSTL2> T0033_COSTL2 { get; set; }
        public virtual DbSet<T0033_COSTL3> T0033_COSTL3 { get; set; }
        public virtual DbSet<T0033_COSTL4> T0033_COSTL4 { get; set; }
        public virtual DbSet<T0033_COSTL5> T0033_COSTL5 { get; set; }
        public virtual DbSet<T0033_COSTL6> T0033_COSTL6 { get; set; }
        public virtual DbSet<T0033_COSTL7> T0033_COSTL7 { get; set; }
        public virtual DbSet<T0033_COSTL8> T0033_COSTL8 { get; set; }
        public virtual DbSet<T0033_COSTL9> T0033_COSTL9 { get; set; }
        public virtual DbSet<T0033_COSTO> T0033_COSTO { get; set; }
        public virtual DbSet<T0034_COSTO_EVAL_NP> T0034_COSTO_EVAL_NP { get; set; }
        public virtual DbSet<T0035_COSTO_EVAL> T0035_COSTO_EVAL { get; set; }
        public virtual DbSet<T0040_MAT_MOVIMIENTOS> T0040_MAT_MOVIMIENTOS { get; set; }
        public virtual DbSet<T0041_LOG_CAMBIOS_NP> T0041_LOG_CAMBIOS_NP { get; set; }
        public virtual DbSet<T0042_PRODUCCION_DET> T0042_PRODUCCION_DET { get; set; }
        public virtual DbSet<T0045_OV_HEADER> T0045_OV_HEADER { get; set; }
        public virtual DbSet<T0046_OV_ITEM> T0046_OV_ITEM { get; set; }
        public virtual DbSet<T0047_MATERIAL_CLIENTE> T0047_MATERIAL_CLIENTE { get; set; }
        public virtual DbSet<T0048_NOTA_CLIENTES> T0048_NOTA_CLIENTES { get; set; }
        public virtual DbSet<T0050_REQUISICION> T0050_REQUISICION { get; set; }
        public virtual DbSet<T0055_REMITO_H> T0055_REMITO_H { get; set; }
        public virtual DbSet<T0056_REMITO_I> T0056_REMITO_I { get; set; }
        public virtual DbSet<T0057_REMITO_I_PRINT> T0057_REMITO_I_PRINT { get; set; }
        public virtual DbSet<T0059_ENTREGAS> T0059_ENTREGAS { get; set; }
        public virtual DbSet<T0059_HOJARUTA_H> T0059_HOJARUTA_H { get; set; }
        public virtual DbSet<T0059_HOJARUTA_I> T0059_HOJARUTA_I { get; set; }
        public virtual DbSet<T0059_LOGSDPROCESS> T0059_LOGSDPROCESS { get; set; }
        public virtual DbSet<T0060_OCOMPRA_H> T0060_OCOMPRA_H { get; set; }
        public virtual DbSet<T0061_OCOMPRA_I> T0061_OCOMPRA_I { get; set; }
        public virtual DbSet<T0063_ITEMS_OC_INGRESADOS> T0063_ITEMS_OC_INGRESADOS { get; set; }
        public virtual DbSet<T0065_MATERIAL_PROVEEDOR> T0065_MATERIAL_PROVEEDOR { get; set; }
        public virtual DbSet<T0066_ITEMS_PROVEEDOR_OC> T0066_ITEMS_PROVEEDOR_OC { get; set; }
        public virtual DbSet<T0070_PLANPRODUCCION> T0070_PLANPRODUCCION { get; set; }
        public virtual DbSet<T0073_FORMULA_PRINT> T0073_FORMULA_PRINT { get; set; }
        public virtual DbSet<T0080_TIPO_MOVIMIENTOS> T0080_TIPO_MOVIMIENTOS { get; set; }
        public virtual DbSet<T0085_PERSONAL> T0085_PERSONAL { get; set; }
        public virtual DbSet<T0099_NELS> T0099_NELS { get; set; }
        public virtual DbSet<T0100_MATERIAL_PROVEEDOR> T0100_MATERIAL_PROVEEDOR { get; set; }
        public virtual DbSet<T0102_EXCHANGE> T0102_EXCHANGE { get; set; }
        public virtual DbSet<T0130_GLL0> T0130_GLL0 { get; set; }
        public virtual DbSet<T0131_GLL1> T0131_GLL1 { get; set; }
        public virtual DbSet<T0132_GLL2> T0132_GLL2 { get; set; }
        public virtual DbSet<T0133_GLL3> T0133_GLL3 { get; set; }
        public virtual DbSet<T0134_GLL4> T0134_GLL4 { get; set; }
        public virtual DbSet<T0135_GLX> T0135_GLX { get; set; }
        public virtual DbSet<T0135_GLX_FF> T0135_GLX_FF { get; set; }
        public virtual DbSet<T0136_GLTREE> T0136_GLTREE { get; set; }
        public virtual DbSet<T0137_GL_MAPPING> T0137_GL_MAPPING { get; set; }
        public virtual DbSet<T0138_PERIODOS> T0138_PERIODOS { get; set; }
        public virtual DbSet<T0150_CUENTAS> T0150_CUENTAS { get; set; }
        public virtual DbSet<T0151_MONEDAS> T0151_MONEDAS { get; set; }
        public virtual DbSet<T0154_CHEQUES> T0154_CHEQUES { get; set; }
        public virtual DbSet<T0155_SALDOS> T0155_SALDOS { get; set; }
        public virtual DbSet<T0156_CHEQUE_RECH> T0156_CHEQUE_RECH { get; set; }
        public virtual DbSet<T0157_INFOCUITCHEQUE> T0157_INFOCUITCHEQUE { get; set; }
        public virtual DbSet<T0160_BANCOS> T0160_BANCOS { get; set; }
        public virtual DbSet<T0190_TAX> T0190_TAX { get; set; }
        public virtual DbSet<T0201_CTACTE> T0201_CTACTE { get; set; }
        public virtual DbSet<T0202_CTACTESALDOS> T0202_CTACTESALDOS { get; set; }
        public virtual DbSet<T0203_CTACTE_PROV> T0203_CTACTE_PROV { get; set; }
        public virtual DbSet<T0203_CTACTE_PROV_IMPU> T0203_CTACTE_PROV_IMPU { get; set; }
        public virtual DbSet<T0204_CTACTESALDOS_PROV> T0204_CTACTESALDOS_PROV { get; set; }
        public virtual DbSet<T0205_COBRANZA_H> T0205_COBRANZA_H { get; set; }
        public virtual DbSet<T0206_COBRANZA_I> T0206_COBRANZA_I { get; set; }
        public virtual DbSet<T0207_SPLITFACTURAS> T0207_SPLITFACTURAS { get; set; }
        public virtual DbSet<T0208_COB_NO_APLICADA> T0208_COB_NO_APLICADA { get; set; }
        public virtual DbSet<T0210_OP_H> T0210_OP_H { get; set; }
        public virtual DbSet<T0212_OP_ITEM> T0212_OP_ITEM { get; set; }
        public virtual DbSet<T0213_OP_FACT> T0213_OP_FACT { get; set; }
        public virtual DbSet<T0300_NCD_H> T0300_NCD_H { get; set; }
        public virtual DbSet<T0301_NCD_I> T0301_NCD_I { get; set; }
        public virtual DbSet<T0310_NCDP_H> T0310_NCDP_H { get; set; }
        public virtual DbSet<T0311_NCDP_I> T0311_NCDP_I { get; set; }
        public virtual DbSet<T0360_RTN> T0360_RTN { get; set; }
        public virtual DbSet<T0400_FACTURA_H> T0400_FACTURA_H { get; set; }
        public virtual DbSet<T0401_FACTURA_I> T0401_FACTURA_I { get; set; }
        public virtual DbSet<T0402_FACTURA_PERCEP> T0402_FACTURA_PERCEP { get; set; }
        public virtual DbSet<T0405_FACTURAS_RETENCIONES> T0405_FACTURAS_RETENCIONES { get; set; }
        public virtual DbSet<T0406_RendicionFF_H> T0406_RendicionFF_H { get; set; }
        public virtual DbSet<T0407_RendicionFF_I> T0407_RendicionFF_I { get; set; }
        public virtual DbSet<T0601_DOCU_H> T0601_DOCU_H { get; set; }
        public virtual DbSet<T0602_DOCU_S> T0602_DOCU_S { get; set; }
        public virtual DbSet<T0603_DOCTYPES> T0603_DOCTYPES { get; set; }
        public virtual DbSet<T0605_DOCUCONFIG> T0605_DOCUCONFIG { get; set; }
        public virtual DbSet<T0606_DOCUCONTACLI> T0606_DOCUCONTACLI { get; set; }
        public virtual DbSet<T0820_CQ1H> T0820_CQ1H { get; set; }
        public virtual DbSet<T1010_GESPA_H> T1010_GESPA_H { get; set; }
        public virtual DbSet<T1010_LOGCUSTOMERMERGE> T1010_LOGCUSTOMERMERGE { get; set; }
        public virtual DbSet<T1011_GESPA_MENSAJES> T1011_GESPA_MENSAJES { get; set; }
        public virtual DbSet<T1205_CobranzaConvertirHeader> T1205_CobranzaConvertirHeader { get; set; }
        public virtual DbSet<T1206_CobranzaConvertirItems> T1206_CobranzaConvertirItems { get; set; }
        public virtual DbSet<TApplicationConfig> TApplicationConfig { get; set; }
        public virtual DbSet<TAUX_G2> TAUX_G2 { get; set; }
        public virtual DbSet<TAUX_G3> TAUX_G3 { get; set; }
        public virtual DbSet<TLogTcode> TLogTcode { get; set; }
        public virtual DbSet<TSecRole> TSecRole { get; set; }
        public virtual DbSet<TSecRoleAssignment> TSecRoleAssignment { get; set; }
        public virtual DbSet<TSecurityLog> TSecurityLog { get; set; }
        public virtual DbSet<TsecurityLogCheck> TsecurityLogCheck { get; set; }
        public virtual DbSet<TSecUsr> TSecUsr { get; set; }
        public virtual DbSet<TTAXRetGananciasConfig> TTAXRetGananciasConfig { get; set; }
        public virtual DbSet<TTAXRetPerConfig> TTAXRetPerConfig { get; set; }
        public virtual DbSet<TTAXRetPerData> TTAXRetPerData { get; set; }
        public virtual DbSet<XREGISTER> XREGISTER { get; set; }
        public virtual DbSet<XREGISTER_H> XREGISTER_H { get; set; }
        public virtual DbSet<XREGISTER_I> XREGISTER_I { get; set; }
        public virtual DbSet<CAE> CAE { get; set; }
        public virtual DbSet<CRM01XP> CRM01XP { get; set; }
        public virtual DbSet<CRM02XP> CRM02XP { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<T0002_LOG> T0002_LOG { get; set; }
        public virtual DbSet<T0010_MATERIALES_NCD> T0010_MATERIALES_NCD { get; set; }
        public virtual DbSet<T0022_MRH> T0022_MRH { get; set; }
        public virtual DbSet<T0031_STOCK_CHG> T0031_STOCK_CHG { get; set; }
        public virtual DbSet<T0042_MM40_CONFIG> T0042_MM40_CONFIG { get; set; }
        public virtual DbSet<T0057_DESPACHOS_TEMP> T0057_DESPACHOS_TEMP { get; set; }
        public virtual DbSet<T0057_DESPACHOS_TEMP3> T0057_DESPACHOS_TEMP3 { get; set; }
        public virtual DbSet<T0075_RESERVA_PF> T0075_RESERVA_PF { get; set; }
        public virtual DbSet<T0090_CLIENTE_MATERIAL> T0090_CLIENTE_MATERIAL { get; set; }
        public virtual DbSet<T0098_MUESTRAS> T0098_MUESTRAS { get; set; }
        public virtual DbSet<T0101_MATERIAL_PROVEEDOR_TEMP> T0101_MATERIAL_PROVEEDOR_TEMP { get; set; }
        public virtual DbSet<T0121_CCN2> T0121_CCN2 { get; set; }
        public virtual DbSet<T0139_GL_CIERRE_TEMPORAL> T0139_GL_CIERRE_TEMPORAL { get; set; }
        public virtual DbSet<T0140_GL_CIERRE_EJERCICIO> T0140_GL_CIERRE_EJERCICIO { get; set; }
        public virtual DbSet<T0290_COMPFACT_T> T0290_COMPFACT_T { get; set; }
        public virtual DbSet<T0500_ERROR_MOV_STK> T0500_ERROR_MOV_STK { get; set; }
        public virtual DbSet<T0501_SYJTEMP> T0501_SYJTEMP { get; set; }
        public virtual DbSet<T0502_SYJ_H> T0502_SYJ_H { get; set; }
        public virtual DbSet<T0503_SYJ_I> T0503_SYJ_I { get; set; }
        public virtual DbSet<T0504_SYJ_PAYTEMP> T0504_SYJ_PAYTEMP { get; set; }
        public virtual DbSet<T0505_SYJ_PAYITEMS> T0505_SYJ_PAYITEMS { get; set; }
        public virtual DbSet<T0506_SYJ_IMPU> T0506_SYJ_IMPU { get; set; }
        public virtual DbSet<T0510_ADELANTOS_H> T0510_ADELANTOS_H { get; set; }
        public virtual DbSet<T0511_ADELANTOS_I> T0511_ADELANTOS_I { get; set; }
        public virtual DbSet<T0821_CQ1I> T0821_CQ1I { get; set; }
        public virtual DbSet<T992_DOCUMENTOS_CONFIG> T992_DOCUMENTOS_CONFIG { get; set; }
        public virtual DbSet<TAUX_G4_MSG_HISTORY> TAUX_G4_MSG_HISTORY { get; set; }
        public virtual DbSet<tbLConfigForm> tbLConfigForm { get; set; }
        public virtual DbSet<Tmp_T0601_DOCU_H> Tmp_T0601_DOCU_H { get; set; }
        public virtual DbSet<TX001> TX001 { get; set; }
        public virtual DbSet<USR000> USR000 { get; set; }
        public virtual DbSet<USR001> USR001 { get; set; }
        public virtual DbSet<USR002> USR002 { get; set; }
        public virtual DbSet<USR003> USR003 { get; set; }
        public virtual DbSet<USR005> USR005 { get; set; }
        public virtual DbSet<USR999> USR999 { get; set; }
        public virtual DbSet<ZBALL2> ZBALL2 { get; set; }
        public virtual DbSet<T0099_NELUPDATE> T0099_NELUPDATE { get; set; }
        public virtual DbSet<T0086_HHRR_POSICIONES> T0086_HHRR_POSICIONES { get; set; }
        public virtual DbSet<T0085_HHRR_DATOSPERSONALES> T0085_HHRR_DATOSPERSONALES { get; set; }
        public virtual DbSet<T0010_Container> T0010_Container { get; set; }
        public virtual DbSet<TblDocumentacionForm> TblDocumentacionForm { get; set; }
        public virtual DbSet<TL001_MsgLog> TL001_MsgLog { get; set; }
        public virtual DbSet<T0072_FORMULA_TEMP> T0072_FORMULA_TEMP { get; set; }
        public virtual DbSet<tLogBloqueoClientes> tLogBloqueoClientes { get; set; }
        public virtual DbSet<TMensajes01> TMensajes01 { get; set; }
        public virtual DbSet<T0020_FORMULA_H> T0020_FORMULA_H { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T0810_QMHeaderData> T0810_QMHeaderData { get; set; }
        public virtual DbSet<T0811_QMDetailData> T0811_QMDetailData { get; set; }
        public virtual DbSet<T0801_QMMasterIPHeader> T0801_QMMasterIPHeader { get; set; }
        public virtual DbSet<T0802_QMMasterIPDetail> T0802_QMMasterIPDetail { get; set; }
        public virtual DbSet<T0800_QMMetodosInspeccion> T0800_QMMetodosInspeccion { get; set; }
        public virtual DbSet<T0805_QMIRecordH1> T0805_QMIRecordH1 { get; set; }
        public virtual DbSet<T0806_QMIRecordH2> T0806_QMIRecordH2 { get; set; }
        public virtual DbSet<T0807QMIDetail> T0807QMIDetail { get; set; }
        public virtual DbSet<T0036_CostoReposicion> T0036_CostoReposicion { get; set; }
        public virtual DbSet<T0037_CostoMfg> T0037_CostoMfg { get; set; }
        public virtual DbSet<T0038_CostoMfgExplo> T0038_CostoMfgExplo { get; set; }
        public virtual DbSet<T0039_CostoStandard> T0039_CostoStandard { get; set; }
        public virtual DbSet<T0403_VENDOR_FACT_H> T0403_VENDOR_FACT_H { get; set; }
        public virtual DbSet<T0404_VENDOR_FACT_I> T0404_VENDOR_FACT_I { get; set; }
        public virtual DbSet<T0518_ConceptosHR> T0518_ConceptosHR { get; set; }
        public virtual DbSet<T0519_SYJHeader> T0519_SYJHeader { get; set; }
        public virtual DbSet<T0520_SYJItems> T0520_SYJItems { get; set; }
        public virtual DbSet<T0525_SueldoAdelanto> T0525_SueldoAdelanto { get; set; }
        public virtual DbSet<T0068RequisicionCompra> T0068RequisicionCompra { get; set; }
        public virtual DbSet<T0231_GescoDetail> T0231_GescoDetail { get; set; }
        public virtual DbSet<T0232_GescoPagosListos> T0232_GescoPagosListos { get; set; }
        public virtual DbSet<T0230_GescoHeader> T0230_GescoHeader { get; set; }
        public virtual DbSet<T0170BloqueoDocumentos> T0170BloqueoDocumentos { get; set; }
        public virtual DbSet<T0035_CostRoll> T0035_CostRoll { get; set; }
        public virtual DbSet<T0034_CostRollHeader> T0034_CostRollHeader { get; set; }
        public virtual DbSet<T0037_CostRollExplosionL1> T0037_CostRollExplosionL1 { get; set; }
        public virtual DbSet<T0012_TIPO_MATERIAL> T0012_TIPO_MATERIAL { get; set; }
        public virtual DbSet<T0010_MATERIALES> T0010_MATERIALES { get; set; }
        public virtual DbSet<T0011_MATERIALES_AKA> T0011_MATERIALES_AKA { get; set; }
        public virtual DbSet<T0011_MaterialType> T0011_MaterialType { get; set; }
    
        public virtual ObjectResult<GetDataOrdenCompra_byOCNum_Result> GetDataOrdenCompra_byOCNum(Nullable<int> numeroOC)
        {
            var numeroOCParameter = numeroOC.HasValue ?
                new ObjectParameter("numeroOC", numeroOC) :
                new ObjectParameter("numeroOC", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDataOrdenCompra_byOCNum_Result>("GetDataOrdenCompra_byOCNum", numeroOCParameter);
        }
    
        public virtual ObjectResult<GetDataOrdenPago_byOpNum_Result> GetDataOrdenPago_byOpNum(Nullable<int> numeroOP)
        {
            var numeroOPParameter = numeroOP.HasValue ?
                new ObjectParameter("numeroOP", numeroOP) :
                new ObjectParameter("numeroOP", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDataOrdenPago_byOpNum_Result>("GetDataOrdenPago_byOpNum", numeroOPParameter);
        }
    
        public virtual ObjectResult<GetOrdenCompraDetails_Result> GetOrdenCompraDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOrdenCompraDetails_Result>("GetOrdenCompraDetails");
        }
    
        public virtual ObjectResult<GetOrdenFabricacionReportDataSource_Result> GetOrdenFabricacionReportDataSource(Nullable<int> numeroOrdenFabricacion)
        {
            var numeroOrdenFabricacionParameter = numeroOrdenFabricacion.HasValue ?
                new ObjectParameter("numeroOrdenFabricacion", numeroOrdenFabricacion) :
                new ObjectParameter("numeroOrdenFabricacion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOrdenFabricacionReportDataSource_Result>("GetOrdenFabricacionReportDataSource", numeroOrdenFabricacionParameter);
        }
    
        public virtual ObjectResult<GetStockDataSetCompleto_Result> GetStockDataSetCompleto()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStockDataSetCompleto_Result>("GetStockDataSetCompleto");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<uspGetStockDisponibleOFByMaterialPlant_Result> uspGetStockDisponibleOFByMaterialPlant(string material, string planta)
        {
            var materialParameter = material != null ?
                new ObjectParameter("material", material) :
                new ObjectParameter("material", typeof(string));
    
            var plantaParameter = planta != null ?
                new ObjectParameter("planta", planta) :
                new ObjectParameter("planta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetStockDisponibleOFByMaterialPlant_Result>("uspGetStockDisponibleOFByMaterialPlant", materialParameter, plantaParameter);
        }
    }
}