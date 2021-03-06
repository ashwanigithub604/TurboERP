//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurboERP_DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemMaster
    {
        public int Pid { get; set; }
        public string GRP_CODE { get; set; }
        public string SGRP_CODE { get; set; }
        public string ITEM_CODE { get; set; }
        public string SAMP_CODE { get; set; }
        public string FINCODE { get; set; }
        public string ITEM_NAME1 { get; set; }
        public string ITEM_NAME2 { get; set; }
        public string ITEM_NAME3 { get; set; }
        public string ITEM_NAME4 { get; set; }
        public Nullable<decimal> OPEN_QTY { get; set; }
        public Nullable<decimal> CLOS_QTY { get; set; }
        public Nullable<decimal> YTOD_RECT { get; set; }
        public Nullable<decimal> YTOD_ISSUE { get; set; }
        public string EAN_NO { get; set; }
        public string SIZE_CODE { get; set; }
        public string UNIT { get; set; }
        public Nullable<decimal> NET_WT { get; set; }
        public Nullable<decimal> INCRNET_WT { get; set; }
        public Nullable<decimal> MCNET_WT { get; set; }
        public Nullable<decimal> CFT { get; set; }
        public string CP_CODE { get; set; }
        public Nullable<decimal> RATE { get; set; }
        public Nullable<decimal> SELL_PRICE { get; set; }
        public Nullable<decimal> FOB { get; set; }
        public Nullable<decimal> MRGN_PER { get; set; }
        public Nullable<decimal> MIN_QTY { get; set; }
        public Nullable<decimal> ITM_LENGTH { get; set; }
        public Nullable<decimal> ITM_BRDTH { get; set; }
        public Nullable<decimal> ITM_HEIGHT { get; set; }
        public Nullable<decimal> IN_CRTNLEN { get; set; }
        public Nullable<decimal> IN_CRTNBRD { get; set; }
        public Nullable<decimal> IN_CRTNHT { get; set; }
        public Nullable<decimal> IN_CRTNPCS { get; set; }
        public Nullable<decimal> TOTINCRTN { get; set; }
        public Nullable<decimal> CRTNLENGTH { get; set; }
        public Nullable<decimal> CRTNBRDTH { get; set; }
        public Nullable<decimal> CRTNHEIGHT { get; set; }
        public Nullable<decimal> CRTN_CBM { get; set; }
        public Nullable<decimal> INRCRT_CBM { get; set; }
        public Nullable<decimal> PRCRTN_QTY { get; set; }
        public string PICT_PATH { get; set; }
        public Nullable<bool> INCH_CMS { get; set; }
        public Nullable<bool> ITM_BRKUP { get; set; }
        public Nullable<System.DateTime> ENTRY_DT { get; set; }
        public Nullable<decimal> SHP_TYP { get; set; }
        public string CURR { get; set; }
        public Nullable<decimal> EXC_RATE { get; set; }
        public string TYPE { get; set; }
        public string ADD_BY { get; set; }
        public string EDIT_BY { get; set; }
        public Nullable<decimal> CONT20QTY { get; set; }
        public Nullable<decimal> CONT40QTY { get; set; }
        public Nullable<decimal> CONT40HQTY { get; set; }
        public Nullable<decimal> CBM20FT { get; set; }
        public Nullable<decimal> CBM40FT { get; set; }
        public Nullable<decimal> CBM40HQ { get; set; }
        public Nullable<System.DateTime> EDIT_DT { get; set; }
        public Nullable<System.DateTime> COSTDATE { get; set; }
        public Nullable<decimal> FACTEXPAMT { get; set; }
        public Nullable<decimal> FACT_PER { get; set; }
        public Nullable<decimal> OVRHD_VAL { get; set; }
        public Nullable<decimal> REORD_LVL { get; set; }
        public Nullable<decimal> MIN_LVL { get; set; }
        public Nullable<decimal> MAX_LVL { get; set; }
        public Nullable<System.DateTime> CREATE_DT { get; set; }
        public Nullable<decimal> VOL_WT { get; set; }
        public string CAT_CODE { get; set; }
        public Nullable<decimal> ENDOP_QTY { get; set; }
        public Nullable<decimal> ENDCL_QTY { get; set; }
        public Nullable<decimal> COST_RATE { get; set; }
        public Nullable<System.DateTime> ITEM_DATE { get; set; }
        public Nullable<decimal> INCRT_CBM { get; set; }
        public Nullable<System.DateTime> COST_DATE { get; set; }
        public Nullable<decimal> ENDYTDRCT { get; set; }
        public Nullable<decimal> ENDYTDISS { get; set; }
        public Nullable<decimal> PERMTRQTY { get; set; }
        public Nullable<bool> TREAT_SET { get; set; }
        public Nullable<decimal> CONT45HQTY { get; set; }
        public Nullable<decimal> QTY_RCVD { get; set; }
        public Nullable<decimal> QTY_ISSUED { get; set; }
        public Nullable<bool> AUTOSIZECD { get; set; }
        public string REFPHOTO { get; set; }
        public Nullable<decimal> ALLOC_QTY { get; set; }
        public Nullable<bool> ASSORTITM { get; set; }
        public Nullable<bool> GST_CAT { get; set; }
        public string GSTHSNSAC { get; set; }
        public Nullable<decimal> GST_DTAX { get; set; }
        public Nullable<bool> ALLOWSTOCK { get; set; }
    
        public virtual CPMaster CPMaster { get; set; }
        public virtual CurrMast CurrMast { get; set; }
        public virtual ItemGrp ItemGrp { get; set; }
        public virtual ItmCat ItmCat { get; set; }
        public virtual ItemSgrp ItemSgrp { get; set; }
        public virtual UnitMast UnitMast { get; set; }
    }
}
