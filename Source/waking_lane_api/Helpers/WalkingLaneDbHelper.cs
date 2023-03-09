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
    public class WalkingLaneDbHelper
    {
        private Connection_Main connection_Main;
        private MySqlConnection con;


        public WalkingPlaceReturnInfo GetWorkingPlaceList(LocationInfo obj)
        {
            WalkingPlaceReturnInfo rinfo = new WalkingPlaceReturnInfo();
            List<Walking_Place> list = new List<Walking_Place>();
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

                        string sql = "SELECT * FROM tbl_walkinglane;";
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
                                Walking_Place sec = new Walking_Place();
                                sec.Walking_Id = int.Parse(r["walking_id"].ToString());
                                sec.Walking_Name = r["walking_name"].ToString();
                                sec.Place = r["Place"].ToString();
                                list.Add(sec);
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

            rinfo.ListWalking_Place = list;
            return rinfo;
        }







    }
}