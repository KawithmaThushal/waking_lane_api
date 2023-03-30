using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using waking_lane_api.Models;
using MySql.Data.MySqlClient;
using System.Data;



namespace waking_lane_api.Helpers
{
    public class AdminIssuedIDoverViewDBHelper
    {


        private Connection_Main connection_Main;
        private MySqlConnection con;

        public AdminIssuedIDoverViewOutput GetAdminIssuedIDoverView(AdminIssuedIDoverViewInput obj)
        {
            AdminIssuedIDoverViewOutput rinfo = new AdminIssuedIDoverViewOutput();

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

                        string sql = "SELECT twa.NIC_no, Applicant_full_Name, Date_of_birth, Permenent_address, Email, Occupation, In_the_council, Home_tele_No, Mobile_tele_No, Emergency_contact_person_number, Emergency_contact_person_name, Upload_the_customer_Photo,paid_date, Total_amount, tw.walking_name FROM tbl_walkinglane_applicant AS twa INNER JOIN tbl_walkinglane AS tw ON twa.Walking_ID = tw.walking_id WHERE twa.ID = '" + obj.twaID + "';";


                        MySqlDataAdapter da = new MySqlDataAdapter(sql, this.con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "btDT");
                        DataTable dt1 = ds.Tables["btDT"];

                        AdminIssuedIDoverViewDisplay sec = new AdminIssuedIDoverViewDisplay();

                        if (dt1.Rows.Count > 0)
                        {
                            rinfo.ReturnInfo.ReturnValue = "OK";
                            rinfo.ReturnInfo.ReturnMessage = "result found";
                            foreach (DataRow r in dt1.Rows)
                            {
                                sec.NicNO = r["NIC_no"].ToString();
                                sec.ApplicantFullName = r["Applicant_full_Name"].ToString();
                                sec.DateOfBirth = r["Date_of_birth"].ToString();
                                sec.PermenentAddress = r["Permenent_address"].ToString();
                                sec.Email = r["Email"].ToString();
                                sec.Occupation = r["Occupation"].ToString();
                                sec.IntheCouncil = r["In_the_council"].ToString();
                                sec.HomeTeleNo = r["Home_tele_No"].ToString();
                                sec.MobileTeleNo = r["Mobile_tele_No"].ToString();
                                sec.EmergencyContactPersonName = r["Emergency_contact_person_name"].ToString();
                                sec.EmergencyContactPersonNumber = r["Emergency_contact_person_number"].ToString();
                                sec.UploadTheCustomerPhoto = r["Upload_the_customer_Photo"].ToString();
                                sec.paidDate = r["paid_date"].ToString();
                                sec.TotalAmount = r["Total_amount"].ToString();
                                sec.walkingName = r["walking_name"].ToString();



                                // rinfo.Tenderobject = sec;

                            }

                        }



                   



                        rinfo.obj = sec;

                    }
                    else
                    {
                        rinfo.ReturnInfo.ReturnValue = "error";
                        rinfo.ReturnInfo.ReturnMessage = "Invalid  ID";
                    }
                    //---------------

                }



            }

            return rinfo;

        }
           



    }
}