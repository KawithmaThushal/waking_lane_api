using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using waking_lane_api.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace waking_lane_api.Helpers
{
    public class AdminIssuedIDlistDBHelper
    {
        private Connection_Main connection_Main;
        private MySqlConnection con;

        public AdminIssuedIDlistOutput GetAdminIssuedIDlist(AdminIssuedIDlistInput obj)
        {
            AdminIssuedIDlistOutput rinfo = new AdminIssuedIDlistOutput();
            List<AdminIssuedIDlistDisplay> list = new List<AdminIssuedIDlistDisplay>();
            //1
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

                        string sql = "SELECT twa.Applicant_full_Name, NIC_no, Paid_date, twid.Issue_date_time, twa.ID  FROM tbl_walkinglane_applicant AS twa  INNER JOIN tbl_walkinglane_issued_details AS twid  ON twa.ID = twid.Applicant_index_No  WHERE twid.Issue_date_time BETWEEN '" + obj.FromDate + "' AND '" + obj.ToDate + "';";
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
                                AdminIssuedIDlistDisplay sec = new AdminIssuedIDlistDisplay();

                                sec.ApplicantFullName = r["Applicant_full_Name"].ToString();
                                sec.ApplicantNICno = r["NIC_no"].ToString();
                                sec.PaidDate = r["Paid_date"].ToString();
                                sec.IDIssueDateTime = r["Issue_date_time"].ToString();
                                sec.ID = r["ID"].ToString();


                                list.Add(sec);
                            }

                        }
                        else
                        {
                            rinfo.ReturnInfo.ReturnValue = "error";
                            rinfo.ReturnInfo.ReturnMessage = "Invalid Date";
                        }
                        //---------------
                    }
                }

            }

            rinfo.IssuedIDlist = list;
            return rinfo;
        }

    }
}