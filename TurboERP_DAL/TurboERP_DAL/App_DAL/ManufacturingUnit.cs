using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class ManufacturingUnit_CRUD
    {
        Pubcls mycls = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = new SqlCommand();
        string Procname = "ManufacturingMastProc";
        public ManufacturingUnit_CRUD()
        {
            conn = mycls.OpenSqlCon();
            cmd = mycls.GetCommand(Procname,conn);
        }

        private void AddParameters(ManUnit ManufacturingUnit)
        {
            cmd.Parameters.Add("@CompanyUnit", SqlDbType.VarChar, 10).Value = ManufacturingUnit.COMPANYUNIT;
            cmd.Parameters.Add("@Manufact_Name", SqlDbType.VarChar, 25).Value = ManufacturingUnit.MANF_NAME;
            cmd.Parameters.Add("@INPUT_BY", SqlDbType.VarChar, 3).Value = ManufacturingUnit.INPUT_BY;
            cmd.Parameters.Add("@EDIT_BY", SqlDbType.VarChar, 3).Value = ManufacturingUnit.EDIT_BY;
        }

        //--------- Insert Manufacturing Unit --------
        public string ManufacturingUnit_Insert(ManUnit ManufacturingUnit)
        {
            string result = string.Empty;
            try
            {
                conn.Open();
                AddParameters(ManufacturingUnit);
                cmd.Parameters.AddWithValue("@Action", "INST");
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch(Exception ex)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }
        }

        //--------- Update Manufacturing Unit --------
        public string ManufacturingUnit_Update(ManUnit ManufacturingUnit)
        {
            string result = string.Empty;
            try
            {
                conn.Open();
                AddParameters(ManufacturingUnit);
                cmd.Parameters.AddWithValue("@Pid", ManufacturingUnit.PID);
                cmd.Parameters.AddWithValue("@Action", "UPDT");
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch(Exception ex)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }
        }

        //--------- Delete Manufacturing Unit --------
        public string ManufacturingUnit_Delete(int Pid)
        {
            string result = string.Empty;
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Pid", Pid);
                cmd.Parameters.AddWithValue("@Action", "DELT");
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch(Exception ex)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }
        }

        //---------Get All Manufacturing Unit Details--------
        public DataTable ManufacturingUnit_GetAll()
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


        //---------Get Manufacturing Unit--------
        public ManUnit ManufacturingUnit_GetById(int? id)
        {
            DataTable dt = null;
            ManUnit ManufacturingUnit = null;
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Pid", id);
                cmd.Parameters.AddWithValue("@Action", "SHOW");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                ManufacturingUnit = GetList.DataTableToList<ManUnit>(dt).FirstOrDefault();
                return ManufacturingUnit;
            }
            catch
            {
                return ManufacturingUnit;
            }
            finally
            {
                conn.Close();
            }
        }


    }
}