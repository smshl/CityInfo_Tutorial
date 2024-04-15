using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

namespace CityInfo.Api.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailFrom;
        private readonly string _mailTo;

        public LocalMailService(IConfiguration configuration)
        {
            _mailFrom = configuration["MailAddresses:MailFrom"];
            _mailTo = configuration["MailAddresses:MailTo"];
        }


        public string mailFrom => _mailFrom;

        public string mailTo => _mailTo;


        public void Send(string subject, string body)
        {
            Console.WriteLine($"mail was sent from: {_mailFrom} to {_mailTo}");
            Console.WriteLine($"subject: {subject}");
            Console.WriteLine($"message: {body}, this email was sent from LocalMailService , from {_mailFrom} to {_mailTo}");
        }

        public static void SendEmail(string emailBody)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            string _mailFrom = "info@paidargroup.net";
            string _mailFromPass = "U}&hxp$aE(Bn1.a>8aw6";//Paidar
            string _mailTo = "s.muhammad.shojaee.l@gmail.com";

            message.From = new MailAddress(_mailFrom);
            message.To.Add(new MailAddress(_mailTo));
            message.Subject = "Important Message from Paidar";
            message.Body = emailBody;
            message.IsBodyHtml = true;
            message.CC.Add(new MailAddress("m.shojaee.langari@gmail.com"));

            smtp.Host = "mail.paidargroup.net";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_mailFrom, _mailFromPass);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(message);
        }
    }
}
