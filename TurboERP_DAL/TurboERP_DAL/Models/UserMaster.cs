using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurboERP_DAL.Models
{
    public class UserMaster
    {
        public int Pid { get; set; }
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Short_Name { get; set; }
        [Required]
        public string Login_Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string Add_1 { get; set; }
        public string Add_2 { get; set; }
        public string Add_3 { get; set; }
        public string Add_4 { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Ac_Expire { get; set; }
        public Nullable<System.DateTime> Ac_Exp_Dt { get; set; }
        public Nullable<int> Qpid { get; set; }
        public string Answer { get; set; }
        public Nullable<bool> Reset_Pass { get; set; }
        public Nullable<System.DateTime> Reset_Pass_Dt { get; set; }
        public string Photo_Attach { get; set; }
        [Required]
        public Nullable<int> Ug_Pid { get; set; }
        public Nullable<int> Circle_Pid { get; set; }
        public string Input_By { get; set; }
        public Nullable<System.DateTime> Input_Dt { get; set; }
        public string Modify_By { get; set; }
        public Nullable<System.DateTime> Modify_Dt { get; set; }
        public Nullable<int> User_Type { get; set; }
        public Nullable<int> STATE_PID { get; set; }
        public Nullable<int> PIN_PID { get; set; }
        public Nullable<int> City_Pid { get; set; }
        public Nullable<System.DateTime> Pswd_ActiveDate { get; set; }
        public Nullable<bool> Frgt_Pass_Chk { get; set; }
        public Nullable<System.DateTime> Login_Date { get; set; }
        public string Contact_No { get; set; }
        public Nullable<bool> Shiva_Login { get; set; }
        public Nullable<int> Lob_Pid { get; set; }
        public string Lob_Id { get; set; }
    }
}