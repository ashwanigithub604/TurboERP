using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TurboERP_DAL.App_DAL
{
    public class Pubcls
    {
        SqlConnection SQLConn;
        public SqlConnection OpenSqlCon()
        {
            try
            {
                // In case of SQL Connection
                String dsn = "server=" + ConfigurationManager.AppSettings["SrvName"].ToString() + ";uid=" + ConfigurationManager.AppSettings["dbUid"].ToString() + ";pwd=" + ConfigurationManager.AppSettings["dbPwd"].ToString() + ";database=" + ConfigurationManager.AppSettings["dbName"].ToString();
                SQLConn = new SqlConnection(dsn);
                //opening the connection
                                 // End of SQL Connection Initialization
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return SQLConn;
        }

        public SqlCommand GetCommand(string procName, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(procName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        public void executequery(string query)
        {
            SQLConn = new SqlConnection();
            SQLConn = OpenSqlCon();
            SqlCommand cmd = new SqlCommand(query, SQLConn);
            cmd.ExecuteNonQuery();
            SQLConn.Close();
        }

        public DataTable Getdatatable(string sql)
        {
            SqlConnection sqlConnection = OpenSqlCon();
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataTable;
        }
        public DataTable getUserRights(string modecode, string Usercode)
        {
            SqlConnection sqlConnection = OpenSqlCon();
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("UserRightsProc", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserCode", SqlDbType.VarChar, 10).Value = "A000000".ToString().Trim();
            cmd.Parameters.Add("@ModeCode", SqlDbType.VarChar, 20).Value = modecode.ToString().Trim();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataTable;
        }
    }
}