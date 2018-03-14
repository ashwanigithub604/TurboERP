using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class WareHouse
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "Warehousemast_Proc";
        public WareHouse()
        {
            conn = db.OpenSqlCon();
            cmd = db.GetCommand(procName, conn);
        }

        //---------Insert Unit Details--------
        public string WareHouse_Insert(Warehousemast WareHouse)
        {
            string result = "";
            try
            {
                cmd.Parameters.Add("@COMPANY_PID", SqlDbType.Int).Value = WareHouse.COMPANY_PID;
                cmd.Parameters.Add("@WAREHOUSE_NAME", SqlDbType.VarChar, 20).Value = WareHouse.WAREHOUSE_NAME;
                cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = WareHouse.ADDRESS;
                cmd.Parameters.Add("@Input_BY", SqlDbType.VarChar).Value = WareHouse.ADD_BY;
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


        //---------Update Unit Details--------
        public string WareHouse_Update(Warehousemast WareHouse)
        {
            string result = "";
            try
            {
                cmd.Parameters.Add("@PID", SqlDbType.VarChar, 3).Value = WareHouse.PID;
                cmd.Parameters.Add("@COMPANY_PID", SqlDbType.VarChar, 3).Value = WareHouse.COMPANY_PID;
                cmd.Parameters.Add("@WAREHOUSE_NAME", SqlDbType.VarChar, 20).Value = WareHouse.WAREHOUSE_NAME;
                cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar,30).Value = WareHouse.ADDRESS;
                cmd.Parameters.Add("@EDIT_BY", SqlDbType.VarChar,10).Value = WareHouse.EDIT_BY;
                cmd.Parameters.AddWithValue("@Action ", "UPDT");
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


        //---------Delete Unit Details--------
        public int WareHouse_Delete(int pid)
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
        public DataTable WareHouse_GetAll()
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
        public Warehousemast WareHouse_GetById(int? pid)
        {
            DataTable dt = null;
            Warehousemast WareHouse = null;
            try
            {
                cmd.Parameters.AddWithValue("@Pid", pid);
                cmd.Parameters.AddWithValue("@Action", "SHOW");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                WareHouse = GetList.DataTableToList<Warehousemast>(dt).FirstOrDefault();

                return WareHouse;
            }
            catch
            {
                return WareHouse;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable GetComp()
        {
            DataTable dt = null;
            try
            {
                cmd.Parameters.AddWithValue("@Action", "GET");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }



    }

}