using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TurboERP_DAL.App_DAL;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CartonPlyApiController : ApiController
    {

        [HttpPost]
        //[Route("CartonPly")]
        public HttpResponseMessage PostCartonPly(CartPly cartPly)
        {
            SqlConnection con = new Pubcls().OpenSqlCon();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CartPlyProc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
               
               // SqlParameter parm = new SqlParameter("@isExist", SqlDbType.VarChar);
              //  parm.Direction = ParameterDirection.ReturnValue;
              //  cmd.Parameters.Add(parm);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 6).Value = "Insert";
                cmd.Parameters.Add("@CRTN_PLY", SqlDbType.Int).Value = cartPly.CRTN_PLY;
                cmd.Parameters.Add("@BOARDWIDTH", SqlDbType.Decimal).Value = cartPly.BOARDWIDTH;
                cmd.Parameters.Add("@RATEBROWN", SqlDbType.Decimal).Value = cartPly.RATEBROWN;
                cmd.Parameters.Add("@RATECOLOR", SqlDbType.Decimal).Value = cartPly.RATECOLOR;
              //  int result = cmd.ExecuteNonQuery();
                object value = cmd.ExecuteScalar();
                if (value.ToString() == "S")
                {
                   return Request.CreateResponse(HttpStatusCode.OK,value);
                }
                if (value.ToString() == "D")
                {
                    //string dd = "dup";
                    return Request.CreateResponse(HttpStatusCode.OK,value);
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            }
            finally
            {
                con.Close();
            }
            return new HttpResponseMessage(HttpStatusCode.BadGateway);
        }

        [HttpGet]
        [Route("CartonPly")]
        public HttpResponseMessage GetCartPly()
        {
            DataTable cartPlyDt = new DataTable();
            SqlConnection con = new Pubcls().OpenSqlCon();
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("CartPlyProc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 6).Value = "Grid";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(cartPlyDt);
                if (cartPlyDt.Rows.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cartPlyDt);

                }
                else { return Request.CreateResponse(HttpStatusCode.BadRequest); }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                con.Close();
            }
        }

        [HttpPut]
        //[Route("api/CartPlyApi/PutCartonPly/")]
        public HttpResponseMessage PutCartonPly(CartPly cartPly)
        {
            SqlConnection con = new Pubcls().OpenSqlCon();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CartPlyProc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 6).Value = "Update";
                cmd.Parameters.Add("@PID", SqlDbType.Int).Value = cartPly.PID;
                cmd.Parameters.Add("@CRTN_PLY", SqlDbType.Int).Value = cartPly.CRTN_PLY;
                cmd.Parameters.Add("@BOARDWIDTH", SqlDbType.Decimal).Value = cartPly.BOARDWIDTH;
                cmd.Parameters.Add("@RATEBROWN", SqlDbType.Decimal).Value = cartPly.RATEBROWN;
                cmd.Parameters.Add("@RATECOLOR", SqlDbType.Decimal).Value = cartPly.RATECOLOR;
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            finally
            {
                con.Close();
            }
        }



        [HttpDelete]
        public HttpResponseMessage DeleteCartonPly(int Pid)
        {

            SqlConnection con = new Pubcls().OpenSqlCon();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CartPlyProc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 6).Value = "Delete";
                cmd.Parameters.Add("@Pid", SqlDbType.Int).Value = Pid;
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                con.Close();
            }

        }
       
        [HttpGet]
        //[Route("api/CartPlyApi/EditCartPly/")]
        public HttpResponseMessage EditCartPly(int PID)
        {

            SqlConnection con = new Pubcls().OpenSqlCon();
            con.Open();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("CartPlyProc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 6).Value = "Edit";
                cmd.Parameters.Add("@Pid", SqlDbType.Int).Value = PID;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return Request.CreateResponse(HttpStatusCode.OK, dt);

            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                con.Close();
            }
        }
    
    }
}
