using Domain.Classes.AppDBClasses;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Persistence.DB
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        #region Сущности БД
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AdultPatient> AdultPatients { get; set; }
        public DbSet<AnthropometryOfPatient> AnthropometryOfPatients { get; set; }
        public DbSet<BirthCertificate> BirthCertificates { get; set; }
        public DbSet<BloodAnalysis> BloodAnalysises { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Lifestyle> Lifestyles { get; set; }
        public DbSet<LittlePatient> LittlePatients { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<RefreshToken> RefreshTokens { set; get; }
        public DbSet<LittlePatientAdultPatientMap> LittlePatientAdultPatientMaps { set; get; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Настройка отношений один-ко-многим между Employee и BloodAnalysis
            modelBuilder.Entity<Employee>()
                .HasMany(p => p.BloodAnalysises)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.EmployeeId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений один-ко-многим между Employee и RefreshTokens
            modelBuilder.Entity<Employee>()
                .HasMany(c => c.RefreshTokens)
                .WithOne(f => f.Employee)
                .OnDelete(DeleteBehavior.Cascade)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений PK-PK между AdultPatient и Passport
            modelBuilder.Entity<Passport>()
                .HasOne(p => p.AdultPatient)
                .WithOne(a => a.Passport)
                .HasForeignKey<Passport>(p => p.AdultPatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //Настройка отношений один-ко-многим между AdultPatient и Address
            modelBuilder.Entity<AdultPatient>()
                .HasMany(p => p.Addresses)
                .WithOne(r => r.AdultPatient)
                .HasForeignKey(r => r.PatientId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений один-ко-многим между AdultPatient и AnthropometryOfPatient
            modelBuilder.Entity<AdultPatient>()
                .HasMany(p => p.AnthropometryOfPatients)
                .WithOne(r => r.AdultPatient)
                .HasForeignKey(r => r.PatientId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade); ;

            //Настройка отношений один-ко-многим между AdultPatient и Lifestyle
            modelBuilder.Entity<AdultPatient>()
                .HasMany(p => p.Lifestyles)
                .WithOne(r => r.AdultPatient)
                .HasForeignKey(r => r.PatientId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений один-ко-многим между AdultPatient и BloodAnalysis
            modelBuilder.Entity<AdultPatient>()
                .HasMany(p => p.BloodAnalysises)
                .WithOne(r => r.AdultPatient)
                .HasForeignKey(r => r.PatientId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений PK-PK между LittlePatient и BirthCertificate
            modelBuilder.Entity<BirthCertificate>()
                .HasOne(p => p.LittlePatient)
                .WithOne(a => a.BirthCertificate)
                .HasForeignKey<BirthCertificate>(p => p.LittlePatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //Настройка отношений один-ко-многим между LittlePatient и Address
            modelBuilder.Entity<LittlePatient>()
                .HasMany(p => p.Addresses)
                .WithOne(r => r.LittlePatient)
                .HasForeignKey(r => r.PatientId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений один-ко-многим между LittlePatient и AnthropometryOfPatient
            modelBuilder.Entity<LittlePatient>()
                .HasMany(p => p.AnthropometryOfPatients)
                .WithOne(r => r.LittlePatient)
                .HasForeignKey(r => r.PatientId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений один-ко-многим между LittlePatient и Lifestyle
            modelBuilder.Entity<LittlePatient>()
                .HasMany(p => p.Lifestyles)
                .WithOne(r => r.LittlePatient)
                .HasForeignKey(r => r.PatientId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений один-ко-многим между LittlePatient и BloodAnalysis
            modelBuilder.Entity<LittlePatient>()
                .HasMany(p => p.BloodAnalysises)
                .WithOne(r => r.LittlePatient)
                .HasForeignKey(r => r.PatientId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Настройка отношений PK-PK между AdultPatient и LittlePatientAdultPatientMap
            modelBuilder.Entity<LittlePatientAdultPatientMap>()
                .HasOne(p => p.AdultPatient)
                .WithOne(a => a.LittlePatientAdultPatientMap)
                .HasForeignKey<LittlePatientAdultPatientMap>(p => p.AdultPatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //Настройка отношений PK-PK между LittlePatient и LittlePatientAdultPatientMap
            modelBuilder.Entity<LittlePatientAdultPatientMap>()
                .HasOne(p => p.LittlePatient)
                .WithOne(a => a.LittlePatientAdultPatientMap)
                .HasForeignKey<LittlePatientAdultPatientMap>(p => p.LittlePatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            //Настройка составного первичного ключа для LittlePatientAdultPatientMap
            modelBuilder.Entity<LittlePatientAdultPatientMap>()
                .HasKey(map => new { map.AdultPatientId, map.LittlePatientId });
        }
    }
}
