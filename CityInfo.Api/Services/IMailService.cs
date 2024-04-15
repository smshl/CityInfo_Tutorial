namespace CityInfo.Api.Services
{
    public interface IMailService
    {
        public string mailFrom { get; }
        public string mailTo { get; }
        void Send(string subject, string body);
    }
}