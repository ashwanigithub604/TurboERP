using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class Couriercls
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "SalesCoProc";

        public Couriercls()
        {
            conn = db.OpenSqlCon();
            conn.Open();
            cmd = db.GetCommand(procName, conn);
        }
        //------Get Courier data In Grid-------
        public DataTable GetCourierGrid()
        {
            DataTable dt = null;
            try
            {
                cmd.Parameters.Add("@Action", SqlDbType.VarChar, 6).Value = "Grid";
                cmd.Parameters.Add("@Identifier", SqlDbType.VarChar, 10).Value = "Courier";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }
       
        //----Get Courier For Edit  --------
        public DataTable GetCourierById(int PId)
        {
            DataTable dt = null;
            try
            {
                cmd.Parameters.Add("@Action", SqlDbType.VarChar, 4).Value = "Edit";
                cmd.Parameters.Add("@Pid", SqlDbType.Int).Value = PId;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return dt;
            }
            finally
            {
                conn.Close();
            }

        }

        //----Save Courier  --------
        public int InsertCourier(MisPrty misParty)
        {
            int result = 0;
            try
            {
                AddParameters(misParty);
                cmd.Parameters.AddWithValue("@Action ", "INSERT");

                result = cmd.ExecuteNonQuery();
                return result;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return result;
            }
            finally
            {
                conn.Close();
            }
        }
        //---------Update Courier Details--------
        public int UpdateCourier(MisPrty misPrty)
        {
            int result = 0;
            try
            {

                AddParameters(misPrty);
                cmd.Parameters.AddWithValue("@Pid", misPrty.PID);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return result;
            }
            finally
            {
                conn.Close();
            }
        }
        //----Delete Courier  --------
        public int DeleteCourier(int PID)
        {
            int result = 0;
            try
            {
                cmd.Parameters.AddWithValue("@Pid", PID);
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                //conn.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return result;
            }
            finally
            {
                conn.Close();
            }
        }


        public void AddParameters(MisPrty misParty)
        {

            cmd.Parameters.Add("@CODE", SqlDbType.VarChar, 4).Value = misParty.CODE;
            cmd.Parameters.Add("@TYPE", SqlDbType.VarChar, 1).Value = misParty.TYPE;
            cmd.Parameters.Add("@NAME", SqlDbType.VarChar, 45).Value = misParty.NAME;
            cmd.Parameters.Add("@SHORT_NAME", SqlDbType.VarChar, 10).Value = misParty.SHORT_NAME;
            cmd.Parameters.Add("@ADD1", SqlDbType.VarChar, 45).Value = misParty.ADD1;
            cmd.Parameters.Add("@ADD2", SqlDbType.VarChar, 45).Value = misParty.ADD2;
            cmd.Parameters.Add("@ADD3", SqlDbType.VarChar, 45).Value = misParty.ADD3;
            cmd.Parameters.Add("@CONTPER", SqlDbType.VarChar, 45).Value = misParty.CONTPER;
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 35).Value = misParty.EMAIL;
            cmd.Parameters.Add("@WEB_ADD", SqlDbType.VarChar, 45).Value = misParty.WEB_ADD;
            cmd.Parameters.Add("@MOBILE", SqlDbType.VarChar, 30).Value = misParty.MOBILE;
            cmd.Parameters.Add("@PHONE", SqlDbType.VarChar, 30).Value = misParty.PHONE;
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar, 30).Value = misParty.FAX;
            if (misParty.RELA != null)
                cmd.Parameters.Add("@RELA", SqlDbType.DateTime).Value = Convert.ToDateTime(misParty.RELA);
            else
                cmd.Parameters.Add("@RELA", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@REMARKS", SqlDbType.VarChar).Value = misParty.REMARKS;
            cmd.Parameters.Add("@MISCTYPE", SqlDbType.VarChar, 1).Value = misParty.MISCTYPE;
        }
    }
}