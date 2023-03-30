using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class PaidReceiptOutput
    {
        public PaidReceiptOutput()
        {
            this.ReturnInfo = new ReturnMsgInfo();
        }
        public PaidReceiptDisplay ListReceiptOnline { get; set; }
        public ReturnMsgInfo ReturnInfo { get; set; }
    }
}