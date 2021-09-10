using Avanade.AllocationMonitor.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.AllocationMonitor.Core.Mocks.Storages.Extensions
{
    public static class InMemoryStorageExtensions
    {
        /// <summary>
        /// Generates identity on provided entity and push to collection on storage
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="instance">Instance of storage</param>
        /// <param name="listOfEntities">Expression with collection</param>
        /// <param name="entityToPush">Entity to push</param>
        public static void GenerateIdentityAndPush<TEntity>(this InMemoryStorage instance,
            Func<InMemoryStorage, IList<TEntity>> listOfEntities, TEntity entityToPush)
            where TEntity: class, IEntity, new()
        {
            //Validazione argomenti
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (listOfEntities == null) throw new ArgumentNullException(nameof(listOfEntities));
            if (entityToPush == null) throw new ArgumentNullException(nameof(entityToPush));

            //Recupero la collezione di riferimento
            var collection = listOfEntities(instance);

            //Calcolo l'indice massimo sulla collezione
            var newId = (collection.Max(e => e.Id) ?? 0) + 1;

            //Assegnazione dell'id
            entityToPush.Id = newId;

            //Aggiungo alla lista
            collection.Add(entityToPush);
        }
    }
}
