using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using waking_lane_api.Models;
using MySql.Data.MySqlClient;
using System.Data;
using waking_lane_api.Models;


namespace waking_lane_api.Helpers
{
    public class PaidReceiptDBHelper
    {

        public PaidReceiptOutput GetReceiptOnlineProcurement(PaidReceiptInput objct1)
        {
            PaidReceiptOutput rinfo = new PaidReceiptOutput();

            //1
            if (objct1.ClientId == null || objct1.ClientId == "")
            {
                rinfo.ReturnInfo.ReturnValue = "error";
                rinfo.ReturnInfo.ReturnMessage = "Client ID cannot be empty";
            }
            else
            {
                this.connection_Main = new Connection_Main();
                string conString = this.connection_Main.Get_Main_Connection(objct1.ClientId);
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
                        //method body

                        string sql = "SELECT tw.walking_name, twa.Index_no, twa.Applicant_full_Name, twa.Permenent_address, twa.NIC_no, twa.Mobile_tele_No, twa.Total_amount, top.OwnerName, top.PaymentID FROM tbl_walkinglane_receipt AS twr INNER JOIN tbl_walkinglane_applicant AS twa ON twr.Applicant_index = twa.ID INNER JOIN tbl_online_payment AS top ON twr.Payment_id = top.ID INNER JOIN tbl_walkinglane AS tw ON twa.Walking_ID = tw.walking_id WHERE twa.ID = 11;";
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
                                PaidReceiptDisplay objec2 = new PaidReceiptDisplay();
                                objec2.WalkingName = r["walking_name"].ToString();
                                objec2.IndexNo = r["Index_no"].ToString();
                                objec2.ApplicantName = r["Applicant_full_Name"].ToString();
                                objec2.ApplicantAddress = r["Permenent_address"].ToString();
                                objec2.ApplicantNIC = r["NIC_no"].ToString();
                                objec2.ApplicantMobileNumber = r["Mobile_tele_No"].ToString();
                                objec2.TotalAmount = r["Total_amount"].ToString();
                                objec2.OwnerName = r["OwnerName"].ToString();
                                objec2.PaymentID = r["PaymentID"].ToString();

                                rinfo.ListReceiptOnline = objec2;

                            }

                        }
                        else
                        {
                            rinfo.ReturnInfo.ReturnValue = "error";
                            rinfo.ReturnInfo.ReturnMessage = "Invalid Reference ID";
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