using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Models
{
    public class UserSession
    {       
        public Guid Id { get; set; }
        public DateTime ValidTo { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}

