using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using waking_lane_api.Models;
using System.Data;
using System.Web;

namespace waking_lane_api.Helpers
{
    public class DoPaymentDisplayDBHelpers
    {
        private MySqlTransaction trans;
        private bool flag;
        
        private Connection_Main connection_Main;
        private MySqlConnection con;

        public DoPaymentDisplayReturn GetDoPaymentDisplay(DoPaymentDisplayInfo obj)
        {
            DoPaymentDisplayReturn rinfo = new DoPaymentDisplayReturn();

            //11   
            if (obj.ClientID == null || obj.ClientID == "")
            {
                rinfo.ReturnInfo.ReturnValue = "error";
                rinfo.ReturnInfo.ReturnMessage = "Client ID cannot be empty";
            }
            else
            {
                this.connection_Main = new Connection_Main();
                string conString = this.connection_Main.Get_Main_Connection(obj.ClientID);
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

                        string sql = "SELECT tw.Service_fee FROM tbl_walkinglane AS tw  INNER JOIN tbl_walkinglane_applicant AS twa ON tw.walking_id = twa.Walking_ID  WHERE twa.ID ='"+obj.ID+"';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, this.con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "btDT");
                        DataTable dt1 = ds.Tables["btDT"];

                        DoPaymentDisplayView objec1 = new DoPaymentDisplayView();

                        if (dt1.Rows.Count > 0)
                        {
                            rinfo.ReturnInfo.ReturnValue = "OK";
                            rinfo.ReturnInfo.ReturnMessage = "result found";
                            foreach (DataRow r in dt1.Rows)
                            {
                                objec1.Service_fee= r["Service_fee"].ToString();
                            }

                        }
                         string sql3 = "UPDATE tbl_walkinglane_applicant AS twa SET twa.Total_amount ='"+obj.Total_amount+"' WHERE twa.ID ='"+obj.ID+"';";
                         MySqlCommand cmd1 = new MySqlCommand(sql3, this.con, trans);
                         cmd1.CommandType = CommandType.Text;
                         cmd1.ExecuteNonQuery();
                         flag = true;



                         string sql2 = "SELECT tw.Service_fee, twa.Total_amount FROM tbl_walkinglane AS tw INNER JOIN tbl_walkinglane_applicant AS twa ON tw.walking_id = twa.Walking_ID WHERE twa.ID = 11";
                        MySqlDataAdapter da1 = new MySqlDataAdapter(sql2, this.con);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1, "btDT1");
                        DataTable dt2 = ds1.Tables["btDT1"];

                        if (dt2.Rows.Count > 0)
                        {
                            rinfo.ReturnInfo.ReturnValue = "OK";
                            rinfo.ReturnInfo.ReturnMessage = "result found";
                            foreach (DataRow r in dt2.Rows)
                            {
                                //PaidOverviewDisplay sec1 = new PaidOverviewDisplay();

                                sec.ApproveRejectDateTime = r["ApproveReject_date_time"].ToString();
                                sec.PaidDateTime = r["Paid_date"].ToString();

                               

                            }

                        }



                        rinfo.ListDoPaymentDisplay = objec1;

                    }
                    else
                    {
                        rinfo.ReturnInfo.ReturnValue = "error";
                        rinfo.ReturnInfo.ReturnMessage = "Invalid Reference ID";
                    }
                    //---------------

                }



            }

            return rinfo;

        }
           



    

    }
}