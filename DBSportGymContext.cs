using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Sport
{
    public partial class DBSportGymContext : DbContext
    {
        public DBSportGymContext()
        {
        }

        public DBSportGymContext(DbContextOptions<DBSportGymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<Pass> Passes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SCYRITYS\\server; Database = DBSportGym; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.TrainerId).HasColumnName("Trainer_id");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK_Clients_Trainers");
            });

            modelBuilder.Entity<Gym>(entity =>
            {
                entity.Property(e => e.Area).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Pass>(entity =>
            {
                entity.Property(e => e.GymId).HasColumnName("Gym_id");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.Passes)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passes_Gyms");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.ClCardNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Cl_Card_Number")
                    .IsFixedLength(true);

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.CompanyCardNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Company_Card_Number")
                    .IsFixedLength(true);

                entity.Property(e => e.IsDebt).HasColumnName("Is_Debt");

                entity.Property(e => e.IsOverPay).HasColumnName("Is_OverPay");

                entity.Property(e => e.IsPaymentDone).HasColumnName("Is_Payment_Done");

                entity.Property(e => e.Month)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassesId).HasColumnName("Passes_Id");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Clients");

                entity.HasOne(d => d.Passes)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PassesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Passes");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
