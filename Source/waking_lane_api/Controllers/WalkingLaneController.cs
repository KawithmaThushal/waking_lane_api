using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using waking_lane_api.Helpers;
using waking_lane_api.Models;

namespace waking_lane_api.Controllers
{
    public class WalkingLaneController : ApiController
    {
        

        // POST api/walkinglane
        public WalkingPlaceReturnInfo Post([FromBody]LocationInfo obj1)
        {
            WalkingLaneDbHelper db = new WalkingLaneDbHelper();
            return db.GetWorkingPlaceList(obj1);
        }

        
    }
}
