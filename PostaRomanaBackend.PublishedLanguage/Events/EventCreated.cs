using MediatR;

namespace RatingSystem.PublishedLanguage.Events
{
    public class EventCreated: INotification
    {
        public string Name { get; set; }
    }
}