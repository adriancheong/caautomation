using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;

namespace CAAutomation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost("Notify")]
        public void Notify()
        {
            Notify("+6597738072", "+601117223073", "From C#!");
        }

        private static void Notify(string to, string from, string body)
        {
            string AccountSid = "AC745b14f8063bd0bbdc6e14bfd223a166";
            string AuthToken = "31d1c25104176b3fdade0b035e589c85";

            var client = new RestClient("https://api.twilio.com/2010-04-01/Accounts/AC745b14f8063bd0bbdc6e14bfd223a166/Messages");
            client.Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken);
            var request = new RestRequest(Method.POST);

            request.AddParameter("To", to);
            request.AddParameter("From", from);
            request.AddParameter("Body", body);

            var response = client.Execute(request);
        }
    }
}
