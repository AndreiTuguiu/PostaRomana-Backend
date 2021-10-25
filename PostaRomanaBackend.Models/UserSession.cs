using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostaRomanaBackend.Models
{
    public class UserSession
    {
        
        public int Id { get; set; }
        public string SessionName { get; set; }
        public DateTime ValidTo { get; set; }

       
    }
}
