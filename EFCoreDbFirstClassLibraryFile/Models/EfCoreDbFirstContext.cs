using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreDbFirstClassLibraryFile.Models
{
    public partial class EfCoreDbFirstContext : DbContext
    {
        public EfCoreDbFirstContext()
        {
        }

        public EfCoreDbFirstContext(DbContextOptions<EfCoreDbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeEducation> EmployeeEducations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AMR2CQS\\MSSQLSERVER01;Initial Catalog=EfCoreDbFirst;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB9937B3F418");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpAddress).HasMaxLength(150);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeEducation>(entity =>
            {
                entity.HasKey(e => e.EduId)
                    .HasName("PK__Employee__84C108D260CBB4E7");

                entity.ToTable("EmployeeEducation");

                entity.Property(e => e.EduId).HasColumnName("eduId");

                entity.Property(e => e.EducationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeEducations)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmployeeE__EmpId__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
