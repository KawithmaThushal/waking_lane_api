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

    public class AdminIssuedIDlistController : ApiController
    {
      
        // POST api/adminissuedidlist
        public AdminIssuedIDlistOutput Post([FromBody]AdminIssuedIDlistInput obj1)
        {
            AdminIssuedIDlistDBHelper db = new AdminIssuedIDlistDBHelper();
            return db.GetAdminIssuedIDlist(obj1);

        }

       
    }
}
