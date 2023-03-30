using System;
using System.Collections.Generic;
using System.Linq;
using waking_lane_api.Models;
using MySql.Data.MySqlClient;
using System.Web;
using System.Data;

namespace waking_lane_api.Helpers
{
    public class PaymentWalkingLaneServiceDBHelpers
    {
         public PaymentWalkingLaneServiceReturn GetPaymentWalkingLaneService( PaymentWalkingLaneServiceInfo obj1)
        {
            PaymentWalkingLaneServiceReturn rinfo = new PaymentWalkingLaneServiceReturn();
           
            //1
            if (obj1.ClientID == null || obj1.ClientID == "")
            {
                rinfo.ReturnInfo.ReturnValue = "error";
                rinfo.ReturnInfo.ReturnMessage = "Client ID cannot be empty";
            }
            else
            {
                this.connection_Main = new Connection_Main();
                string conString = this.connection_Main.Get_Main_Connection(obj1.ClientID);
                if (conString == null || conString == "")
                {
                    rinfo.ReturnInfo.ReturnValue = "Error";
                    rinfo.ReturnInfo.ReturnMessage = this.connection_Main.ErrorMessage;
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
                        rinfo.ReturnInfo.ReturnValue = "Error";
                        rinfo.ReturnInfo.ReturnMessage = "Connection  was already  opened.";
                    }
                    if (this.con != null)
                    {
                        

                        string sql = "SELECT twa.Applicant_full_Name, Permenent_address, NIC_no,Mobile_tele_No, paid_date, Total_amount,tw.walking_name,Service_fee FROM tbl_walkinglane_applicant AS twa INNER JOIN tbl_walkinglane AS tw ON twa.Walking_ID=tw.walking_id WHERE twa.ID='"+obj1.ID+"';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, this.con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "btDT");
                        DataTable dt1 = ds.Tables["btDT"];
                        if (dt1.Rows.Count > 0)
                        {
                            rinfo.ReturnInfo.ReturnValue = "OK";
                            rinfo.ReturnInfo.ReturnMessage = "result found";
                            foreach (DataRow r in dt1.Rows)
                            {
                                PaymentWalkingLaneServiceDisplay objec2 = new PaymentWalkingLaneServiceDisplay();

                             
                               
                           
                                objec2.Applicant_full_Name = r["Applicant_full_Name"].ToString();
                                objec2.NIC_no = r["NIC_no"].ToString();
                                objec2.Permenent_address = r["Permenent_address"].ToString();
                                objec2.Mobile_tele_No = r["Mobile_tele_No"].ToString();
                                objec2.paid_date = r["paid_date"].ToString();
                                objec2.Total_amount = r["Total_amount"].ToString();
                                objec2.walking_name = r["walking_name"].ToString();
                                objec2.Service_fee = r["Service_fee"].ToString();
                             




                                rinfo.ListPaymentWalkingLaneService =objec2;
                            }

                        }
                        else
                        {
                            rinfo.ReturnInfo.ReturnValue = "error";
                            rinfo.ReturnInfo.ReturnMessage = "Invalid Reference ID";
                        }
                        //---------------
                    }
                }

            }

           
            return rinfo;
        }


        public Connection_Main connection_Main { get; set; }



        public MySqlConnection con { get; set; }
    }
    
    
}