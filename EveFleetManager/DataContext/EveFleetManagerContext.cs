using EveFleetManager.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EveFleetManager.DataContext
{
    public partial class EveFleetManagerContext : DbContext
    {
        public EveFleetManagerContext()
        {
        }

        public EveFleetManagerContext(DbContextOptions<EveFleetManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fleet> Fleet { get; set; }
        public virtual DbSet<FleetDetail> FleetDetail { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=tcp:evefleetmanager.database.windows.net,1433;Initial Catalog=EveFleetManager;Persist Security Info=False;User ID=efmadmin;Password=BaconPancakes1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            //modelBuilder.Entity<Fleet>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.HasOne(d => d.Commander)
            //        .WithMany(p => p.Fleet)
            //        .HasForeignKey(d => d.CommanderId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_FleetCommander_User");
            //});

            //modelBuilder.Entity<FleetDetail>(entity =>
            //{
            //    entity.HasKey(e => new { e.CharacterId, e.FleetId });

            //    entity.Property(e => e.SharePercentage)
            //        .HasColumnType("decimal(3, 2)")
            //        .HasDefaultValueSql("((1.00))");

            //    entity.HasOne(d => d.Character)
            //        .WithMany(p => p.FleetDetail)
            //        .HasForeignKey(d => d.CharacterId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_FleetDetail_User");

            //    entity.HasOne(d => d.Fleet)
            //        .WithMany(p => p.FleetDetail)
            //        .HasForeignKey(d => d.FleetId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_FleetDetail_Fleet");
            //});

            //modelBuilder.Entity<Session>(entity =>
            //{
            //    entity.HasKey(e => e.CharacterId);

            //    entity.Property(e => e.CharacterId).ValueGeneratedNever();

            //    entity.Property(e => e.SessionId).IsRequired();
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasKey(e => e.CharacterId);

            //    entity.Property(e => e.CharacterId).ValueGeneratedNever();

            //    entity.Property(e => e.BearerToken).IsRequired();

            //    entity.Property(e => e.Name).IsRequired();

            //    entity.Property(e => e.RefreshToken).IsRequired();
            //});
        }
    }
}
