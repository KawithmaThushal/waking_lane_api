using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class DoPaymentDisplayReturn
    {
        public DoPaymentDisplayReturn()
            {
                this.ReturnInfo = new ReturnMsgInfo();
            }
        public DoPaymentDisplayView ListDoPaymentDisplay { get; set; }
            public ReturnMsgInfo ReturnInfo { get; set; }
        
    }
}