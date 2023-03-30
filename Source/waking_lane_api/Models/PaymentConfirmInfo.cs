using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class PaymentConfirmInfo
    {
        public string ClientID { get; set; }
        public int Payment_id { get; set; }
        public int Applicant_index { get; set; }
        public int Applicant_index_No { get; set; }
        public int ID { get; set; }
    }
}