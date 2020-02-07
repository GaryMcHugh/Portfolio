using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using myMvcApp.Models;

namespace myMvcApp.Controllers
{
    public class EmailController : Controller
    {
        // POST: /Email/SendEmail
        [HttpPost]
        public string SendEmail(string name, string email, string phone, string message)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential("emailAddress", "password");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("noreply@garymchugh.com"),
                    Subject = "Website Contact Form",
                    Body = "You have received a new message from your website contact form.<br />" +
                           "Here are the details:<br />Name:" + name + "<br />Email: " + email + "<br />Phone:" + phone +
                           "<br />Message:<br />" + message + "; "
                };

                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("emailAddress"));
                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
                return "Email Sent Successfully!";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }
        }
    }
}