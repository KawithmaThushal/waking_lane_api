using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using waking_lane_api.Helpers;
using waking_lane_api.Models;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace waking_lane_api.Controllers
{
    [EnableCors(origins: "*", headers: "", methods: "*")]
    public class PaidReceiptController : ApiController
    {
       

        // POST api/paidreceipt
        public PaidReceiptOutput Post([FromBody]PaidReceiptInput object1)
        {
            
            PaidReceiptDBHelper db5 = new  PaidReceiptDBHelper();
            return db5.GetReceiptOnlineProcurement(object1);

        }

        
    }
}
