using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpiritLink.Data;

namespace SpiritLink.Models;

public partial class AtonsuDbContext : identityDbContext
{

    public AtonsuDbContext(DbContextOptions<AtonsuDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BacentaLeader> BacentaLeaders { get; set; }

    public virtual DbSet<FirstTimer> FirstTimers { get; set; }

    public virtual DbSet<LaySchool> LaySchools { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<NewConvert> NewConverts { get; set; }

    public virtual DbSet<Pastor> Pastors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => e.UserId);
        });
        
        modelBuilder.Entity<BacentaLeader>(entity =>
        {
            entity.HasKey(e => new { e.LeaderName, e.LeaderId, e.PastorName })
                .HasName("PK4")
                .IsClustered(false);

            entity.ToTable("BacentaLeader");

            entity.Property(e => e.LeaderName).HasMaxLength(100);
            entity.Property(e => e.LeaderId).ValueGeneratedOnAdd();
            entity.Property(e => e.PastorName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);

            entity.HasOne(d => d.PastorNameNavigation).WithMany(p => p.BacentaLeaders)
                .HasForeignKey(d => d.PastorName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefPastor7");
        });

        modelBuilder.Entity<FirstTimer>(entity =>
        {
            entity.HasKey(e => e.FirstTimerName)
                .HasName("PK5")
                .IsClustered(false);

            entity.Property(e => e.FirstTimerName).HasMaxLength(100);
            entity.Property(e => e.AreaDescription).HasMaxLength(1000);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.GpsAddress)
                .HasMaxLength(12)
                .HasColumnName("GPS Address");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(256);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.WhoInvited).HasMaxLength(50);
        });

        modelBuilder.Entity<LaySchool>(entity =>
        {
            entity.HasKey(e => new { e.SchoolName, e.SchoolId, e.PastorName, e.MemberName, e.ConvertName, e.FirstTimerName, e.LeaderId, e.LeaderName })
                .HasName("PK8")
                .IsClustered(false);

            entity.ToTable("LaySchool");

            entity.Property(e => e.SchoolName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SchoolId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PastorName).HasMaxLength(100);
            entity.Property(e => e.MemberName).HasMaxLength(100);
            entity.Property(e => e.ConvertName).HasMaxLength(100);
            entity.Property(e => e.FirstTimerName).HasMaxLength(100);
            entity.Property(e => e.LeaderName).HasMaxLength(100);
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.PastorNameNavigation).WithMany(p => p.LaySchools)
                .HasForeignKey(d => d.PastorName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefPastor6");

            entity.HasOne(d => d.BacentaLeader).WithMany(p => p.LaySchools)
                .HasForeignKey(d => new { d.LeaderName, d.LeaderId, d.PastorName })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefBacentaLeader13");

            entity.HasOne(d => d.Member).WithMany(p => p.LaySchools)
                .HasForeignKey(d => new { d.MemberName, d.PastorName, d.ConvertName, d.FirstTimerName })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefMembers11");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => new { e.MemberName, e.PastorName, e.ConvertName, e.FirstTimerName })
                .HasName("PK7")
                .IsClustered(false);

            entity.Property(e => e.MemberName).HasMaxLength(100);
            entity.Property(e => e.PastorName).HasMaxLength(100);
            entity.Property(e => e.ConvertName).HasMaxLength(100);
            entity.Property(e => e.FirstTimerName).HasMaxLength(100);
            entity.Property(e => e.AreaDescription).HasMaxLength(1000);
            entity.Property(e => e.Basonta).HasMaxLength(60);
            entity.Property(e => e.Gpsaddress)
                .HasMaxLength(50)
                .HasColumnName("GPSAddress");
            entity.Property(e => e.Location).HasMaxLength(60);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);

            entity.HasOne(d => d.ConvertNameNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.ConvertName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefNewConverts9");

            entity.HasOne(d => d.FirstTimerNameNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.FirstTimerName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefFirstTimers10");

            entity.HasOne(d => d.PastorNameNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.PastorName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefPastor8");
        });

        modelBuilder.Entity<NewConvert>(entity =>
        {
            entity.HasKey(e => e.ConvertName)
                .HasName("PK6")
                .IsClustered(false);

            entity.Property(e => e.ConvertName).HasMaxLength(100);
            entity.Property(e => e.AreaDescription).HasMaxLength(1000);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Gpsaddress)
                .HasMaxLength(50)
                .HasColumnName("GPSAddress");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.WhoInvited).HasMaxLength(100);
        });

        modelBuilder.Entity<Pastor>(entity =>
        {
            entity.HasKey(e => e.PastorName)
                .HasName("PK3")
                .IsClustered(false);

            entity.ToTable("Pastor");

            entity.Property(e => e.PastorName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.PasswordHash).HasMaxLength(1000);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
