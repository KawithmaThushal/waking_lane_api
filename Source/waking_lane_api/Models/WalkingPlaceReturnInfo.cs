using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class WalkingPlaceReturnInfo
    {

        public WalkingPlaceReturnInfo()
        {
            this.ReturnInfo = new ReturnMsgInfo();

        }

        public List<Walking_Place> ListWalking_Place { get; set; }

        public ReturnMsgInfo ReturnInfo { get; set; }

       
    }
}