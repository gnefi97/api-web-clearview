using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_web_clearview.Models
{
    public class Model_new_format
    {
        public string ticketID { get; set; }
        public string key { get; set; }
        public string agentName { get; set; }
        public string startDate { get; set; }
        public string type { get; set; }
        public string priority { get; set; }
        public string company { get; set; }
        public string completed { get; set; }
        public string totalDuration { get; set; }
        public string open { get; set; }
        public string inProgress { get; set; }
        public string waiting { get; set; }
        public string internalValidation { get; set; }
    }
}
