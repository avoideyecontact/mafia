using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Persistance;

public partial class MafiaContext : DbContext
{
    public MafiaContext()
    {
    }

    public MafiaContext(DbContextOptions<MafiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FamilyMember> FamilyMembers { get; set; }

    public virtual DbSet<MafiaFamily> MafiaFamilies { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<OrganizationType> OrganizationTypes { get; set; }

    public virtual DbSet<RankType> RankTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost; Port=5432; DataBase=Mafia; Integrated Security=false; User ID=postgres; Password=super");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FamilyMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("FamilyMembers_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.MafiaFamilyId).HasColumnName("MafiaFamily_ID");
            entity.Property(e => e.RankId).HasColumnName("Rank_ID");
            entity.Property(e => e.SecondName).HasMaxLength(50);

            entity.HasOne(d => d.MafiaFamily).WithMany(p => p.FamilyMembers)
                .HasForeignKey(d => d.MafiaFamilyId)
                .HasConstraintName("FamilyMembers_MafiaFamily_ID_fkey");

            entity.HasOne(d => d.Rank).WithMany(p => p.FamilyMembers)
                .HasForeignKey(d => d.RankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FamilyMembers_Rank_ID_fkey");
        });

        modelBuilder.Entity<MafiaFamily>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MafiaFamilies_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(300)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Organizations_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CollectorId).HasColumnName("Collector_Id");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(300)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OrganizationTypeId).HasColumnName("OrganizationType_Id");

            entity.HasOne(d => d.Collector).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.CollectorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Organizations_Collector_Id_fkey");

            entity.HasOne(d => d.OrganizationType).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.OrganizationTypeId)
                .HasConstraintName("Organizations_OrganizationType_Id_fkey");
        });

        modelBuilder.Entity<OrganizationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("OrganizationTypes_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RankType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RankTypes_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
