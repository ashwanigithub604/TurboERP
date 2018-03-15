using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class UnitMaster
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "UnitMast_Proc";
        public UnitMaster()
        {
            conn = db.OpenSqlCon();
            cmd = db.GetCommand(procName, conn);
        }

        //---------Insert Unit Details--------
        public string Unit_Insert(UnitMast unit)
        {
            string result = "";
            try
            {
                cmd.Parameters.Add("@UNIT", SqlDbType.VarChar, 3).Value = unit.UNIT;
                cmd.Parameters.Add("@DESC", SqlDbType.VarChar, 20).Value = unit.DESC;
                cmd.Parameters.Add("@DECI_REQ", SqlDbType.Bit).Value = unit.DECI_REQ;
                cmd.Parameters.AddWithValue("@Action ", "INST");
                conn.Open();
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    result = "Code is duplicate.";
                }
                return result;
            }
            finally
            {
                conn.Close();
            }
        }


        //---------Update Unit Details--------
        public string Unit_Update(UnitMast unit)
        {
            string result = "";
            try
            {
                conn.Open();
                cmd.Parameters.Add("@UNIT", SqlDbType.VarChar, 3).Value = unit.UNIT;
                cmd.Parameters.Add("@DESC", SqlDbType.VarChar, 20).Value = unit.DESC;
                cmd.Parameters.Add("@DECI_REQ", SqlDbType.Bit).Value = unit.DECI_REQ;
                cmd.Parameters.AddWithValue("@Pid", unit.PID);
                cmd.Parameters.AddWithValue("@Action", "UPDT");

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


        //---------Delete Unit Details--------
        public int Unit_Delete(int pid)
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


        //---------Get All Unit Details--------
        public DataTable Unit_GetAll()
        {
            DataTable dt = null;
            //List<UnitMast> unitList = null;
            try
            {
                cmd.Parameters.AddWithValue("@Action", "GRID");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //unitList = GetList.DataTableToList<UnitMast>(dt);

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


        //---------Get Unit Details--------
        public UnitMast Unit_GetById(int? pid)
        {
            DataTable dt = null;
            UnitMast unit = null;
            try
            {
                cmd.Parameters.AddWithValue("@Pid", pid);
                cmd.Parameters.AddWithValue("@Action", "SHOW");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                unit = GetList.DataTableToList<UnitMast>(dt).FirstOrDefault();

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



    }
}