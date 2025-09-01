using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiTasks.DataBase;

public partial class DbAa6e7eTasksContext : DbContext
{
    public DbAa6e7eTasksContext()
    {
    }

    public DbAa6e7eTasksContext(DbContextOptions<DbAa6e7eTasksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TGroup> TGroups { get; set; }

    public virtual DbSet<TStatus> TStatuses { get; set; }

    public virtual DbSet<TTask> TTasks { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__T_Groups__3213E83F620223B0");

            entity.ToTable("T_Groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createat)
                .HasColumnType("datetime")
                .HasColumnName("createat");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icon");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.TGroups)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK__T_Groups__idStat__4BAC3F29");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TGroups)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__T_Groups__IdUser__4E88ABD4");
        });

        modelBuilder.Entity<TStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__T_Status__3213E83FA9EC1FE5");

            entity.ToTable("T_Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__T_Tasks__3213E83F377EB8A5");

            entity.ToTable("T_Tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createat)
                .HasColumnType("datetime")
                .HasColumnName("createat");
            entity.Property(e => e.Details)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.IdGroup).HasColumnName("idGroup");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Limitdate)
                .HasColumnType("datetime")
                .HasColumnName("limitdate");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.TTasks)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK__T_Tasks__idGroup__4AB81AF0");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.TTasks)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK__T_Tasks__idStatu__4CA06362");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TTasks)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__T_Tasks__idUser__49C3F6B7");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__T_Users__3213E83F4724BA0E");

            entity.ToTable("T_Users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createat)
                .HasColumnType("datetime")
                .HasColumnName("createat");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Idstatus).HasColumnName("idstatus");
            entity.Property(e => e.Lastlogindate)
                .HasColumnType("datetime")
                .HasColumnName("lastlogindate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Verified).HasColumnName("verified");

            entity.HasOne(d => d.IdstatusNavigation).WithMany(p => p.TUsers)
                .HasForeignKey(d => d.Idstatus)
                .HasConstraintName("FK__T_Users__idstatu__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
