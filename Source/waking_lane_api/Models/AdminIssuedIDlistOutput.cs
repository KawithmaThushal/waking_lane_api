using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class AdminIssuedIDlistOutput
    {
        public AdminIssuedIDlistOutput()
        {
            this.ReturnInfo = new ReturnMsgInfo();
        }
        public List<AdminIssuedIDlistDisplay> IssuedIDlist { get; set; }
        public ReturnMsgInfo ReturnInfo { get; set; }
    }
}