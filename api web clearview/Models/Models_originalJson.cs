using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_web_clearview.Models
{
    public class Models_originalJson
    {
        public Model_original[] Tickets { get; set; }
    }

    public class Model_original
    {
        public int id { get; set; }
        public string key { get; set; }
        public data_fildsx[] fields { get; set; }
    }
    public class data_fildsx
    {

        public int agentId { get; set; }
        public string agentName { get; set; }
        public string startDate { get; set; }
        public string type { get; set; }
        public string priority { get; set; }
        public string company { get; set; }
        public bool completed { get; set; }
        public int totalDuration { get; set; }
        public data_sumarysx[] summaryStates { get; set; }

    }


    public class data_sumarysx
    {

        public int id { get; set; }
        public string name { get; set; }
        public int duration { get; set; }

    }
}
