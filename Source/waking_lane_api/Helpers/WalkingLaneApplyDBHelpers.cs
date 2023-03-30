using System;
using System.Collections.Generic;
using System.Linq;
using waking_lane_api.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web;

namespace waking_lane_api.Helpers
{
    public class WalkingLaneApplyDBHelpers
    {
           private MySqlTransaction trans;
        private bool flag;
        public ReturnMsgInfo GetWalkingLaneApply(WalkingLaneApplyInfo objct3)
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

                            string sql = "UPDATE tbl_walkinglane_Index AS twi SET twi.Index_ID = twi.Index_ID + 1 WHERE twi.ID = 1;";
                         MySqlCommand cmd1 = new MySqlCommand(sql, this.con, trans);
                           cmd1.CommandType = CommandType.Text;
                          cmd1.ExecuteNonQuery();
                           flag = true;

                    //       string IndexCode="";
                    //      string IndexId="";
                           string refno = "";
                           string sqlselect = "SELECT CONCAT (twi.IndexCode , twi.Index_ID) as 'RefNo' FROM tbl_walkinglane_Index AS twi;";
                           MySqlDataAdapter da = new MySqlDataAdapter(sqlselect, this.con);
                           DataSet ds = new DataSet();
                           da.Fill(ds, "btDT");
                           DataTable dt1 = ds.Tables["btDT"];
                           if (dt1.Rows.Count > 0)
                           {
                               refno = dt1.Rows[0]["RefNo"].ToString();

                           }
                           string sql1 = "INSERT INTO tbl_walkinglane_applicant(NIC_no, Applicant_full_Name, Date_of_birth, Permenent_address, Email, Occupation, In_the_council, Home_tele_No, Mobile_tele_No, Emergency_contact_person_number, Emergency_contact_person_name, Upload_the_customer_Photo, Walking_ID,Index_no,User_id)VALUES('" + objct3.NIC + "', '" + objct3.FullName + "', '" + objct3.Birth_of_Date + "', '" + objct3.Adress + "', '" + objct3.Email + "', '" + objct3.Occupation + "', '" + objct3.InTheCounsill + "', '" + objct3.Home_Tele_No + "', '" + objct3.Mobile_Tele_No + "', '" + objct3.EmargencyContactNumber + "', '" + objct3.EmargencyContactName + "', '" + objct3.UploadYourPoto + "','" + objct3.Walking_ID + "','" + refno + "','"+objct3.User_id+"');";
                           MySqlCommand cmd = new MySqlCommand(sql1, this.con, trans);
                           cmd.CommandType = CommandType.Text;
                           cmd.ExecuteNonQuery();
                           flag = true;
                           int ID = int.Parse(cmd.LastInsertedId.ToString());


                           string sql2 = "INSERT INTO tbl_walkinglane_application_history(Status , Applicant_index_No) VALUES ('Saved' ,'"+ID+"');";
                           MySqlCommand cmd3 = new MySqlCommand(sql2, this.con, trans);
                           cmd3.CommandType = CommandType.Text;
                           cmd3.ExecuteNonQuery();
                           flag = true;









                            rinfo.ReturnValue = "OK";
                            rinfo.ReturnMessage = "Successfully Inserted";

                        }
                        catch (MySqlException myEx)
                        {
                            rinfo.ReturnValue = "Error";
                            rinfo.ReturnMessage = "Tender Id is invalid";

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