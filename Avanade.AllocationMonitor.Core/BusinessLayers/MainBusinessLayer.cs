using Avanade.AllocationMonitor.Core.DependencyContainers;
using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Enums;
using Avanade.AllocationMonitor.Core.Repositories;
using Avanade.AllocationMonitor.Core.Structures;
using Avanade.AllocationMonitor.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.Core.BusinessLayers
{
    public class MainBusinessLayer: BusinessLayerBase
    {
        #region Public properties
        public IAttivitaRepository AttivitaRepository { get; set; }
        public IClienteRepository ClienteRepository { get; set; }
        public ICommessaRepository CommessaRepository { get; set; }
        public IDipendenteRepository DipendenteRepository { get; set; }
        public ITimesheetRepository TimesheetRepository { get; set; }
        #endregion

        public MainBusinessLayer() 
        {
            //Utilizzo la reflection per eseguire
            //la risoluzione di tutti i repository pubblici
            FillRepositories();

            //** VERSIONE CLASSICA => inizializzazione di tutti i repo
            //AttivitaRepository = DependencyContainer.Resolve<IAttivitaRepository>();
            //ClienteRepository = DependencyContainer.Resolve<IClienteRepository>();
            //CommessaRepository = DependencyContainer.Resolve<ICommessaRepository>();
            //DipendenteRepository = DependencyContainer.Resolve<IDipendenteRepository>();
            //TimesheetRepository = DependencyContainer.Resolve<ITimesheetRepository>();
        }

        /// <summary>
        /// Fills repositories declared as public properties of current class
        /// </summary>
        private void FillRepositories()
        {
            //Recupero tutte le proprietà pubbliche della classe corrente
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //Iterazione delle proprietà
            foreach (var currentProperty in properties) 
            {
                //Recupero il tipo della proprietà
                Type propertyType = currentProperty.PropertyType;

                //Tento la risoluzione tramite dependency container
                object implementationInstance = DependencyContainer.Resolve(propertyType);

                //Imposto il valore sull'istanza
                currentProperty.SetValue(this, implementationInstance);
            }
        }

        #region Attività
        /// <summary>
        /// Recupera le liste di attività su una commessa
        /// </summary>
        /// <param name="commessa">Commessa</param>
        /// <returns>Ritorna la lista</returns>
        public IList<Attivita> FetchAttivitasByCommessa(Cliente commessa)
        {
            //Validazione argomenti
            if (commessa == null) throw new ArgumentNullException(nameof(commessa));

            //Richiamo il repository (efficiente!)
            return AttivitaRepository.FetchByCommessa(commessa);
        }
        #endregion

        #region Commessa

        /// <summary>
        /// Recupera la lista delle commesse per cliente
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <returns>Ritorna la lista delle commesse</returns>
        public IList<Commessa> FetchCommesseByCliente(Cliente cliente)
        {
            //Validazione argomenti
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            //Richiamo il repository (inefficiente!)
            var allCommesse = FetchAllEntities(CommessaRepository);

            //Estrazione di quelle del cliente
            return allCommesse
                .Where(c => c.Cliente.Id == cliente.Id)
                .ToList();
        }

        public IList<WorkerHoursByMonth> GetWorkedHoursForMonthByDipendente(Dipendente dipendente)
        {
            //Validazione argomenti
            if (dipendente == null) throw new ArgumentNullException(nameof(dipendente));

            //Estraggo tutti i timesheet (INEFFICIENTE, ma non ho TEMPO!!!!)
            var all = FetchAllEntities<Timesheet>(TimesheetRepository);

            //Raggruppamento
            return all
                .Where(r => r.Dipendente.Id == dipendente.Id)
                .GroupBy(e => new { Year = e.DataReport.Year, Month = e.DataReport.Month })
                .Select(g =>
                {
                    //Oggetto di uscita
                    var metric = new WorkerHoursByMonth
                    {
                        Dipendente = g.First().Dipendente,
                        Month = g.Key.Month,
                        Year = g.Key.Year,
                        TotalHours = g.Sum(r => r.OreAllocate)
                    };


                    return metric;
                })
                .ToList();
        }


        /// <summary>
        /// Crea un oggetto "Commessa" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> CreateCommessa(Commessa entity)
        {
            //Utilizzo il metodo base
            return CreateEntity(entity, CommessaRepository);
        }

        /// <summary>
        /// Aggiorna un oggetto "Commessa" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> UpdateCommessa(Commessa entity)
        {
            //Utilizzo il metodo base
            return UpdateEntity(entity, CommessaRepository);
        }

        /// <summary>
        /// Elimina un oggetto "Commessa" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> DeleteCommessa(Commessa entity)
        {
            //Utilizzo il metodo base
            return DeleteEntity(entity, CommessaRepository);
        }
        #endregion

        #region Dipendenti
        /// <summary>
        /// Get single dipendente by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dipendente GetDipendenteById(int id)
        {
            //TODO non va bene, ma per fare in fretta ci può stare!
            return base.FetchAllEntities<Dipendente>(DipendenteRepository)
                .SingleOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Lista di tutti i dipendenti nello storage
        /// </summary>
        /// <returns>Ritorna la lista</returns>
        public IList<Dipendente> FetchAllDipendenti()
        {
            //Utilizzo il repository
            return DipendenteRepository.FetchAll();
        }

        /// <summary>
        /// Crea un oggetto "Dipendente" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> CreateDipendente(Dipendente entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            DipendenteRepository.Create(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }

        /// <summary>
        /// Aggiorna un oggetto "Dipendente" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> UpdateDipendente(Dipendente entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            DipendenteRepository.Update(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }



        /// <summary>
        /// Elimina un oggetto "Dipendente" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> DeleteDipendente(Dipendente entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            DipendenteRepository.Delete(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }

        #endregion

        #region Cliente

        /// <summary>
        /// Cerca un cliente tramite tutti i suoi campi
        /// </summary>
        /// <param name="searchText">Testo di ricerca</param>
        /// <returns>Ritorna una lista</returns>
        public IList<Cliente> SearchClienti(string searchText)
        {
            //Se viene passato vuoto, esco
            if (string.IsNullOrEmpty(searchText))
                return new List<Cliente>();

            //Utilizzo il repository con il metodo custom
            return ClienteRepository.Search(searchText);
        }

        /// <summary>
        /// Conta tutti i clienti sullo storage
        /// </summary>
        /// <returns>Ritorna il conteggio</returns>
        public int CountAllClienti()
        {
            //Utilizzo il repository
            return ClienteRepository.CountAll();
        }

        /// <summary>
        /// Emette la lista di tutti gli elementi "Cliente" nello storage
        /// </summary>
        /// <returns>Ritorna la lista</returns>
        public IList<Cliente> FetchAllClienti()
        {
            //Utilizzo il metodo base
            return FetchAllEntities(ClienteRepository);
        }

        public async Task<IList<Cliente>> FetchAllClientiAsync() 
        {
            //Attesa
            await Task.Delay(1000);

            //Funzione base
            return FetchAllClienti();
        }

        /// <summary>
        /// Crea un oggetto "Dipendente" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> CreateCliente(Cliente entity)
        {
            //Utilizzo il metodo base
            return CreateEntity(entity, ClienteRepository);
        }

        /// <summary>
        /// Aggiorna un oggetto "Cliente" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> UpdateCliente(Cliente entity)
        {
            //Utilizzo il metodo base
            return UpdateEntity(entity, ClienteRepository);
        }

        /// <summary>
        /// Elimina un oggetto "Cliente" sul database e ritorna le validazioni
        /// </summary>
        /// <param name="entity">Entità</param>
        /// <returns>Ritorna le validazioni fallite (lista vuota => tutto ok!)</returns>
        public IList<ValidationResult> DeleteCliente(Cliente entity)
        {
            //Utilizzo il metodo base
            return DeleteEntity(entity, ClienteRepository);
        }

        /// <summary>
        /// Ritorna la lista di tutti i valori di dimensione azienda
        /// </summary>
        /// <returns>Lista di enum</returns>
        public IList<DimensioneAzienda> FetchDimensioniAzienda() 
        {
            //Utilizzo l'enum
            return EnumUtils.FetchEnumValues<DimensioneAzienda>();
        }
        #endregion

        #region Timesheets

        /// <summary>
        /// Estrae la lista dei timesheets
        /// </summary>
        /// <returns>Ritorna la lista</returns>
        public IList<Timesheet> FetchAllTimesheets()
        {
            //Tutti gli elementi
            return FetchAllEntities<Timesheet>(TimesheetRepository);
        }



        /// <summary>
        /// Fetch timesheest for dipendente
        /// </summary>
        /// <param name="dipendenteSelected">Dipendente</param>
        /// <returns></returns>
        public IList<Timesheet> FetchAllTimesheetsByDipendente(Dipendente dipendenteSelected)
        {
            //Validazione argomenti
            if (dipendenteSelected == null) throw new ArgumentNullException(nameof(dipendenteSelected));

            //Tutti gli elementi (TODO: megkio farlo fare al repository!)
            return FetchAllEntities<Timesheet>(TimesheetRepository)
                .Where(d => d.Dipendente.Id ==dipendenteSelected.Id)
                .ToList();
        }
        #endregion
    }
}
