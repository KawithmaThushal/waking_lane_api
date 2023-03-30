using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using waking_lane_api.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace waking_lane_api.Helpers
{
    public class AdminIssueIDDBHelper
    {

        private Connection_Main connection_Main;
        private MySqlConnection con;

        private MySqlTransaction trans;
        private bool flag;


        public ReturnMsgInfo GetAdminIssueID(AdminIssueIDInput obj)
        {

            ReturnMsgInfo rinfo = new ReturnMsgInfo();

            if (obj.ClientID == null || obj.ClientID == "")
            {
                rinfo.ReturnValue = "error";
                rinfo.ReturnMessage = "Client ID cannot be empty";
            }
            else
            {
                this.connection_Main = new Connection_Main();
                string conString = this.connection_Main.Get_Main_Connection(obj.ClientID);
                if (conString == null || conString == "")
                {
                    rinfo.ReturnValue = "Error";
                    rinfo.ReturnMessage = this.connection_Main.ErrorMessage;
                }
                else
                {

                    this.con = new MySqlConnection(conString);
                    if (this.con.State.ToString() != "Open")
                    {
                        this.con.Open();
                    }
                    else
                    {
                        rinfo.ReturnValue = "Error";
                        rinfo.ReturnMessage = "Connection  was already  opened.";
                    }
                    if (this.con != null)
                    {
                        //method body
                        try
                        {
                       

                            string sql1 = "INSERT INTO tbl_walkinglane_issued_details( Comment_by, Commented_date_time, Expire_date, Issue_date_time, Comment, Applicant_index_No)  VALUES ('" + obj.CommentBy + "', NOW(), '" + obj.ExpireDate + "', NOW(), '" + obj.Comment + "', '" + obj.ApplicantIndexNO + "');";
                            MySqlCommand cmd = new MySqlCommand(sql1, this.con, trans);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            flag = true;


                            string sql2 = "UPDATE tbl_walkinglane_application_history AS twah SET twah.Status = 'Issued'  WHERE twah.Applicant_index_No = '" + obj.ApplicantIndexNO + "';";
                            MySqlCommand cmd2 = new MySqlCommand(sql2, this.con, trans);
                            cmd2.CommandType = CommandType.Text;
                            cmd2.ExecuteNonQuery();
                            flag = true;






                            rinfo.ReturnValue = "OK";
                            rinfo.ReturnMessage = "Successfully Inserted";

                        }
                        catch (MySqlException myEx)
                        {
                            rinfo.ReturnValue = "Error";
                            rinfo.ReturnMessage = myEx.Message;

                        }


                    }

                }

            }


            return rinfo;
        }






    }
}