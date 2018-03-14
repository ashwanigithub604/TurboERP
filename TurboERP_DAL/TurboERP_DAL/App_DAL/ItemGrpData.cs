using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class ItemGrpData_Crud
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "ItemGrp_Proc";
        public ItemGrpData_Crud()
        {
            conn = db.OpenSqlCon();
            cmd = db.GetCommand(procName, conn);
        }

        //---------Get All ItemGrp Details--------
        public DataTable ItemGrp_GetAll()
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

        //---------Get ItemGrp Details--------
        public DataTable ItemGrp_GetById(int? PID)
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
            catch (Exception ex)
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }

        //---------Insert ItemGrp Details--------
        public string ItemGrp_Insert(ItemGrp itemGrp)
        {
            string result = "";
            try
            {
                AddParameters(itemGrp);
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

        //---------Update ItemGrp Details--------
        public string ItemGrp_Update(ItemGrp itemGrp)
        {
            string result = "";
            try
            {
                conn.Open();
                AddParameters(itemGrp);
                cmd.Parameters.AddWithValue("@PID", itemGrp.PID);
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

        //---------Delete ItemGrp Details--------
        public int ItemGrp_Delete(int PID)
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

        private void AddParameters(ItemGrp itemGrp)
        {
            cmd.Parameters.AddWithValue("GRP_CODE", itemGrp.GRP_CODE);
            cmd.Parameters.AddWithValue("GRP_NAME", itemGrp.GRP_NAME);
            cmd.Parameters.AddWithValue("GRP_PREFIX", itemGrp.GRP_PREFIX);
            cmd.Parameters.AddWithValue("PICT_PATH", itemGrp.PICT_PATH);

        }
    }
}