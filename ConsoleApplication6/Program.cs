using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpPutDemo();
            HttpPostDemo();
        }

        private static void HttpPutDemo()
        {
            // HTTP GET            
            using (var client = new HttpClient())
            {
                var uri = "http://localhost:51278/ExternalResource-service/ExternalResource(46682)";

                HttpRequestMessage reqMsg = new HttpRequestMessage(HttpMethod.Get, uri);
                reqMsg.Headers.Add("x-acc-clientid", "4d53bce03ec34c0a911182d4c228ee6c");
                reqMsg.Headers.Add("x-acc-clientapikey", "uPEGhulfkwLSg8IofgWQcDU1bZ/9YuPKB40Fw99nRbJLwn1xnN/qf6Gujvu+oU8U");

                var response = client.SendAsync(reqMsg).Result;
                var content = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var contractors = JsonConvert.DeserializeObject<dynamic>(content);
                }
                else
                {
                    var err = content;
                }
            }
        }

        private static void HttpPostDemo()
        {
            // HTTP POST
            using (var client = new HttpClient())
            {
                var url = "http://localhost:51278/EREES-service/EREES/Execute";

                var payload = new
                {
                    ExternalIdKey = 46682,
                    EidStatus = "Disabled For Non-Compliance: Password Change"
                };

                var param = new
                {
                    Action = "deactivateenterpriseid",
                    Parameter = JsonConvert.SerializeObject(payload)
                };

                var json = JsonConvert.SerializeObject(param);
                var req = new HttpRequestMessage(HttpMethod.Post, url);
                req.Content = new StringContent(json, Encoding.UTF8, "application/json");
                req.Headers.Add("x-acc-clientid", "4d53bce03ec34c0a911182d4c228ee6c");
                req.Headers.Add("x-acc-clientapikey", "uPEGhulfkwLSg8IofgWQcDU1bZ/9YuPKB40Fw99nRbJLwn1xnN/qf6Gujvu+oU8U");

                var response = client.SendAsync(req).Result;
                var content = response.Content.ReadAsStringAsync().Result;

                if(response.IsSuccessStatusCode)
                {
                    // return response here.
                }
                else
                {
                    // return error here.
                }
            }
        }
    }
}
