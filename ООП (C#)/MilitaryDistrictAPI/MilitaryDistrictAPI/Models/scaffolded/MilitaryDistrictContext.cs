using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MilitaryDistrictAPI.Models.routines;
using MilitaryDistrictAPI.Models;
using MilitaryDistrictAPI.Models.scaffolded;


#nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class MilitaryDistrict2Context : DbContext
    {
        
        public MilitaryDistrict2Context()
        {
        }

        public MilitaryDistrict2Context(DbContextOptions<MilitaryDistrict2Context> options)
            : base(options)
        {
            
        }
        
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<LocationType> LocationTypes { get; set; }
        public virtual DbSet<MilitaryRank> MilitaryRanks { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<Soldier> Soldiers { get; set; }
        // public virtual DbSet<SoldierOccupation> SoldierOccupations { get; set; }
        public virtual DbSet<SoldierRankInfo> SoldierRankInfos { get; set; }
        public virtual DbSet<Subunit> Subunits { get; set; }
        public virtual DbSet<SubunitType> SubunitTypes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitLocation> UnitLocations { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleCategory> VehicleCategories { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponCategory> WeaponCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=1234;database=military_district_2");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ConfigureRoutines(modelBuilder);

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("building");

                entity.HasIndex(e => e.UnitId, "fk_building_unit1_idx");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.NumberOfLivingSubunits).HasColumnName("number_of_living_subunits");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_building_unit1");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("location_type");

                entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MilitaryRank>(entity =>
            {
                entity.ToTable("military_rank");

                entity.Property(e => e.MilitaryRankId).HasColumnName("military_rank_id");

                entity.Property(e => e.CommandHigherUnit).HasColumnName("command_higher_unit");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.RankGroup)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("rank_group");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.ToTable("occupation");

                entity.Property(e => e.OccupationId).HasColumnName("occupation_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Soldier>(entity =>
            {
                entity.ToTable("soldier");

                entity.HasIndex(e => e.MilitaryRankId, "fk_soldier_military_rank1_idx");

                entity.HasIndex(e => e.LeaderId, "fk_soldier_soldier1_idx");

                entity.HasIndex(e => e.RankInfoId, "fk_soldier_soldier_rank_info1_idx");

                entity.HasIndex(e => e.ServingSubunitId, "fk_soldier_subunit1_idx");

                entity.HasIndex(e => e.ServingUnitId, "fk_soldier_unit1_idx");

                entity.Property(e => e.SoldierId).HasColumnName("soldier_id").ValueGeneratedOnAdd();

                entity.Property(e => e.LeaderId).HasColumnName("leader_id");

                entity.Property(e => e.MilitaryRankId).HasColumnName("military_rank_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.RankInfoId).HasColumnName("rank_info_id");

                entity.Property(e => e.ServingSubunitId).HasColumnName("serving_subunit_id");

                entity.Property(e => e.ServingUnitId).HasColumnName("serving_unit_id");


                entity.HasMany(p => p.Occupations)
                    .WithMany(p => p.Soldiers)
                    .UsingEntity<Dictionary<string, object>>(
                        "soldier_occupation",
                        j => j
                            .HasOne<Occupation>()
                            .WithMany()
                            .HasForeignKey("occupation_id")
                            .OnDelete(DeleteBehavior.Cascade),
                        j => j
                            .HasOne<Soldier>()
                            .WithMany()
                            .HasForeignKey("soldier_id")
                            .OnDelete(DeleteBehavior.ClientCascade));
                

                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.InverseLeader)
                    .HasForeignKey(d => d.LeaderId)
                    .HasConstraintName("fk_soldier_soldier1");

                entity.HasOne(d => d.MilitaryRank)
                    .WithMany(p => p.Soldiers)
                    .HasForeignKey(d => d.MilitaryRankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soldier_military_rank1");

                entity.HasOne(d => d.RankInfo)
                    .WithMany(p => p.Soldiers)
                    .HasForeignKey(d => d.RankInfoId)
                    .HasConstraintName("fk_soldier_soldier_rank_info1");

                entity.HasOne(d => d.ServingSubunit)
                    .WithMany(p => p.Soldiers)
                    .HasForeignKey(d => d.ServingSubunitId)
                    .HasConstraintName("fk_soldier_subunit1");

                entity.HasOne(d => d.ServingUnit)
                    .WithMany(p => p.Soldiers)
                    .HasForeignKey(d => d.ServingUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soldier_unit1");
            });

            
            
            modelBuilder.Entity<SoldierRankInfo>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PRIMARY");
            
                entity.ToTable("soldier_rank_info");
            
                entity.Property(e => e.RecordId).HasColumnName("record_id");
            
                entity.Property(e => e.DateOfGraduation)
                    .HasColumnType("date")
                    .HasColumnName("date_of_graduation");
            
                entity.Property(e => e.DateOfPromotion)
                    .HasColumnType("date")
                    .HasColumnName("date_of_promotion");
            });

            modelBuilder.Entity<Subunit>(entity =>
            {
                entity.ToTable("subunit");
            
                entity.HasIndex(e => e.LeaderId, "fk_subunit_soldier1_idx");
            
                entity.HasIndex(e => e.SubunitTypeId, "fk_subunit_subunit_type1_idx");
            
                entity.HasIndex(e => e.ParentUnitId, "fk_subunit_unit1_idx");
            
                entity.Property(e => e.SubunitId).HasColumnName("subunit_id").ValueGeneratedOnAdd();
            
                entity.Property(e => e.LeaderId).HasColumnName("leader_id");
            
                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            
                entity.Property(e => e.ParentUnitId).HasColumnName("parent_unit_id");
            
                entity.Property(e => e.SubunitTypeId).HasColumnName("subunit_type_id");
            
                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.Subunits)
                    .HasForeignKey(d => d.LeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subunit_soldier1");
            
                entity.HasOne(d => d.ParentUnit)
                    .WithMany(p => p.Subunits)
                    .HasForeignKey(d => d.ParentUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subunit_unit1");
            
                entity.HasOne(d => d.SubunitType)
                    .WithMany(p => p.Subunits)
                    .HasForeignKey(d => d.SubunitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subunit_subunit_type1");
            });

            modelBuilder.Entity<SubunitType>(entity =>
            {
                entity.ToTable("subunit_type");

                entity.Property(e => e.SubunitTypeId).HasColumnName("subunit_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit");

                entity.HasIndex(e => e.LeaderId, "fk_unit_soldier1_idx");

                entity.HasIndex(e => e.UnitTypeId, "fk_unit_type_idx");

                entity.HasIndex(e => e.ParentUnitId, "fk_unit_unit1_idx");

                entity.Property(e => e.UnitId).HasColumnName("unit_id").ValueGeneratedOnAdd();

                entity.Property(e => e.LeaderId).HasColumnName("leader_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.ParentUnitId).HasColumnName("parent_unit_id");

                entity.Property(e => e.UnitNumber)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("unit_number");

                entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");

                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.LeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unit_soldier1");

                entity.HasOne(d => d.ParentUnit)
                    .WithMany(p => p.InverseParentUnit)
                    .HasForeignKey(d => d.ParentUnitId)
                    .HasConstraintName("fk_unit_unit1");

                entity.HasOne(d => d.UnitType)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.UnitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_unit_type_id");
            });

            modelBuilder.Entity<UnitLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("unit_location");

                entity.HasIndex(e => e.UnitId, "fk_location_id");

                entity.HasIndex(e => e.LocationTypeId, "fk_location_type_id");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("location_name");

                entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.LocationType)
                    .WithMany()
                    .HasForeignKey(d => d.LocationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location_location_type");

                entity.HasOne(d => d.Unit)
                    .WithMany()
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location_unit");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.ToTable("unit_type");

                entity.Property(e => e.UnitTypeId).HasColumnName("unit_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");

                entity.HasIndex(e => e.VehicleCategoryId, "fk_vehicle_vehicle_category1_idx");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.VehicleCategoryId).HasColumnName("vehicle_category_id");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehicle_vehicle_category1");
            });

            modelBuilder.Entity<VehicleCategory>(entity =>
            {
                entity.ToTable("vehicle_category");

                entity.HasIndex(e => e.UnitId, "fk_vehicle_category_unit1_idx");

                entity.Property(e => e.VehicleCategoryId).HasColumnName("vehicle_category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.VehicleCategories)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehicle_category_unit1");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.ToTable("weapon");

                entity.HasIndex(e => e.WeaponCategoryId, "fk_weapon_weapon_category1_idx");

                entity.Property(e => e.WeaponId).HasColumnName("weapon_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.WeaponCategoryId).HasColumnName("weapon_category_id");

                entity.HasOne(d => d.WeaponCategory)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_weapon_weapon_category1");
            });

            modelBuilder.Entity<WeaponCategory>(entity =>
            {
                entity.ToTable("weapon_category");

                entity.HasIndex(e => e.UnitId, "fk_weapon_category_unit1_idx");

                entity.Property(e => e.WeaponCategoryId).HasColumnName("weapon_category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.WeaponCategories)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_weapon_category_unit1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
