using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using waking_lane_api.Models;
using System.Web;

namespace waking_lane_api.Helpers
{
    public class PaymentConfirmDBHelper
    {
          private MySqlTransaction trans;
        private bool flag;
        public ReturnMsgInfo GetPaymentConfirm(PaymentConfirmInfo objct3)
        {
            ReturnMsgInfo rinfo = new ReturnMsgInfo();

            if (objct3.ClientID == null || objct3.ClientID == "")
            {
                rinfo.ReturnValue = "error";
                rinfo.ReturnMessage = "Client ID cannot be empty";
            }
            else
            {
                this.connection_Main = new Connection_Main();
                string conString = this.connection_Main.Get_Main_Connection(objct3.ClientID);
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

                            string sql = "UPDATE tbl_walkinglane_applicant AS twa SET twa.Paid_date = NOW() WHERE twa.ID ='"+objct3.ID+"';";
                            MySqlCommand cmd1 = new MySqlCommand(sql, this.con, trans);
                            cmd1.CommandType = CommandType.Text;
                            cmd1.ExecuteNonQuery();
                            flag = true;
                              
                            string sql2 = "UPDATE tbl_walkinglane_application_history AS twah SET twah.Status = 'Paid'  WHERE twah.Applicant_index_No ='"+objct3.Applicant_index_No+"';";
                            MySqlCommand cmd2 = new MySqlCommand(sql2, this.con, trans);
                            cmd2.CommandType = CommandType.Text;
                            cmd2.ExecuteNonQuery();
                            flag = true;
                               
                            string sql3 = "INSERT INTO tbl_walkinglane_receipt(Date, Time , Applicant_index, Payment_id)VALUES(NOW(),NOW(),'"+objct3.Applicant_index+"','"+objct3.Payment_id+"');";
                            MySqlCommand cmd3 = new MySqlCommand(sql3, this.con, trans);
                            cmd3.CommandType = CommandType.Text;
                            cmd3.ExecuteNonQuery();
                            flag = true;



                            rinfo.ReturnValue = "OK";
                            rinfo.ReturnMessage = "Successfully Inserted";

                        }
                        catch (MySqlException myEx)
                        {
                            rinfo.ReturnValue = "Error";
                            rinfo.ReturnMessage = "Id is invalid";

                        }
                       
                        
                    }
                }

            }
           
           
            return rinfo;



           
        }




        public Connection_Main connection_Main { get; set; }

        public MySqlConnection con { get; set; }
    }
    
}