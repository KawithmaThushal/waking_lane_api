using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using waking_lane_api.Helpers;
using waking_lane_api.Models;
using System.Web.Http.Cors;

namespace waking_lane_api.Controllers
{
    [EnableCors(origins: "*", headers: "", methods: "*")]

    public class AdminIssueIDController : ApiController
    {
       
        // POST api/adminissueid
        public ReturnMsgInfo Post([FromBody]AdminIssueIDInput obj1)
        {
            AdminIssueIDDBHelper db = new AdminIssueIDDBHelper();
            return db.GetAdminIssueID(obj1);

        }

       
    }
}
