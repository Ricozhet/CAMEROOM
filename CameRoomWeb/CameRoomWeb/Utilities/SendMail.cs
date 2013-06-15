using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CameRoomWeb.Utilities
{
    public class SendMail
    {
        public static bool sendEmail(string toEmail, string subject, string body, out string errMsg)
        {
            bool result = false;
            errMsg = "";
            try
            {
                var fromAddress = new MailAddress("all.more.aim@gmail.com", "Vesuvius");
                var toAddress = new MailAddress(toEmail, "Noob");
                const string fromPassword = "Vincent1717";
                //subject = "Subject";
                //body = "Body";

                var smtp = new SmtpClient
                           {
                               Host = "smtp.gmail.com",
                               Port = 587,
                               EnableSsl = true,
                               DeliveryMethod = SmtpDeliveryMethod.Network,
                               UseDefaultCredentials = false,
                               Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                           };
                using (var message = new MailMessage(fromAddress, toAddress)
                                     {
                                         Subject = subject,
                                         Body = body
                                     })
                {
                    smtp.Send(message);
                }
                result = true;
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }
            return result;
        }
    }
}