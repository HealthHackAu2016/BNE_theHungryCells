using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace HungryCells.Controllers
{
    public class SendSMSController : TwilioController
    {
        [HttpPost]
        public ActionResult Index(SmsRequest request)
        {
            var response = new TwilioResponse();
            response.Message("Thank you");
            return TwiML(response);
        }
    }


    //public class Example
    //{
    //    static void Main(string[] args)
    //    {
    //        // Find your Account Sid and Auth Token at twilio.com/user/account
    //        string AccountSid = "ACef8a7bddec12fb38bc28d2edcc943753";
    //        string AuthToken = "461e3d6e9c387f7772cf561b690b0850";
    //        var twilio = new TwilioRestClient(AccountSid, AuthToken);

    //        var message = twilio.SendMessage(
    //            "+61429528808", "+61435865949",
    //            "Hi On a scale of 1 to 10, how breathless are you feeling today?" +
    //            "(Where 1 is not troubled by breathless except on strenuous exercise and 10 is too breathless to leave the house)"
    //        );
    //        Console.WriteLine(message.Sid);
    //    }
    //}
}