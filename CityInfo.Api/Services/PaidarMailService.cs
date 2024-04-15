using System.Runtime.CompilerServices;

namespace CityInfo.Api.Services
{
    public class PaidarMailService : IMailService
    {
        private readonly string _mailFrom;
        private readonly string _mailTo;

        public PaidarMailService(IConfiguration configuration)
        {
            _mailFrom = configuration["MailAddresses:MailFrom"];
            _mailTo = configuration["MailAddresses:MailTo"];
        }
        public string mailFrom => _mailFrom;

        public string mailTo => _mailTo;

        public void Send(string subject, string body)
        {
            Console.WriteLine($"subject: {subject}");
            Console.WriteLine($"message: {body}, this email was sent from PaidarMailService , from {_mailFrom} to {_mailTo}");
        }
    }
}
