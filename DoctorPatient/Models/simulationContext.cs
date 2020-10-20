using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoctorPatient.Models
{
    public partial class simulationContext : DbContext
    {

        public simulationContext(DbContextOptions<simulationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId)
                    .HasColumnName("BookingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfbooking)
                    .HasColumnName("DateOFBooking")
                    .HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Booking__DoctorI__1920BF5C");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Booking__Patient__182C9B23");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId)
                    .HasColumnName("DoctorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dname)
                    .IsRequired()
                    .HasColumnName("DName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Special)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Disease)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasColumnName("PName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4CC1CA13C0");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
