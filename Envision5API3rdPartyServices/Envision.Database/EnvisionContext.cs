using Envision.Database.Mapping;
using Envision.Entity;
using Envision.Entity.AIResult;
using Envision.Entity.Result;
using Envision.Entity.Schedule;
using Microsoft.EntityFrameworkCore;

namespace Envision.Database
{
    public class EnvisionContext : DbContext
    {
        public DbSet<HrEmp> HrEmp { get; set; }
        public DbSet<HrJobTitle> HrJobTitle { get; set; }
        public DbSet<RisAuthLevel> RisAuthLevel { get; set; }
        public DbSet<GblRadExperience> GblRadExperience { get; set; }
        public DbSet<HrUnit> HrUnit { get; set; }
        public DbSet<RisServiceType> RisServiceType { get; set; }
        public DbSet<RisExamType> RisExamType { get; set; }
        public DbSet<RisExam> RisExam { get; set; }
        public DbSet<HisRegistration> HisRegistration { get; set; }
        public DbSet<RisClinicSession> RisClinicSession { get; set; }
        public DbSet<RisClinicType> RisClinicType { get; set; }
        // AI Result
        public DbSet<RisAIDetail> RisAIDetail { get; set; }
        // Schedules
        public DbSet<RisSchedule> RisSchedule { get; set; }
        public DbSet<RisScheduleDtl> RisScheduleDtl { get; set; }
        public DbSet<RisScheduleLogs> RisScheduleLogs { get; set; }
        public DbSet<RisScheduleLogsDtl> RisScheduleLogsDtl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=10.6.34.51;database=RIS_RAMA;uid=sa;pwd=mira@@1");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HR_EMP());
            modelBuilder.ApplyConfiguration(new HR_JOBTITLE());
            modelBuilder.ApplyConfiguration(new RIS_AUTHLEVEL());
            modelBuilder.ApplyConfiguration(new GBL_RADEXPERIENCE());
            modelBuilder.ApplyConfiguration(new HIS_REGISTRATION());
            modelBuilder.ApplyConfiguration(new HR_UNIT());
            modelBuilder.ApplyConfiguration(new RIS_SERVICETYPE());
            modelBuilder.ApplyConfiguration(new RIS_EXAMTYPE());
            modelBuilder.ApplyConfiguration(new RIS_EXAM());
            modelBuilder.ApplyConfiguration(new RIS_CLINICSESSION());
            modelBuilder.ApplyConfiguration(new RIS_CLINICTYPE());
            // AI Result
            modelBuilder.ApplyConfiguration(new RIS_AIDETAIL());
            //Schedules
            modelBuilder.ApplyConfiguration(new RIS_SCHEDULE());
            modelBuilder.ApplyConfiguration(new RIS_SCHEDULEDTL());
            modelBuilder.ApplyConfiguration(new RIS_SCHEDULELOGS());
            modelBuilder.ApplyConfiguration(new RIS_SCHEDULELOGSDTL());
        }
    }
}
