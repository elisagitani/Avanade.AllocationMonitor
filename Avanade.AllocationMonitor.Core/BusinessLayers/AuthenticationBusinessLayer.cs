using Avanade.AllocationMonitor.Core.DependencyContainers;
using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.Core.BusinessLayers
{
    /// <summary>
    /// Cervello dell'applicazione per gestire le autenticazioni al sistema
    /// </summary>
    public class AuthenticationBusinessLayer
    {
        /// <summary>
        /// Esegue il login al sistema usando username e password;
        /// ritorna un utente valido (diverso da null) se l'autenticazione
        /// è andata a buon fine. Null se l'autenticazione è fallita
        /// </summary>
        /// <param name="userName">Nome utente</param>
        /// <param name="password">Password</param>
        /// <returns>Ritorna null o user</returns>
        public User SignIn(string userName, string password)
        {
            //Validazione degli input
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            //Verifico che esista uno username sul database
            User user = GetUserByUserName(userName);

            //Se l'utente è nullo, esco perchè non posso fare il login
            if (user == null)
                return null;

            //Se arrivo qui, l'utente esiste; quindi verifico se è abilitato.
            //Se non è abilitato, esco con null
            if (!user.IsEnabled)
                return null;

            //A questo punto verifico la password. (ATTENZIONE! La password
            //non dovrebbe essere in chiaro nel database). Se la password
            //passata è uguale a quella sull'utente, confermo, altrimenti null
            if (user.Password != password)
                return null;

            //Se arrivo anche qui il login è ok
            return user;
        }

        /// <summary>
        /// Executes sign-in (in async mode) with provided credentials
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Returns task with autenticated user (or null)</returns>
        public async Task<User> SignInAsync(string userName, string password)
        {
            //Validazione degli input
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            //Simulazione di una attesa di 3 secondi
            await Task.Delay(1000);

            //Esecuzione della funzione di login
            return SignIn(userName, password);
        }

        /// <summary>
        /// Recupera dal database un utente usando lo username
        /// </summary>
        /// <param name="userName">Username</param>
        /// <returns>Ritorna null se non lo trova, l'oggetto user se lo trova</returns>
        public User GetUserByUserName(string userName)
        {
            //Validazione degli input
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));

            //Creo il repository
            //SqlServerUserRepository userRepository
            //IUserRepository userRepository = new SqlServerUserRepository();
            //IUserRepository userRepository = new InMemoryUserRepository();
            IUserRepository userRepository = DependencyContainer.Resolve<IUserRepository>();

            //Ritorno user (o null, se non è stato trovato)
            return userRepository.GetByUserName(userName);            
        }
    }
}