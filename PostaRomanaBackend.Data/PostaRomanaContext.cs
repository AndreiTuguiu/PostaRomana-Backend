using Microsoft.EntityFrameworkCore;
using PostaRomanaBackend.Models;

#nullable disable

namespace PostaRomanaBackend.Data
{
    public partial class PostaRomanaContext : DbContext
    {

        public PostaRomanaContext(DbContextOptions<PostaRomanaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventXuser> EventXusers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TS1678\\SQLEXPRESS,1091;Database=PostaRomana;Trusted_Connection=False;User Id=Internship;Password=123;MultipleActiveResultSets=true");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Locations");
            });

            modelBuilder.Entity<EventXuser>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.UserId });

                entity.ToTable("EventXUser");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventXusers)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventXUser_Events");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventXusers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventXUser_Users");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.AddressLine).HasMaxLength(50);
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("Register");

                entity.Property(e => e.Id);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.TokenStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Register_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SessionId);


            });

            modelBuilder.Entity<UserSession>(entity =>
            {

                entity.ToTable("UserSessions");

                entity.HasIndex(e => e.Id, "UQ_SessionId")
                            .IsUnique();

                entity.Property(e => e.SessionName)
                            .IsRequired()
                            .HasMaxLength(50);
                entity.Property(e => e.ValidTo).HasColumnType("datetime");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
