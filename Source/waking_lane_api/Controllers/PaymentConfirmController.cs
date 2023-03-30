using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using waking_lane_api.Models;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using waking_lane_api.Helpers;

namespace waking_lane_api.Controllers
{
     [EnableCors(origins: "*", headers: "", methods: "*")]
    public class PaymentConfirmController : ApiController
    {

        
        public ReturnMsgInfo Post([FromBody]PaymentConfirmInfo Object1)
        {

            PaymentConfirmDBHelper db6 = new PaymentConfirmDBHelper();
            return db6.GetPaymentConfirm(Object1);
        }

      
    }
}
