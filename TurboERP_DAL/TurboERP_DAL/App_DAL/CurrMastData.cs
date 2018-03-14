using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurboERP_DAL.Models;
using System.Data;
using System.Data.SqlClient;

namespace TurboERP_DAL.App_DAL
{
    public class CurrMastData_Crud
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "CurrMast_Proc";
        public CurrMastData_Crud()
        {
            conn = db.OpenSqlCon();
            cmd = db.GetCommand(procName, conn);
        }

        //---------Get All CurrMast Details--------
        public DataTable CurrMast_GetAll()
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

        //---------Get CurrMast Details--------
        public DataTable CurrMast_GetById(int? PID)
        {
            DataTable dt = null;
            //CurrMast currMast = null;
            try
            {
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@Action", "SHOW");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
                //currMast = GetList.DataTableToList<CurrMast>(dt).FirstOrDefault();
                //return currMast;
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

        //---------Insert CurrMast Details--------
        public string CurrMast_Insert(CurrMast currMast)
        {
            string result = "";
            try
            {
                AddParameters(currMast);
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

        //---------Update CurrMast Details--------
        public string CurrMast_Update(CurrMast currMast)
        {
            string result = "";
            try
            {
                conn.Open();
                AddParameters(currMast);
                cmd.Parameters.AddWithValue("@PID", currMast.PID);
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

        //---------Delete CurrMast Details--------
        public int CurrMast_Delete(int PID)
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

        private void AddParameters(CurrMast currMast)
        {
            cmd.Parameters.AddWithValue("CURR_CODE", currMast.CURR_CODE);
            cmd.Parameters.AddWithValue("CURR_NAME", currMast.CURR_NAME);
            cmd.Parameters.AddWithValue("CURR_CAP", currMast.CURR_CAP);
            cmd.Parameters.AddWithValue("CURR_CONV", currMast.CURR_CONV);
            cmd.Parameters.AddWithValue("EXC_RATE", currMast.EXC_RATE);
            cmd.Parameters.AddWithValue("COIN", currMast.COIN);
            cmd.Parameters.AddWithValue("CURR_SEP", currMast.CURR_SEP);

        }

    }
}