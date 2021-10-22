using MediatR;
using System;

namespace PostaRomanaBackend.PublishedLanguage.Commands
{
    public class EditEvent : IRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CountryId { get; set; }
        public int CountyId { get; set; }
        public int CityId { get; set; }
        public string AddressLine { get; set; }
        public decimal? Cost { get; set; }
        public int EventTypeId { get; set; }
        public int OrganizerId { get; set; }
    }
}
