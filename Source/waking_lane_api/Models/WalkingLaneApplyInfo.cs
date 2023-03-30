using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class WalkingLaneApplyInfo
    {
        public string FullName { get; set; }
        public string ClientID { get; set; }
        public int Walking_ID { get; set; }
        public int User_id { get; set; }


        public string NIC { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Mobile_Tele_No { get; set; }
        public string Home_Tele_No { get; set; }
        public string Birth_of_Date { get; set; }
        public string InTheCounsill { get; set; }
        public string EmargencyContactNumber { get; set; }
        public string EmargencyContactName { get; set; }
        public string UploadYourPoto { get; set; }


    }
}