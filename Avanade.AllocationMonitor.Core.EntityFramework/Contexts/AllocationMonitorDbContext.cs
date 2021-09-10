using Avanade.AllocationMonitor.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avanade.AllocationMonitor.Terminal.Contexts
{
    public class AllocationMonitorDbContext: DbContext
    {
        public DbSet<Dipendente> Dipendenti { get; set; }

        public DbSet<Mansione> Mansioni { get; set; }

        public DbSet<Cliente> Clienti { get; set; }

        public DbSet<Commessa> Commesse { get; set; }

        public DbSet<Attivita> Attivitas { get; set; }

        public DbSet<Assegnazione> Assegnazioni { get; set; }

        public DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //*** INSTRUCTIONS
            // dotnet tool install--global dotnet-ef--version 3.1.13
            // Go on project folder where is located EntityFramework DbContext 
            // using command prompt (cmd or PowerShell) and type:
            //
            // > dotnet add package Microsoft.EntityFrameworkCore.Design
            // > dotnet restore
            //
            // If everything is installed correctly, you should see a confirm after
            // > dotnet ef
            //
            // Create an executable project (ex. .NET Core Console) that will be used 
            // as entry point for migrations (ex. Avanade.AllocationMonitor.Terminal), then type:
            // 
            // > dotnet ef migrations add InitialMigration --startup-project ../Avanade.AllocationMonitor.Terminal/Avanade.AllocationMonitor.Terminal.csproj
            //
            // Generate SQL scripts using the following command: 
            //
            // > dotnet ef migrations script --startup-project ../Avanade.AllocationMonitor.Terminal/Avanade.AllocationMonitor.Terminal.csproj -o script.sql
            //
            // File "script.sql" will be generate on Avanade.AllocationMonitor.Terminal folder

            //Stringa di connessione, lazy loading e inizializzazione
            optionsBuilder
                .UseSqlServer("Data Source=localhost;Initial Catalog=ALLOCATIONMONITOR;User ID=sa;Password=P@ssw0rd;trusted_connection=false;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mappatura delle singole entità
            modelBuilder.Entity<Mansione>().ToTable("Mansioni");
            modelBuilder.Entity<Dipendente>().ToTable("Dipendenti");
            modelBuilder.Entity<Cliente>().ToTable("Clienti");
            modelBuilder.Entity<Commessa>().ToTable("Commesse");
            modelBuilder.Entity<Attivita>().ToTable("Attivitas");
            modelBuilder.Entity<Assegnazione>().ToTable("Assegnazioni");
            modelBuilder.Entity<Timesheet>().ToTable("Timesheets");

            //Mappatura base
            base.OnModelCreating(modelBuilder);
        }
    }
}
