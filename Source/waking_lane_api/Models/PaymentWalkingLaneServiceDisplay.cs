using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class PaymentWalkingLaneServiceDisplay
    {
        public string Service_fee { get; set; }
        public string walking_name { get; set; }

        public string Total_amount { get; set; }

        public string paid_date { get; set; }
        public string Mobile_tele_No { get; set; }
        public string NIC_no { get; set; }
        public string Permenent_address { get; set; }
        public string Applicant_full_Name { get; set; }
       

    }
}