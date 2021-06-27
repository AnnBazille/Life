using System.Collections.Generic;

namespace ConsolePrinterLibrary
{
    /// <summary>
    /// This class stores the fields as the keys and its corresponding values as the single entry
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Columns of the entry, where Field is the key and value is the string. Columns can be added in any order.
        /// Any data type can be represented as value as long as it can be converted to string.
        /// </summary>
        public Dictionary<Field, string> Columns { get; set; } = new Dictionary<Field, string>();
    }
}