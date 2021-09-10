using System;
using System.Collections.Generic;

namespace Avanade.AllocationMonitor.Core.Utils
{
    /// <summary>
    /// Utilities for enums
    /// </summary>
    public static class EnumUtils
    {
        public static IList<TEnum> FetchEnumValues<TEnum>()
            where TEnum: struct
        {
            //Recupero il tipo dell'enumerazione dal generico
            Type enumType = typeof(TEnum);

            //Recupero tutti i valori contenuti nell'enum            
            Array values = Enum.GetValues(enumType);

            //Lista di uscita
            IList<TEnum> items = new List<TEnum>();

            //Iterazione sui valori recuperati
            foreach (var current in values)
            {
                //Recupero del valore
                TEnum value = (TEnum)current;

                //Creazione dell'item e aggiunta
                items.Add(value);
            }

            //EMissione della lista
            return items;
        }
    }
}
