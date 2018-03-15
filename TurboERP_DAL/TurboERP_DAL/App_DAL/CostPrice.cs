using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class CostPrice
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "CPMaster_Proc";
        public CostPrice()
        {
            conn = db.OpenSqlCon();
            cmd = db.GetCommand(procName, conn);
        }

        //---------Insert CostPrice Details--------
        public string CostPrice_Insert(CPMaster costPrice)
        {
            string result = "";
            try
            {
                cmd.Parameters.Add("@CP_CODE", SqlDbType.VarChar, 1).Value = costPrice.CP_CODE;
                cmd.Parameters.Add("@RATE", SqlDbType.VarChar, 1).Value = costPrice.RATE;
                cmd.Parameters.AddWithValue("@Action ", "INST");
                conn.Open();
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    result = "Either Code or Value is duplicate.";
                }
         
                return result ;
            }
            finally
            {
                conn.Close();
            }

        }


        //---------Update CostPrice Details--------
        public string CostPrice_Update(CPMaster costPrice)
        {
            string result = "";
            try
            {
                conn.Open();
                cmd.Parameters.Add("@RATE", SqlDbType.VarChar, 1).Value = costPrice.RATE;
                cmd.Parameters.AddWithValue("@Pid", costPrice.PID);
                cmd.Parameters.AddWithValue("@Action", "UPDT");

                int res = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    result = "Value is duplicate.";
                }
                return result;
            }
            finally
            {
                conn.Close();
            }
        }


        //---------Delete CostPrice Details--------
        public int CostPrice_Delete(int pid)
        {
            int result;
            try
            {
                cmd.Parameters.AddWithValue("@Pid", pid);
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


        //---------Get All CostPrice Details--------
        public DataTable CostPrice_GetAll()
        {
            DataTable dt = null;
           // List<CPMaster> costPriceList = null;
            try
            {
                cmd.Parameters.AddWithValue("@Action", "GRID");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
               // costPriceList = GetList.DataTableToList<CPMaster>(dt);
               
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


        //---------Get CostPrice Details--------
        public CPMaster CostPrice_GetById(int? pid)
        {
            DataTable dt = null;
            CPMaster costPrice = null;
            try
            {
                cmd.Parameters.AddWithValue("@Pid", pid);
                cmd.Parameters.AddWithValue("@Action", "SHOW");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                costPrice = GetList.DataTableToList<CPMaster>(dt).FirstOrDefault();

                return costPrice;
            }
            catch
            {
                return costPrice;
            }
            finally
            {
                conn.Close();
            }
        }

        

    }
}