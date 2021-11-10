using api_web_clearview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using Nancy.Json;

namespace api_web_clearview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       static string  dataDir = @"C:\Users\nefi.garcia\Desktop\";

        private readonly ILogger<WeatherForecastController> _logger;


        
        [HttpGet]
        public object Get()
        {
            var data = Getdatajson();
            var dat = Get_New_Formats(data, "outPutGet");
            
            return dat;
        }

        

       
        [HttpPost]
        public object Post ()
        {
            var data = Getdatajson();
            var dat = Get_New_Formats(data, "outPutPost");
            return dat;

        }

        public static List<Model_new_format> Get_New_Formats(string data,string namedoc)
        {
            List<string> intermediate_list = new List<string>();
            intermediate_list.Add("ticketID,key,agentName,startDate,type,priority,company,completed,totalDuration,open,inProgress,waiting,internalValidation");
            List<Model_new_format> data_Mastertickets = new List<Model_new_format> {

                
                            
        };
            
            for (int i = 0; i <= 12; i++)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                dynamic blogObject = js.Deserialize<dynamic>(data);

                object v_ticketID = blogObject[0][i][0];
                object v_key = blogObject[0][i][1];
                object v_agentName = blogObject[0][i][2][0][1];
                object v_startDate = blogObject[0][i][2][0][2];
                object v_type = blogObject[0][i][2][0][3];
                object v_priority = blogObject[0][i][2][0][4];
                object v_company = blogObject[0][i][2][0][5];
                object v_completed = blogObject[0][i][2][0][6];
                object v_totalDuration = blogObject[0][i][2][0][7];
                object v_open = blogObject[0][i][2][0][8][0][2];
                object v_inProgress = blogObject[0][i][2][0][8][1][2];
                object v_waiting = blogObject[0][i][2][0][8][2][2];
                object v_internalValidation = blogObject[0][i][2][0][8][3][2];

                intermediate_list.Add(v_ticketID + "," + v_key + "," + v_agentName + "," + v_startDate + "," + v_type + "," +
                    v_priority + "," + v_company + "," + v_completed + "," + v_totalDuration + "," + v_open + "," +
                    v_inProgress + "," + v_waiting + "," + v_internalValidation);

                data_Mastertickets.Add(
                new Model_new_format
                {
                    ticketID = v_ticketID + "",
                    key = v_key + "",
                    agentName = v_agentName + "",
                    startDate = v_startDate + "",
                    type = v_type + "",
                    priority = v_priority + "",
                    company = v_company + "",
                    completed = v_completed + "",
                    totalDuration = v_totalDuration + "",
                    open = v_open + "",
                    inProgress = v_inProgress + "",
                    waiting = v_waiting + "",
                    internalValidation = v_internalValidation + ""

                });

                if (v_internalValidation==null)
                {
                    break;
                }
                
            }

            System.IO.File.WriteAllLines(@""+dataDir + namedoc+".txt", intermediate_list);
            return data_Mastertickets;
        }

        public static string Getdatajson()
        {
            string datajsonfile;
            using (var reader = new StreamReader("IntegrationTest.json"))
            {
                datajsonfile = reader.ReadToEnd();
            }
            return datajsonfile;
        }

        
        
    }
}
