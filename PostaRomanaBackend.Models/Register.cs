using System;

#nullable disable

namespace PostaRomanaBackend.Models
{
    public partial class Register
    {
        public int Id { get; set; }
        public string TokenStatus { get; set; }
        public DateTime ValidTo { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public virtual User User { get; set; }
    }
}
