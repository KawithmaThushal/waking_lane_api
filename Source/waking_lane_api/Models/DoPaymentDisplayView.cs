using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class DoPaymentDisplayView
    {
        public string Service_fee { get; set; }
        public decimal Total_amount { get; set; }
    }
}