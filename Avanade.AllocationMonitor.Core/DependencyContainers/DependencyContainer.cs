using Ninject;
using System;

namespace Avanade.AllocationMonitor.Core.DependencyContainers
{
    public static class DependencyContainer
    {
        //Inizializzazione statica
        private static readonly Lazy<IKernel> _Kernel = new Lazy<IKernel>(() => new StandardKernel());

        /// <summary>
        /// Resolve specified interface
        /// </summary>
        /// <typeparam name="TInterface">Type of interface</typeparam>
        /// <returns>Returns resolution</returns>
        public static TInterface Resolve<TInterface>()
        {
            //Ritorno la risoluzione
            return _Kernel.Value.Get<TInterface>();
        }

        /// <summary>
        /// Resolve specified type
        /// </summary>
        /// <param name="interfaceType">Interface as type</param>
        /// <returns>Returns resolution</returns>
        public static object Resolve(Type interfaceType)
        {
            //Ritorno la risoluzione
            return _Kernel.Value.Get(interfaceType);
        }

        /// <summary>
        /// Registers provided interface to concrete type
        /// </summary>
        /// <typeparam name="TInterface">Type of interface</typeparam>
        /// <typeparam name="TImplementation">Type of implementation</typeparam>
        public static void Register<TInterface, TImplementation>()
            where TImplementation : class, TInterface
        {
            //Espongo il metodo ed ottengo la sintassi per il bindind
            //di destinazione per l'interfaccia passata
            var bindingToSyntax = _Kernel.Value.Rebind<TInterface>();

            //Eseguo il binding della sintassi al target
            var bindingOnSyntax = bindingToSyntax.To<TImplementation>();

            //Applico la policy di singleton per la cache
            bindingOnSyntax.InSingletonScope();
        }
    }
}