using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class SkuMastData_Crud
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "SkuMast_Proc";
        public SkuMastData_Crud()
        {
            conn = db.OpenSqlCon();
            cmd = db.GetCommand(procName, conn);
        }

        //---------Get All SkuMast Details--------
        public DataTable SkuMast_GetAll()
        {
            DataTable dt = null;
            try
            {
                cmd.Parameters.AddWithValue("@Action", "GRID");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }

        //---------Get SkuMast Details--------
        public DataTable SkuMast_GetById(int? PID)
        {
            DataTable dt = null;
            try
            {
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@Action", "SHOW");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                
                return dt;
            }
            catch(Exception ex)
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }

        //---------Insert SkuMast Details--------
        public string SkuMast_Insert(SkuMast skuMast)
        {
            string result = "";
            try
            {
                AddParameters(skuMast);
                cmd.Parameters.AddWithValue("@Action ", "INST");
                conn.Open();
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch (Exception ex)
            {
                return result = "";
            }
            finally
            {
                conn.Close();
            }
        }

        //---------Update SkuMast Details--------
        public string SkuMast_Update(SkuMast skuMast)
        {
            string result = "";
            try
            {
                conn.Open();
                AddParameters(skuMast);
                cmd.Parameters.AddWithValue("@PID", skuMast.PID);
                cmd.Parameters.AddWithValue("@Action", "UPDT");

                int res = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return result = "";


            }
            finally
            {
                conn.Close();
            }
        }

        //---------Delete Buyer Details--------
        public int SkuMast_Delete(int PID)
        {
            int result;
            try
            {
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@Action", "DELT");
                conn.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return result = 0;
            }
            finally
            {
                conn.Close();
            }
        }

        private void AddParameters(SkuMast skuMast)
        {
            cmd.Parameters.AddWithValue("BUY_VND", skuMast.BUY_VND);
            cmd.Parameters.AddWithValue("ITEM_CODE", skuMast.ITEM_CODE);
            cmd.Parameters.AddWithValue("BUYER_CODE", skuMast.BUYER_CODE);
            cmd.Parameters.AddWithValue("SKU_NO", skuMast.SKU_NO);
            cmd.Parameters.AddWithValue("ITCHSTMP", skuMast.ITCHSTMP);
            cmd.Parameters.AddWithValue("ITEM_NAME1", skuMast.ITEM_NAME1);
            cmd.Parameters.AddWithValue("ITEM_NAME2", skuMast.ITEM_NAME2);
            cmd.Parameters.AddWithValue("ITEM_NAME3", skuMast.ITEM_NAME3);
            cmd.Parameters.AddWithValue("ITEM_NAME4", skuMast.ITEM_NAME4);
            cmd.Parameters.AddWithValue("CNFTYP", skuMast.CNFTYP);
            cmd.Parameters.AddWithValue("CURR", skuMast.CURR);
            cmd.Parameters.AddWithValue("RATE", skuMast.RATE);
            cmd.Parameters.AddWithValue("FOB", skuMast.FOB);
            cmd.Parameters.AddWithValue("EXC_RATE", skuMast.EXC_RATE);
            cmd.Parameters.AddWithValue("SALE_RATE", skuMast.SALE_RATE);
            cmd.Parameters.AddWithValue("SALE_CURR", skuMast.SALE_CURR);
            cmd.Parameters.AddWithValue("SALE_DATE", skuMast.SALE_DATE);
            cmd.Parameters.AddWithValue("INCH_CMS", skuMast.INCH_CMS);
            cmd.Parameters.AddWithValue("UNIT", skuMast.UNIT);
            cmd.Parameters.AddWithValue("ITM_LENGTH", skuMast.ITM_LENGTH);
            cmd.Parameters.AddWithValue("ITM_BRDTH", skuMast.ITM_BRDTH);
            cmd.Parameters.AddWithValue("ITM_HEIGHT", skuMast.ITM_HEIGHT);
            cmd.Parameters.AddWithValue("NET_WT", skuMast.NET_WT);
            cmd.Parameters.AddWithValue("EAN_NO", skuMast.EAN_NO);
            cmd.Parameters.AddWithValue("IN_CRTNPCS", skuMast.IN_CRTNPCS);
            cmd.Parameters.AddWithValue("IN_CRTNLEN", skuMast.IN_CRTNLEN);
            cmd.Parameters.AddWithValue("IN_CRTNBRD", skuMast.IN_CRTNBRD);
            cmd.Parameters.AddWithValue("IN_CRTNHT", skuMast.IN_CRTNHT);
            cmd.Parameters.AddWithValue("INCRNET_WT", skuMast.INCRNET_WT);
            cmd.Parameters.AddWithValue("INRCRT_CBM", skuMast.INRCRT_CBM);
            cmd.Parameters.AddWithValue("IEAN_NO", skuMast.IEAN_NO);
            cmd.Parameters.AddWithValue("PRCRTN_QTY", skuMast.PRCRTN_QTY);
            cmd.Parameters.AddWithValue("CRTNLENGTH", skuMast.CRTNLENGTH);
            cmd.Parameters.AddWithValue("CRTNBRDTH", skuMast.CRTNBRDTH);
            cmd.Parameters.AddWithValue("CRTNHEIGHT", skuMast.CRTNHEIGHT);
            cmd.Parameters.AddWithValue("CRTN_CBM", skuMast.CRTN_CBM);
            cmd.Parameters.AddWithValue("MCNET_WT", skuMast.MCNET_WT);
            cmd.Parameters.AddWithValue("MCGROSWT", skuMast.MCGROSWT);
            cmd.Parameters.AddWithValue("MEAN_NO", skuMast.MEAN_NO);
            cmd.Parameters.AddWithValue("SIZE_CODE", skuMast.SIZE_CODE);
            cmd.Parameters.AddWithValue("FINCODE", skuMast.FINCODE);
            cmd.Parameters.AddWithValue("TARRIF", skuMast.TARRIF);
            cmd.Parameters.AddWithValue("PACK_INS", skuMast.PACK_INS);
            cmd.Parameters.AddWithValue("LBL_INS", skuMast.LBL_INS);
            cmd.Parameters.AddWithValue("OTH_INS", skuMast.OTH_INS);
            cmd.Parameters.AddWithValue("VND_DTL1", skuMast.VND_DTL1);
            cmd.Parameters.AddWithValue("VND_DTL2", skuMast.VND_DTL2);
            cmd.Parameters.AddWithValue("REMARKS", skuMast.REMARKS);
            cmd.Parameters.AddWithValue("ITMLBLPATH", skuMast.ITMLBLPATH);
            cmd.Parameters.AddWithValue("CASLBLPATH", skuMast.CASLBLPATH);
            cmd.Parameters.AddWithValue("BRNLBLPATH", skuMast.BRNLBLPATH);

        }

    }
}