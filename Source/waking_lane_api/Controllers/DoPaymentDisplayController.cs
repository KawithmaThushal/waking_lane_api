using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using waking_lane_api.Helpers;
using waking_lane_api.Models;
using System.Net.Http;
using System.Web.Http;

namespace waking_lane_api.Controllers
{
    public class DoPaymentDisplayController : ApiController
    {

        public DoPaymentDisplayReturn Post([FromBody]DoPaymentDisplayInfo Object1)
        {
            DoPaymentDisplayDBHelpers db6 = new DoPaymentDisplayDBHelpers();
            return db6.GetDoPaymentDisplay(Object1);
        }

     
    }
}
