using System.Runtime.CompilerServices;

namespace CityInfo.Api.Services
{
    public class PaidarMailService : IMailService
    {

        public void Send(string subject, string body)
        {
            Console.WriteLine($"subject: {subject}");
            Console.WriteLine($"message: {body}, this email was sent from PaidarMailService");
        }
    }
}
