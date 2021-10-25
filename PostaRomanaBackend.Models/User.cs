using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PostaRomanaBackend.Models
{
    public class User
    {
        public User()
        {
            EventXusers = new HashSet<EventXuser>();
            Registers = new HashSet<Register>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int? SessionId { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EventXuser> EventXusers { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
    }
}
