using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApiQUizz.Services
{
    public class RecaptchaService: IRecaptchaService
    {
        public string ValidateInvOkeRecaptcha()
        {
            const string secretKey = "6LeGCjgUAAAAAJHJmkzfNks3tD5E7J4yMCp_qnSG";
            string responseFromServer = "";
            string response = "6LeGCjgUAAAAAAhsJfMLEDwg1FZ3S4beK2Aq6Fpa";
            string clientKey = "6LeGCjgUAAAAAAhsJfMLEDwg1FZ3S4beK2Aq6Fpa";
            //var response = Request["g-recaptcha-response"];
            //  string secretKey = "my key";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=" + secretKey + "&response=" + response);

            using (WebResponse resp = req.GetResponse())
            using (Stream dataStream = resp.GetResponseStream())
            {
                if (dataStream != null)
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content.
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }
            var client = new WebClient();
            var result = client.DownloadString(
          $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}");
            var obj = JObject.Parse(result);
            var model = (bool)obj.SelectToken("success");
          
             var demo= VerifyCaptcha(secretKey, response);

            dynamic jsonResponse = new JavaScriptSerializer().DeserializeObject(responseFromServer);

            return jsonResponse == null || bool.Parse(jsonResponse["success"].ToString());
        }

        void ValidateInvoke222(HttpRequest Request)
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LeGCjgUAAAAAJHJmkzfNks3tD5E7J4yMCp_qnSG";
            var client = new WebClient();
            var result = client.DownloadString(
            $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}");
            var obj = JObject.Parse(result);
            var model = (bool)obj.SelectToken("success");
        }

        public static ReCaptchaResponse VerifyCaptcha(string secret, string response)
        {
            //    if (request != null)
            //    {
            ReCaptchaResponse responses;

                using (System.Net.Http.HttpClient hc = new System.Net.Http.HttpClient())
                {
                    var values = new Dictionary<string,
                        string> {
                        {
                            "secret",
                            secret
                        },
                        {
                            "response",
                            response
                        }
                    };
                    var content = new System.Net.Http.FormUrlEncodedContent(values);
                    var Response = hc.PostAsync("https: //www.google.com/recaptcha/api/siteverify", content).Result;  
                        var responseString = Response.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrWhiteSpace(responseString))
                    {
                         responses = JsonConvert.DeserializeObject<ReCaptchaResponse>(responseString);
                        return responses;
                    }
                   
                    //Throw error as required  
                }
            return null;
           
        }
    }

    public class ReCaptchaResponse
    {
        public bool success
        {
            get;
            set;
        }
        public string challenge_ts
        {
            get;
            set;
        }
        public string hostname
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "error-codes")]
        public List<string> error_codes
        {
            get;
            set;
        }
    }
}