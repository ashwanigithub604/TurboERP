using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class VehCats
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "VehiCat_Proc";
        public VehCats()
        {
            conn = db.OpenSqlCon();
            cmd = db.GetCommand(procName, conn);
        }
        //---------Get All VehiCat Details--------
        public DataTable VehCat_GetAll()
        {
            DataTable dt = null;
            try
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");
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

        //---------Get VehCat Details--------
        public VehiCat VehCat_GetById(int? pid)
        {
            DataTable dt = null;
            VehiCat unit = null;
            try
            {
                cmd.Parameters.AddWithValue("@Pid", pid);
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                unit = GetList.DataTableToList<VehiCat>(dt).FirstOrDefault();

                return unit;
            }
            catch
            {
                return unit;
            }
            finally
            {
                conn.Close();
            }
        }

        //---------Insert VehCat Details--------
        public string VehCat_Insert(VehiCat vehCat)
        {
            string result = "";
            try
            {
                cmd.Parameters.Add("@NAME", SqlDbType.VarChar, 50).Value = vehCat.NAME;
                cmd.Parameters.Add("@VPREFIX", SqlDbType.VarChar, 2).Value = vehCat.VPREFIX;
                cmd.Parameters.Add("@START_NO", SqlDbType.Int).Value = vehCat.START_NO;
                cmd.Parameters.AddWithValue("@Action ", "INSERT");
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


        //---------Update VehCat Details--------
        public string VehCat_Update(VehiCat vehCat)
        {
            string result = "";
            try
            {
                conn.Open();
                cmd.Parameters.Add("@NAME", SqlDbType.VarChar, 50).Value = vehCat.NAME;
                cmd.Parameters.Add("@VPREFIX", SqlDbType.VarChar, 2).Value = vehCat.VPREFIX;
                cmd.Parameters.Add("@START_NO", SqlDbType.Int).Value = vehCat.START_NO;
                cmd.Parameters.AddWithValue("@Pid", vehCat.PID);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");

                int res = cmd.ExecuteNonQuery();
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

        //---------Delete Unit Details--------
        public int VehCat_Delete(int pid)
        {
            int result;
            try
            {
                cmd.Parameters.AddWithValue("@Pid", pid);
                cmd.Parameters.AddWithValue("@Action", "DELETE");
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
    }
}