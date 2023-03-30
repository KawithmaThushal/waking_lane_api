using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class PaymentWalkingLaneServiceReturn
    {

        public PaymentWalkingLaneServiceReturn()
            {
                this.ReturnInfo = new ReturnMsgInfo();
            }
        public PaymentWalkingLaneServiceDisplay ListPaymentWalkingLaneService { get; set; }
            public ReturnMsgInfo ReturnInfo { get; set; }
        
    }
}