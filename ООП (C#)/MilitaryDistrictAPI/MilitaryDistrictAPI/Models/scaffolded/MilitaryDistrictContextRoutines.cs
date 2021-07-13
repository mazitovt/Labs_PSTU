using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MilitaryDistrictAPI.Models.routines;

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public partial class MilitaryDistrict2Context
    {
        public DbSet<Routine1> ResultRoutine1 { get; set; }
        public DbSet<Routine2> ResultRoutine2 { get; set; }
        public DbSet<Routine3> ResultRoutine3 { get; set; }
        public DbSet<Routine4> ResultRoutine4 { get; set; }
        public DbSet<Routine5> ResultRoutine5 { get; set; }
        public DbSet<Routine6> ResultRoutine6 { get; set; }
        public DbSet<Routine7> ResultRoutine7 { get; set; }
        public DbSet<Routine8> ResultRoutine8 { get; set; }
        
        public DbSet<Routine9> ResultRoutine9 { get; set; }
        
        public DbSet<Routine10> ResultRoutine10 { get; set; }
        
        public DbSet<Routine11> ResultRoutine11 { get; set; }
        
        public DbSet<Routine12> ResultRoutine12 { get; set; }
        
        public DbSet<Routine13> ResultRoutine13 { get; set; }
        
        protected virtual void ConfigureRoutines(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Routine1>().HasNoKey();

            modelBuilder.Entity<Routine1>(entity =>
                {
                    entity.Property(e => e.UnitId).HasColumnName("unit_id");
                    entity.Property(e => e.UnitName).HasColumnName("unit_name");
                    entity.Property(e => e.LeaderName).HasColumnName("leader_name");
                    entity.Property(e => e.Level).HasColumnName("level");
                }
            );


            modelBuilder.Entity<Routine2>().HasNoKey();
            modelBuilder.Entity<Routine3>().HasNoKey();
            modelBuilder.Entity<Routine4>().HasNoKey();

            modelBuilder.Entity<Routine4>(entity =>
                {
                    entity.Property(e => e.SoldierId).HasColumnName("soldier_id");
                    entity.Property(e => e.Name).HasColumnName("name");
                    entity.Property(e => e.LeaderId).HasColumnName("leader_id");
                }
            );

            modelBuilder.Entity<Routine5>().HasNoKey();
            modelBuilder.Entity<Routine6>().HasNoKey();
            modelBuilder.Entity<Routine7>().HasNoKey();
            modelBuilder.Entity<Routine8>().HasNoKey();
            modelBuilder.Entity<Routine9>().HasNoKey();
            modelBuilder.Entity<Routine10>().HasNoKey();
            modelBuilder.Entity<Routine11>().HasNoKey();
            modelBuilder.Entity<Routine12>().HasNoKey();
            modelBuilder.Entity<Routine13>().HasNoKey();

        }

        
        public IList ExecuteQuery(string routineName, params object[] parameters)
        {
            return routineName switch
            {
                Routine1.NAME => ResultRoutine1.FromSqlRaw(Routine1.SQL, parameters).ToList(),
                
                Routine2.NAME => ResultRoutine2.FromSqlRaw(Routine2.SQL, parameters).ToList(),
                
                Routine3.NAME => ResultRoutine3.FromSqlRaw(Routine3.SQL, parameters).ToList(),
                
                Routine4.NAME => ResultRoutine4.FromSqlRaw(Routine4.SQL, parameters).ToList(),
                
                Routine5.NAME => ResultRoutine5.FromSqlRaw(Routine5.SQL, parameters).ToList(),
                
                Routine6.NAME_1 => ResultRoutine6.FromSqlRaw(Routine6.SQL_1, parameters).ToList(),
                Routine6.NAME_2 => ResultRoutine6.FromSqlRaw(Routine6.SQL_2, parameters).ToList(),
                Routine6.NAME_3 => ResultRoutine6.FromSqlRaw(Routine6.SQL_3, parameters).ToList(),
                
                Routine7.NAME_1 => ResultRoutine7.FromSqlRaw(Routine7.SQL_1, parameters).ToList(),
                Routine7.NAME_2 => ResultRoutine7.FromSqlRaw(Routine7.SQL_2, parameters).ToList(),
                Routine7.NAME_3 => ResultRoutine7.FromSqlRaw(Routine7.SQL_3, parameters).ToList(),
                
                Routine8.NAME_1 => ResultRoutine8.FromSqlRaw(Routine8.SQL_1, parameters).ToList(),
                Routine8.NAME_2 => ResultRoutine8.FromSqlRaw(Routine8.SQL_2, parameters).ToList(),
                
                Routine9.NAME_1 => ResultRoutine9.FromSqlRaw(Routine9.SQL_1, parameters).ToList(),
                Routine9.NAME_2 => ResultRoutine9.FromSqlRaw(Routine9.SQL_2, parameters).ToList(),
                Routine9.NAME_3 => ResultRoutine9.FromSqlRaw(Routine9.SQL_3, parameters).ToList(),
                
                Routine10.NAME_1 => ResultRoutine10.FromSqlRaw(Routine10.SQL_1, parameters).ToList(),
                Routine10.NAME_2 => ResultRoutine10.FromSqlRaw(Routine10.SQL_2, parameters).ToList(),
                
                Routine11.NAME_1 => ResultRoutine11.FromSqlRaw(Routine11.SQL_1, parameters).ToList(),
                Routine11.NAME_2 => ResultRoutine11.FromSqlRaw(Routine11.SQL_2, parameters).ToList(),
                
                Routine12.NAME_1 => ResultRoutine12.FromSqlRaw(Routine12.SQL_1, parameters).ToList(),
                Routine12.NAME_2 => ResultRoutine12.FromSqlRaw(Routine12.SQL_2, parameters).ToList(),
                
                Routine13.NAME_1 => ResultRoutine13.FromSqlRaw(Routine13.SQL_1, parameters).ToList(),
                Routine13.NAME_2 => ResultRoutine13.FromSqlRaw(Routine13.SQL_2, parameters).ToList(),
                
                _ => throw new ArgumentOutOfRangeException(nameof(routineName), routineName, null)
            }; 
        }
    }
}