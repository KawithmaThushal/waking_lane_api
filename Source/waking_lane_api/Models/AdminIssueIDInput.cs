using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waking_lane_api.Models
{
    public class AdminIssueIDInput
    {

        public string ClientID { get; set; }
        public string CommentBy { get; set; }
        public string ExpireDate { get; set; }
        public string Comment { get; set; }
        public string ApplicantIndexNO { get; set; }

    }
}