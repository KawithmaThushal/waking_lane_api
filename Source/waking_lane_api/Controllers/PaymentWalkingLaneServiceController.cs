using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using waking_lane_api.Helpers;
using waking_lane_api.Models;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;

namespace waking_lane_api.Controllers
{
      [EnableCors(origins: "*", headers: "", methods: "*")]
    public class PaymentWalkingLaneServiceController : ApiController
    {

        public PaymentWalkingLaneServiceReturn Post([FromBody] PaymentWalkingLaneServiceInfo object1)
        {
            PaymentWalkingLaneServiceDBHelpers db5 = new PaymentWalkingLaneServiceDBHelpers();
            return db5.GetPaymentWalkingLaneService(object1);
        }

        
        
    }
}
