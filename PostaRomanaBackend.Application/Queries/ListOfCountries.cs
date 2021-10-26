using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Application.Queries
{
    public class ListOfCountries
    {
        public class Query : IRequest<List<Model>>
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }



        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int LocationId { get; set; }
            public int OrganizerId { get; set; }
            public decimal? Cost { get; set; }
            public int EventTypeId { get; set; }
        }
    }
}
