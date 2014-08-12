using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HIS_MobileApp.Services
{
    public static class EmailService
    {
        public static void SendMail(string msg)
        {
            
                MailMessage mail = new MailMessage();
                mail.To.Add(ConfigurationManager.AppSettings["ExceptionSendTo"]);

                mail.From = new MailAddress(ConfigurationManager.AppSettings["ExceptionSendTo"]);
                mail.Subject = "Exception Message";

                string Body = msg;
                mail.Body = Body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["SmtpHost"];
                smtp.Credentials = new System.Net.NetworkCredential
                     (ConfigurationManager.AppSettings["EmailUseName"], ConfigurationManager.AppSettings["EmailPassword"]);

                smtp.EnableSsl = true;
                smtp.Send(mail);            
        }
    }
}