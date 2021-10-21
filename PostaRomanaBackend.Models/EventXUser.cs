#nullable disable

namespace PostaRomanaBackend.Models
{
    public partial class EventXuser
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
