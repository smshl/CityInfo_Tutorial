namespace CityInfo.Api.Services
{
    public interface IMailService
    {
        void Send(string subject, string body);
    }
}