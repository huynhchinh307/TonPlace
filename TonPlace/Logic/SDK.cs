using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace
{
    public static class SDK
    {
        public static string RapidAPI_Twitter { get; set; }
        public static string RapidAPI_Mail { get; set; }

        public static Mails Call_Create_Mai()
        {
            var client = new RestClient("https://temp-mail44.p.rapidapi.com/api/v3/email/new");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-RapidAPI-Key", RapidAPI_Mail);
            request.AddHeader("X-RapidAPI-Host", "temp-mail44.p.rapidapi.com");
            var restResponse = client.Execute<Mails>(request);
            if (restResponse.IsSuccessful)
            {
                return restResponse.Data;
            }
            else
            {
                return null;
            }

        }

        public static List<Inbox> Call_Read_Inbox(string mail)
        {
            var client = new RestClient("https://temp-mail44.p.rapidapi.com/api/v3/email/"+mail+"/messages");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-RapidAPI-Key", RapidAPI_Mail);
            request.AddHeader("X-RapidAPI-Host", "temp-mail44.p.rapidapi.com");
            var restResponse = client.Execute<List<Inbox>>(request);
            if (restResponse.IsSuccessful)
            {
                return restResponse.Data;
            }
            else
            {
                return null;
            }

        }
    }

    public class Mails
    {
        public string email { get; set; }
        public string token { get; set; }
    }

    public class Inbox
    {
        public string id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public object cc { get; set; }
        public string subject { get; set; }
        public string body_text { get; set; }
        public string body_html { get; set; }
        public string created_at { get; set; }
    }
}
