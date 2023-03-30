using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class AdminIssuedIDoverViewOutput
    {

        public AdminIssuedIDoverViewOutput()
        {
            this.ReturnInfo = new ReturnMsgInfo();
        }
        public AdminIssuedIDoverViewDisplay obj { get; set; }
        public ReturnMsgInfo ReturnInfo { get; set; }
    }
}