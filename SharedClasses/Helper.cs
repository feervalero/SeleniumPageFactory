using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses
{
    public class Helper
    {
        /// <summary>
        /// Método para el envío de correos
        /// </summary>
        /// <param name="To"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="FromEmail"></param>
        /// <param name="EmailHeader"></param>
        /// <returns></returns>
        public bool SendEmail(string To, string Subject, string Body)
        {
            var result = true;

            var mailMessage = new MailMessage();
            mailMessage.To.Add(To);
            mailMessage.Subject = Subject;
            mailMessage.Body = Body;
            mailMessage.IsBodyHtml = true;
            //Despues se debe cambiar para ser configurable
            mailMessage.From = new MailAddress("fer.dev.valero@gmail.com", "Prueba");
            try
            {

                var client = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"))
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("fer.dev.valero@gmail.com", "IAS343073"),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mailMessage);
                client.Dispose();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
