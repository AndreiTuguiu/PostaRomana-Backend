using System;
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
            UserSessions = new HashSet<UserSession>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EventXuser> EventXusers { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
        public virtual ICollection<UserSession> UserSessions { get; set; }



    }
}
