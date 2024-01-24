using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Models;

public partial class DbfapproachContext : DbContext
{
    public DbfapproachContext()
    {
    }

    public DbfapproachContext(DbContextOptions<DbfapproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PayRoll> PayRolls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=dbfapproach;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PayRoll>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PayRoll__3213E83FD57360D5");

            entity.ToTable("PayRoll");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Deptname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptname");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Leavedays).HasColumnName("leavedays");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<MVC_Project.Models.UserDetail> UserDetail { get; set; } = default!;
}
