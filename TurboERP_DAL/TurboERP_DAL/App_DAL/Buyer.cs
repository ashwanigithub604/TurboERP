using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TurboERP_DAL.Models;

namespace TurboERP_DAL.App_DAL
{
    public class Buyer_Crud
    {
        Pubcls db = new Pubcls();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string procName = "Buyer_Proc";
        public Buyer_Crud()
        {
            conn = db.OpenSqlCon();
            cmd = db.GetCommand(procName, conn);
        }

        //---------Insert Buyer Details--------
        public string Buyer_Insert(Buyer buyer)
        {
            string result = "";
            try
            {
                AddParameters(buyer);
                cmd.Parameters.AddWithValue("@Action ", "INSERT");
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


        //---------Update Buyer Details--------
        public string Buyer_Update(Buyer buyer)
        {
            string result = "";
            try
            {
                conn.Open();
                AddParameters(buyer);
                cmd.Parameters.AddWithValue("@Pid", buyer.Pid);
                cmd.Parameters.AddWithValue("@Action", "UPDATE");

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


        //---------Delete Buyer Details--------
        public int Buyer_Delete(int pid)
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
            catch(Exception ex)
            {
                return result = 0;
            }
            finally
            {
                conn.Close();
            }
        }


        //---------Get All Buyers Details--------
        public DataTable Buyer_GetAll()
        {
            DataTable dt = null;
            //List<Buyer> buyerList = null;
            try
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //buyerList = GetList.DataTableToList<Buyer>(dt);
                //buyerList = new List<Buyer>();
                //buyerList = BindDetails(dt);
                return dt;
            }
            catch(Exception ex)
            {
                return dt;
            }
            finally
            {
                conn.Close();
            }
        }


        //---------Get Buyer Details--------
        public Buyer Buyer_GetById(int? id)
        {
            DataTable dt = null;
            Buyer buyer = null;
            try
            {
                cmd.Parameters.AddWithValue("@Pid", id);
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                buyer  = GetList.DataTableToList<Buyer>(dt).FirstOrDefault();
               
                return buyer;
            }
            catch
            {
                return buyer;
            }
            finally
            {
                conn.Close();
            }
        }

        private void AddParameters(Buyer buyer)
        {
            //cmd.Parameters.Add("@SHORT_ID",SqlDbType.VarChar,10).Value= buyer.SHORT_ID;
            cmd.Parameters.Add("@BUYER_CODE", SqlDbType.VarChar, 4).Value = buyer.BUYER_CODE;
            cmd.Parameters.Add("@TALLYID", SqlDbType.VarChar, 10).Value = buyer.TALLYID;
            cmd.Parameters.Add("@BUYER_NAME", SqlDbType.VarChar, 45).Value = buyer.BUYER_NAME;
            cmd.Parameters.Add("@SHORT_NAME", SqlDbType.VarChar, 10).Value = buyer.SHORT_NAME;
            cmd.Parameters.Add("@ADD1", SqlDbType.VarChar, 45).Value = buyer.ADD1;
            cmd.Parameters.Add("@ADD2", SqlDbType.VarChar, 46).Value = buyer.ADD2;
            cmd.Parameters.Add("@ADD3", SqlDbType.VarChar, 45).Value = buyer.ADD3;
            cmd.Parameters.Add("@ADD4", SqlDbType.VarChar, 45).Value = buyer.ADD4;
            cmd.Parameters.Add("@ADD5", SqlDbType.VarChar, 10).Value = buyer.ADD5;
            cmd.Parameters.Add("@COUN_CODE", SqlDbType.VarChar, 4).Value = buyer.COUN_CODE;
            //cmd.Parameters.Add("@CONT_CODE", SqlDbType.VarChar, 4).Value = buyer.CONT_CODE;
            cmd.Parameters.Add("@CURR_CODE", SqlDbType.VarChar, 4).Value = buyer.CURR_CODE;
            cmd.Parameters.Add("@BANK_ADD1", SqlDbType.VarChar, 45).Value = buyer.BANK_ADD1;
            cmd.Parameters.Add("@BANK_ADD2", SqlDbType.VarChar, 45).Value = buyer.BANK_ADD2;
            cmd.Parameters.Add("@BANK_ADD3", SqlDbType.VarChar, 45).Value = buyer.BANK_ADD3;
            cmd.Parameters.Add("@BANK_ADD4", SqlDbType.VarChar, 45).Value = buyer.BANK_ADD4;
            cmd.Parameters.Add("@PORT_DISC", SqlDbType.VarChar, 25).Value = buyer.PORT_DISC;
            cmd.Parameters.Add("@FIN_DEST", SqlDbType.VarChar, 25).Value = buyer.FIN_DEST;
            cmd.Parameters.Add("@NOTIFY1", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@NOTIFY2", SqlDbType.VarChar, 45).Value = buyer.NOTIFY2;
            cmd.Parameters.Add("@NOTIFY3", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@NOTIFY4", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@NOTIFY5", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@NOTIFY6", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@NOTIFY7", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@NOTIFY8", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@NOTIFY9", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@NOTIFY10", SqlDbType.VarChar, 45).Value = buyer.NOTIFY1;
            cmd.Parameters.Add("@PHONE", SqlDbType.VarChar, 30).Value = buyer.PHONE;
            cmd.Parameters.Add("@MOBILE", SqlDbType.VarChar, 30).Value = buyer.MOBILE;
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 60).Value = buyer.EMAIL;
            //cmd.Parameters.Add("@TELEX", SqlDbType.VarChar, 20).Value = buyer.TELEX;
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar, 30).Value = buyer.FAX;
            cmd.Parameters.Add("@AGNT_CODE", SqlDbType.VarChar, 4).Value = buyer.AGNT_CODE;
            cmd.Parameters.Add("@TYPE", SqlDbType.VarChar, 1).Value = buyer.TYPE;
            cmd.Parameters.Add("@CMSN", SqlDbType.Decimal).Value = buyer.CMSN;
            cmd.Parameters.Add("@CNT_PRSN", SqlDbType.VarChar, 30).Value = buyer.CNT_PRSN;
            cmd.Parameters.Add("@PAY_TERM1", SqlDbType.VarChar, 50).Value = buyer.PAY_TERM1;
            cmd.Parameters.Add("@PAY_TERM2", SqlDbType.VarChar, 50).Value = buyer.PAY_TERM2;
            cmd.Parameters.Add("@PAY_TERM3", SqlDbType.VarChar, 50).Value = buyer.PAY_TERM3;
            cmd.Parameters.Add("@PAY_TERM4", SqlDbType.VarChar, 50).Value = buyer.PAY_TERM4;
            cmd.Parameters.Add("@PAY_TERM5", SqlDbType.VarChar, 50).Value = buyer.PAY_TERM5;
            cmd.Parameters.Add("@PAY_TERM6", SqlDbType.VarChar, 50).Value = buyer.PAY_TERM6;
            cmd.Parameters.Add("@PAY_TERM7", SqlDbType.VarChar, 50).Value = buyer.PAY_TERM7;
            cmd.Parameters.Add("@PAY_TERM8", SqlDbType.VarChar, 50).Value = buyer.PAY_TERM8;
            //cmd.Parameters.Add("@RMK1", SqlDbType.VarChar, 30).Value = buyer.RMK1;
            //cmd.Parameters.Add("@RMK2", SqlDbType.VarChar, 30).Value = buyer.RMK2;
            //cmd.Parameters.Add("@RMK3", SqlDbType.VarChar, 30).Value = buyer.RMK3;
            //cmd.Parameters.Add("@RMK4", SqlDbType.VarChar, 30).Value = buyer.RMK4;
            cmd.Parameters.Add("@RMK5", SqlDbType.Text).Value = buyer.RMK5;
            cmd.Parameters.Add("@OPEN_BAL", SqlDbType.Decimal).Value = buyer.OPEN_BAL;
           // cmd.Parameters.Add("@ST_CODE", SqlDbType.VarChar, 4).Value = buyer.ST_CODE;
           // cmd.Parameters.Add("@ST_NO", SqlDbType.VarChar, 25).Value = buyer.ST_NO;
            cmd.Parameters.Add("@DEAL_ITM", SqlDbType.VarChar, 40).Value = buyer.DEAL_ITM;
            cmd.Parameters.Add("@VISITOR", SqlDbType.VarChar, 45).Value = buyer.VISITOR;
            //cmd.Parameters.Add("@M0411", SqlDbType.Bit).Value = buyer.M0411;
            cmd.Parameters.Add("@VISIT_ADD1", SqlDbType.VarChar, 45).Value = buyer.VISIT_ADD1;
            cmd.Parameters.Add("@VISIT_ADD2", SqlDbType.VarChar, 45).Value = buyer.VISIT_ADD2;
            cmd.Parameters.Add("@VISIT_ADD3", SqlDbType.VarChar, 45).Value = buyer.VISIT_ADD3;
            cmd.Parameters.Add("@BANK_ACNO", SqlDbType.VarChar, 40).Value = buyer.BANK_ACNO;
            cmd.Parameters.Add("@SWIFT_ACNO", SqlDbType.VarChar, 40).Value = buyer.SWIFT_ACNO;
            cmd.Parameters.Add("@RELA_SINCE", SqlDbType.DateTime).Value = buyer.RELA_SINCE;
            cmd.Parameters.Add("@SOURCE", SqlDbType.VarChar, 25).Value = buyer.SOURCE;
            cmd.Parameters.Add("@CATEGORY", SqlDbType.VarChar, 2).Value = buyer.CAT_CODE;
           
            cmd.Parameters.Add("@EDIT_BY", SqlDbType.VarChar, 3).Value = buyer.EDIT_BY;
            cmd.Parameters.Add("@CAT_CODE", SqlDbType.VarChar, 2).Value = buyer.CAT_CODE;
            
            cmd.Parameters.Add("@WEB_ADDR", SqlDbType.VarChar, 254).Value = buyer.WEB_ADDR;
           // cmd.Parameters.Add("@PICTPATH1", SqlDbType.VarChar, 100).Value = buyer.PICTPATH1;
            //cmd.Parameters.Add("@PICTPATH2", SqlDbType.VarChar, 100).Value = buyer.PICTPATH2;
            //cmd.Parameters.Add("@PICTPATH3", SqlDbType.VarChar, 100).Value = buyer.PICTPATH3;
            //cmd.Parameters.Add("@PICTPATH4", SqlDbType.VarChar, 100).Value = buyer.PICTPATH4;
            //cmd.Parameters.Add("@PICTPATH5", SqlDbType.VarChar, 100).Value = buyer.PICTPATH5;
            //cmd.Parameters.Add("@PICTDESC1", SqlDbType.VarChar, 30).Value = buyer.PICTDESC1;
            //cmd.Parameters.Add("@PICTDESC2", SqlDbType.VarChar, 30).Value = buyer.PICTDESC2;
            //cmd.Parameters.Add("@PICTDESC3", SqlDbType.VarChar, 30).Value = buyer.PICTDESC3;
            //cmd.Parameters.Add("@PICTDESC4", SqlDbType.VarChar, 30).Value = buyer.PICTDESC4;
            //cmd.Parameters.Add("@PICTDESC5", SqlDbType.VarChar, 30).Value = buyer.PICTDESC5;
            cmd.Parameters.Add("@BANKCODE", SqlDbType.VarChar, 4).Value = buyer.BANKCODE;
            cmd.Parameters.Add("@MER_CODE", SqlDbType.VarChar, 4).Value = buyer.MER_CODE;
            //cmd.Parameters.Add("@DESP_CODE", SqlDbType.VarChar, 5).Value = buyer.DESP_CODE;
            cmd.Parameters.Add("@FREEZE", SqlDbType.Bit).Value = buyer.FREEZE;
            //cmd.Parameters.Add("@DISCOUNT", SqlDbType.Decimal).Value = buyer.DISCOUNT;
            //cmd.Parameters.Add("@FREIGHT", SqlDbType.Decimal).Value = buyer.FREIGHT;
            //cmd.Parameters.Add("@INSURANCE", SqlDbType.Decimal).Value = buyer.INSURANCE;
            //cmd.Parameters.Add("@REMARKS1", SqlDbType.VarChar, 80).Value = buyer.REMARKS1;
            //cmd.Parameters.Add("@REMARKS2", SqlDbType.VarChar, 80).Value = buyer.REMARKS2;
            //cmd.Parameters.Add("@REMARKS3", SqlDbType.VarChar, 80).Value = buyer.REMARKS3;
            //cmd.Parameters.Add("@REMARKS4", SqlDbType.VarChar, 80).Value = buyer.REMARKS4;
            //cmd.Parameters.Add("@REMARKS5", SqlDbType.VarChar, 80).Value = buyer.REMARKS5;
            //cmd.Parameters.Add("@REMARKS6", SqlDbType.VarChar, 80).Value = buyer.REMARKS6;
            //cmd.Parameters.Add("@REMARKS7", SqlDbType.VarChar, 80).Value = buyer.REMARKS7;
            //cmd.Parameters.Add("@REMARKS8", SqlDbType.VarChar, 80).Value = buyer.REMARKS8;
            //cmd.Parameters.Add("@REMARKS9", SqlDbType.VarChar, 80).Value = buyer.REMARKS9;
            //cmd.Parameters.Add("@REMARKS10", SqlDbType.VarChar, 80).Value = buyer.REMARKS10;
            //cmd.Parameters.Add("@USER_CODE", SqlDbType.VarChar, 3).Value = buyer.USER_CODE;
            //cmd.Parameters.Add("@PRE_CARY", SqlDbType.VarChar, 30).Value = buyer.PRE_CARY;
            //cmd.Parameters.Add("@VESSEL", SqlDbType.VarChar, 30).Value = buyer.VESSEL;
            //cmd.Parameters.Add("@RCT_PRCRG", SqlDbType.VarChar, 30).Value = buyer.RCT_PRCRG;
            //cmd.Parameters.Add("@PART_LDING", SqlDbType.VarChar, 30).Value = buyer.PART_LDING;
            //cmd.Parameters.Add("@PAYTERMCD", SqlDbType.VarChar, 10).Value = buyer.PAYTERMCD;
            //cmd.Parameters.Add("@VATRATE", SqlDbType.Decimal).Value = buyer.VATRATE;
            //cmd.Parameters.Add("@PANNO", SqlDbType.VarChar, 30).Value = buyer.PANNO;
            //cmd.Parameters.Add("@TINNO", SqlDbType.VarChar, 30).Value = buyer.TINNO;
            //cmd.Parameters.Add("@ATT_FILE1", SqlDbType.VarChar, 100).Value = buyer.ATT_FILE1;
            //cmd.Parameters.Add("@ATT_FILE2", SqlDbType.VarChar, 100).Value = buyer.ATT_FILE2;
            //cmd.Parameters.Add("@ATT_FILE3", SqlDbType.VarChar, 100).Value = buyer.ATT_FILE3;
            //cmd.Parameters.Add("@ATT_FILE4", SqlDbType.VarChar, 100).Value = buyer.ATT_FILE4;
            //cmd.Parameters.Add("@ATT_FILE5", SqlDbType.VarChar, 100).Value = buyer.ATT_FILE5;
            cmd.Parameters.Add("@BUY_FWRD", SqlDbType.VarChar, 4).Value = buyer.BUY_FWRD;
            //cmd.Parameters.Add("@LSELECTED", SqlDbType.Bit).Value = buyer.LSELECTED;
            //cmd.Parameters.Add("@LLSTSELD", SqlDbType.Bit).Value = buyer.LLSTSELD;
            cmd.Parameters.Add("@CITY_CODE", SqlDbType.VarChar, 4).Value = buyer.CITY_CODE;
            cmd.Parameters.Add("@OTHER_REF", SqlDbType.VarChar, 40).Value = buyer.OTHER_REF;
            //cmd.Parameters.Add("@CLIENT", SqlDbType.Decimal).Value = buyer.CLIENT;
            //cmd.Parameters.Add("@PICT_PATH", SqlDbType.VarChar, 100).Value = buyer.PICT_PATH;
            cmd.Parameters.Add("@STATE_CODE", SqlDbType.VarChar, 2).Value = buyer.STATE_CODE;
            cmd.Parameters.Add("@GSTPRIFIX", SqlDbType.VarChar, 3).Value = buyer.GSTPRIFIX;
            cmd.Parameters.Add("@GSTIN_CAT", SqlDbType.Bit).Value = buyer.GSTIN_CAT;
            cmd.Parameters.Add("@GSTIN_NO", SqlDbType.VarChar, 15).Value = buyer.GSTIN_NO;
            cmd.Parameters.Add("@GST_REG", SqlDbType.VarChar, 1).Value = buyer.GST_REG;

        }

   
    }
}
