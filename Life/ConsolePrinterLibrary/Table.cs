using System.Collections.Generic;

namespace ConsolePrinterLibrary
{
    /// <summary>
    /// This class stores entries and needed fields
    /// </summary>
    public class Table
    {
        /// <summary>
        /// This name is shown in the head of the table
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Entries list. They will be printed in the same order as here.
        /// </summary>
        public List<Entry> Entries { get; set; } = new List<Entry>();
        /// <summary>
        /// Fields list. Fields will be printed in the same order as here, no matter how they are ordered in entries.
        /// If some field, which is present in entries, is not added here, it will not be printed at all.
        /// If some entry doesn't contain some field either by mistake or by purpose, blank cell will be printed.
        /// </summary>
        public List<Field> Fields { get; set; } = new List<Field>();
    }
}

