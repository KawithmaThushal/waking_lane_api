using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class AdminIssuedIDlistInput
    {
        public string ClientID { get; set; }
        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
}