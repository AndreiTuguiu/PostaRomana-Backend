using MediatR;

namespace PostaRomanaBackend.PublishedLanguage.Events
{
    public class AccountMade: INotification
    {
        public string Name { get; set; }
    }
}