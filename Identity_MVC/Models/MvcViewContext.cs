using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_MVC.Models;

public  class MvcViewContext : IdentityDbContext<ApplicationUser>
{
    public MvcViewContext()
    {
    }

    public MvcViewContext(DbContextOptions<MvcViewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ESLAMEED00;Initial Catalog=MVC_View;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DepId).HasColumnName("DepID");

            entity.HasOne(d => d.Dep).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepId)
                .HasConstraintName("FK_DEP_COURSE");

           
        });


        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.HasIndex(e => e.DepartmentId, "IX_Student_DepartmentId");

            entity.HasOne(d => d.Department).WithMany(p => p.Students).HasForeignKey(d => d.DepartmentId);
        });

        OnModelCreating(modelBuilder);
    }

    
}
