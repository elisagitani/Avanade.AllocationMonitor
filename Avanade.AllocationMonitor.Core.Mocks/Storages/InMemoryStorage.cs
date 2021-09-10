using Avanade.AllocationMonitor.Core.Entities;
using System;
using System.Collections.Generic;
using Avanade.AllocationMonitor.Core.Mocks.Storages.Extensions;
using Avanade.AllocationMonitor.Core.Enums;
using Avanade.AllocationMonitor.Core.Utils;

namespace Avanade.AllocationMonitor.Core.Mocks.Storages
{
    public class InMemoryStorage
    {
        #region Private static initialization
        /// <summary>
        /// Lazy loader for singleton storage instance
        /// </summary>
        private static Lazy<InMemoryStorage> _Default = new Lazy<InMemoryStorage>(Initialize);

        /// <summary>
        /// Initialize storage with scenario data
        /// </summary>
        /// <returns>Returns singleton instance</returns>
        private static InMemoryStorage Initialize() 
        {
            //Creo una nuova istanza "singleton" della classe
            var instance = new InMemoryStorage
            {
                //Inizializzo la lista di tutte le entità
                Dipendenti = new List<Dipendente>(),
                Attivitas = new List<Attivita>(),
                Clienti = new List<Cliente>(),
                Commesse = new List<Commessa>(),
                Timesheets = new List<Timesheet>(), 
                Assegnazioni = new List<Assegnazione>(), 
                Mansioni = new List<Mansione>(),
                Users = new List<User>()
            };

            #region Dipendenti
            //Inserisco i dati "finti" degli "Utenti"
            instance.GenerateIdentityAndPush(i => i.Users, new User
            {
                FirstName = "Mario",
                LastName = "Rossi",
                Email = "mario.rossi@icubed.it",
                IsEnabled = true,
                UserName = "mario.rossi",
                Password = "123456",
                IsAdministrator = true
            });
            instance.GenerateIdentityAndPush(i => i.Users, new User
            {
                FirstName = "Giuseppe",
                LastName = "Verdi",
                Email = "giuseppe.verdi@icubed.it",
                IsEnabled = true,
                UserName = "giuseppe.verdi",
                Password = "123456",
                IsAdministrator = false
            });
            #endregion

            #region Dipendenti
            //Inserisco i dati "finti" degli "Dipendenti"
            instance.GenerateIdentityAndPush(i => i.Dipendenti, new Dipendente
            {                                
                Nome = "Mario",
                Cognome = "Rossi",
                Email = "mario.rossi@icubed.it",
                CostoOrario = 10, 
                DataInizioProfessione = new DateTime(1999, 1,1), 
                DataNascita = new DateTime(1977, 1, 1), 
                Mansione = null
            });
            instance.GenerateIdentityAndPush(i => i.Dipendenti, new Dipendente
            {
                Email = "giuseppe.verdi@icubed.it",
                Nome = "Giuseppe",
                Cognome = "Verdi",
                CostoOrario = 10,
                DataInizioProfessione = new DateTime(1999, 1, 1),
                DataNascita = new DateTime(1977, 1, 1),
                Mansione = null
            });
            instance.GenerateIdentityAndPush(i => i.Dipendenti, new Dipendente
            {
                Email = "marco.bianchi@icubed.it",
                Nome = "Marco",
                Cognome = "Bianchi",
                CostoOrario = 10,
                DataInizioProfessione = new DateTime(1999, 1, 1),
                DataNascita = new DateTime(1977, 1, 1),
                Mansione = null
            });
            #endregion

            #region Clienti
            var vodafone = new Cliente
            {
                Nome = "Vodafone", 
                Citta ="Milano", 
                Provincia = "MI", 
                Regione = "Lombardia",
                Dimensione = DimensioneAzienda.Enterprise,
                EmailRiferimento = null, 
                NomeRiferimento = null
            };
            instance.GenerateIdentityAndPush(i => i.Clienti, vodafone);
            var monte = new Cliente
            {
                Nome = "Monte dei Paschi",
                Citta = "Siena",
                Provincia = "SI",
                Regione = "Toscana",
                Dimensione = DimensioneAzienda.Grande,
                EmailRiferimento = null,
                NomeRiferimento = null
            };
            instance.GenerateIdentityAndPush(i => i.Clienti, monte);
            var tim = new Cliente
            {
                Nome = "TIM",
                Citta = "Roma",
                Provincia = "RM",
                Regione = "Lazio",
                Dimensione = DimensioneAzienda.Grande,
                EmailRiferimento = null,
                NomeRiferimento = null
            };
            instance.GenerateIdentityAndPush(i => i.Clienti, tim);
            var parmalat = new Cliente
            {
                Nome = "Parmalat",
                Citta = "Parma",
                Provincia = "PR",
                Regione = "Emilia-Romagna",
                Dimensione = DimensioneAzienda.Enterprise,
                EmailRiferimento = null,
                NomeRiferimento = null
            };
            instance.GenerateIdentityAndPush(i => i.Clienti, parmalat);
            #endregion

            #region Commesse
            var portale = new Commessa
            {                
                Nome = "Sviluppo Portale",
                Cliente = vodafone, 
                Descrizione = null, 
                DataInizio = new DateTime(2021, 1, 1), 
                DataFineStimata = new DateTime(2021, 7, 1)
            };
            instance.GenerateIdentityAndPush(i => i.Commesse, portale);
            var android = new Commessa
            {
                Nome = "Applicazione Android",
                Cliente = tim,
                Descrizione = null,
                DataInizio = new DateTime(2021, 2, 1),
                DataFineStimata = new DateTime(2021, 10, 1)
            };
            instance.GenerateIdentityAndPush(i => i.Commesse, android);
            #endregion

            #region Attivita
            var portaleSenior = new Attivita
            {
                Nome = "Senior Developer .NET",
                Commessa = portale, 
                OrePreviste = 100, 
                FatturatoOrario = 50
            };
            instance.GenerateIdentityAndPush(i => i.Attivitas, portaleSenior);
            var portaleJunior = new Attivita
            {
                Nome = "Junior Developer .NET",
                Commessa = portale,
                OrePreviste = 100,
                FatturatoOrario = 50
            };
            instance.GenerateIdentityAndPush(i => i.Attivitas, portaleJunior);
            var mobileSenior = new Attivita
            {
                Nome = "Senior Developer .NET",
                Commessa = android,
                OrePreviste = 100,
                FatturatoOrario = 50
            };
            instance.GenerateIdentityAndPush(i => i.Attivitas, mobileSenior);
            var mobileJunior = new Attivita
            {
                Nome = "Junior Developer .NET",
                Commessa = android,
                OrePreviste = 100,
                FatturatoOrario = 50
            };
            instance.GenerateIdentityAndPush(i => i.Attivitas, mobileJunior);
            #endregion

            #region Timesheets

            //Fisso il random seed in modo da essere sicuro di ottenere
            //sempre le stesse informazioni pseudo-randomiche
            Random random = new Random(1234567890);

            //Iterazione di 100 timesheets
            for (var i = 0; i < 100; i++) 
            {
                //Selezione della attività
                var activity = RandomizationUtils.GetRandomElement(instance.Attivitas, random);
                var dipendente = RandomizationUtils.GetRandomElement(instance.Dipendenti, random);

                //Composizione del timesheet
                var timesheet = new Timesheet
                {
                    Attivita = activity, 
                    Dipendente = dipendente, 
                    DataReport = RandomizationUtils.GetRandomDate(
                        activity.Commessa.DataInizio, 
                        activity.Commessa.DataFineStimata, 
                        random), 
                    OreAllocate = random.Next(1, 8)
                };
                instance.GenerateIdentityAndPush(e => e.Timesheets, timesheet);
            }
            #endregion

            //Ritorno l'istanza
            return instance;
        }
        #endregion

        #region Public static methods
        /// <summary>
        /// Singleton instance of storage
        /// </summary>
        public static InMemoryStorage Default { get => _Default.Value; }
       
        /// <summary>
        /// Destroy singleton instance of storage
        /// </summary>
        public static void Destroy() 
        {
            //Ricreando il "lazy" di fatto elimino l'istanza in memoria del database
            //che sarà poi re-inizializzato alla prima chiamata
            _Default = new Lazy<InMemoryStorage>(Initialize);
        }
        #endregion
        
        /// <summary>
        /// Dipendenti
        /// </summary>
        public List<Dipendente> Dipendenti { get; private set; }

        /// <summary>
        /// Attivita
        /// </summary>
        public List<Attivita> Attivitas { get; private set; }

        /// <summary>
        /// Clineti
        /// </summary>
        public List<Cliente> Clienti { get; private set; }

        /// <summary>
        /// Timesheets
        /// </summary>
        public List<Timesheet> Timesheets { get; private set; }

        /// <summary>
        /// Commesse
        /// </summary>
        public List<Commessa> Commesse { get; private set; }

        /// <summary>
        /// Assegnazioni
        /// </summary>
        public IList<Assegnazione> Assegnazioni { get; set; }

        /// <summary>
        /// Mansioni
        /// </summary>
        public IList<Mansione> Mansioni { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public IList<User> Users { get; set; }
    }
}
