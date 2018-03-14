using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class Country_Crud
    {
        Pubcls mycls = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "CountryMastProc";
        public Country_Crud()
        {
            conn = mycls.OpenSqlCon();
            cmd = mycls.GetCommand(procName, conn);
        }

        private void AddParameters(Country country)
        {
            cmd.Parameters.Add("@Country_Code", SqlDbType.VarChar, 4).Value = country.COUN_CODE;
            cmd.Parameters.Add("@Country_Name", SqlDbType.VarChar, 30).Value = country.COUN_NAME;
            cmd.Parameters.Add("@Continental_Code", SqlDbType.VarChar, 4).Value = country.CONT_CODE;
            cmd.Parameters.Add("@Input_By", SqlDbType.VarChar, 3).Value = "";
            cmd.Parameters.Add("@Edit_By", SqlDbType.VarChar, 3).Value = "";
        }

        //--------- Insert Country --------
        public string Country_Insert(Country country)
        {
            string result = string.Empty;
            try
            {
                conn.Open();
                AddParameters(country);
                cmd.Parameters.AddWithValue("@Action ", "INST");                
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


        //--------- Update Country --------
        public string Country_Update(Country country)
        {
            string result = string.Empty;
            try
            {
                conn.Open();
                AddParameters(country);
                cmd.Parameters.AddWithValue("@Pid", country.PID);
                cmd.Parameters.AddWithValue("@Action", "UPDT");
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch (Exception ex)
            {
                return result = string.Empty;
            }
            finally
            {
                conn.Close();
            }
        }


        //--------- Delete Country --------
        public string Country_Delete(int pid)
        {
            string result;
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Pid", pid);
                cmd.Parameters.AddWithValue("@Action", "DELT");
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch (Exception ex)
            {
                return result = string.Empty;
            }
            finally
            {
                conn.Close();
            }
        }


        //---------Get All Country Details--------
        public DataTable Country_GetAll()
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


        //---------Get Country--------
        public Country Country_GetById(int? id)
        {
            DataTable dt = null;
            Country country = null;
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Pid", id);
                cmd.Parameters.AddWithValue("@Action", "SHOW");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                country = GetList.DataTableToList<Country>(dt).FirstOrDefault();
                return country;
            }
            catch
            {
                return country;
            }
            finally
            {
                conn.Close();
            }
        }


        //------------- Get Continental Code-------------
        public DataTable ContinentalCode()
        {
            DataTable dt = null;
            try
            {
                conn.Open();
                cmd = mycls.GetCommand("ContinentalCode", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
    }
}