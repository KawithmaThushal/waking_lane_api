using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using waking_lane_api.Helpers;
using waking_lane_api.Models;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace waking_lane_api.Controllers
{
     [EnableCors(origins: "*", headers: "", methods: "*")]


    public class WalkingLaneApplyController : ApiController
    {
   
        public ReturnMsgInfo Post([FromBody] WalkingLaneApplyInfo object2)
        {
            WalkingLaneApplyDBHelpers db6 = new WalkingLaneApplyDBHelpers();
            return db6.GetWalkingLaneApply(object2);

        
        }


    }
}
