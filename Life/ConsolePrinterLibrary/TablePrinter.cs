using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsolePrinterLibrary
{
    /// <summary>
    /// This class is used for printing the tables
    /// </summary>
    public class TablePrinter
    {
        /// <summary>
        /// The Table which is to be printed
        /// </summary>
        public Table Table { get; set; } = new Table();
        /// <summary>
        /// Creates string with table in such format:
        /// ┏━━━┓
        /// ┃   ┃
        /// ┣━┳━┫
        /// ┃ ┃ ┃
        /// ┡━╇━┩
        /// │ │ │
        /// ├─┼─┤
        /// │ │ │
        /// └─┴─┘
        /// </summary>
        public string GetTextTable()
        {
            string text = "";
            #region Collecting values of table cells max width
            Dictionary<Field, int> width = new Dictionary<Field, int>();
            int total = 0;
            for (int i = 0; i < Table.Fields.Count; i++)
            {
                width.Add(Table.Fields[i], Table.Fields[i].Name.Length);
                for (int a = 0; a < Table.Entries.Count; a++)
                {
                    if (Table.Entries[a].Columns.Keys.Contains(Table.Fields[i]) &&
                        width[Table.Fields[i]] < Table.Entries[a].Columns[Table.Fields[i]].Length)
                    {
                        width[Table.Fields[i]] = Table.Entries[a].Columns[Table.Fields[i]].Length;
                    }
                }
                total += width[Table.Fields[i]];
            }
            #endregion
            #region ┏━━━┓
            text += "┏";
            for (int i = 0; i < total + 3 * Table.Fields.Count - 1; i++)
                text += "━";
            text += "┓";
            text += "\r\n";
            #endregion
            #region ┃   ┃
            text += "┃";
            int left = (total + 3 * Table.Fields.Count - 1 - Table.Name.Length) / 2;
            int right = total + 3 * Table.Fields.Count - 1 - Table.Name.Length - left;
            for (int i = 0; i < left; i++)
                text += " ";
            text += Table.Name;
            for (int i = 0; i < right; i++)
                text += " ";
            text += "┃";
            text += "\r\n";
            #endregion
            #region ┣━┳━┫
            text += "┣";
            for (int i = 0; i < Table.Fields.Count; i++)
            {
                for (int a = 0; a < width[Table.Fields[i]] + 2; a++)
                {
                    text += "━";
                }
                if (i != Table.Fields.Count - 1)
                    text += "┳";
                else
                    text += "┫";
            }
            text += "\r\n";
            #endregion
            #region ┃ ┃ ┃
            for (int i = 0; i < Table.Fields.Count; i++)
            {
                left = (width[Table.Fields[i]] - Table.Fields[i].Name.Length) / 2;
                right = width[Table.Fields[i]] - Table.Fields[i].Name.Length - left;
                text += "┃ ";
                for (int a = 0; a < left; a++)
                    text += " ";
                text += Table.Fields[i].Name;
                for (int a = 0; a < right + 1; a++)
                    text += " ";
                if (i == Table.Fields.Count - 1)
                    text += "┃";
            }
            text += "\r\n";
            #endregion
            #region ┡━╇━┩
            text += "┡";
            for (int i = 0; i < Table.Fields.Count; i++)
            {
                for (int a = 0; a < width[Table.Fields[i]] + 2; a++)
                    text += "━";
                if (i != Table.Fields.Count - 1)
                    text += "╇";
                else
                    text += "┩";
            }
            text += "\r\n";
            #endregion
            #region │ │ │
            for (int i = 0; i < Table.Entries.Count; i++)
            {
                for (int a = 0; a < Table.Fields.Count; a++)
                {
                    text += "│ ";
                    int length = 1;
                    if(Table.Entries[i].Columns.Keys.Contains(Table.Fields[a]))
                    {
                        length = Table.Entries[i].Columns[Table.Fields[a]].Length;
                    }
                    left = (width[Table.Fields[a]] - length) / 2;
                    right = width[Table.Fields[a]] - length - left;
                    for (int k = 0; k < left; k++)
                        text += " ";
                    if (Table.Entries[i].Columns.Keys.Contains(Table.Fields[a]))
                    {
                        text += Table.Entries[i].Columns[Table.Fields[a]];
                    }
                    else
                    {
                        text += " ";
                    }
                    for (int k = 0; k < right + 1; k++)
                        text += " ";
                    if (a == Table.Fields.Count - 1)
                    {
                        text += "│";
                        text += "\r\n";
                    }
                }
                #region ├─┼─┤
                if (i != Table.Entries.Count - 1)
                {
                    text += "├";
                    for (int a = 0; a < Table.Fields.Count; a++)
                    {
                        for (int k = 0; k < width[Table.Fields[a]] + 2; k++)
                            text += "─";
                        if (a != Table.Fields.Count - 1)
                            text += "┼";
                        else
                        {
                            text += "┤";
                            text += "\r\n";
                        }
                    }
                }
                #endregion
            }
            #endregion
            #region └─┴─┘
            text += "└";
            for (int i = 0; i < Table.Fields.Count; i++)
            {
                for (int a = 0; a < width[Table.Fields[i]] + 2; a++)
                    text += "─";
                if (i != Table.Fields.Count - 1)
                    text += "┴";
                else
                    text += "┘";
            }
            text += "\r\n";
            #endregion
            return text;
        }
        /// <summary>
        /// Creates string with table in html format:
        ///     <table>
        ///         <thead>
        ///             <tr>
        ///                 <th>
        ///                     
        ///                 </th>
        ///             </tr>
        ///             <tr>
        ///                 <th>
        ///                     
        ///                 </th>
        ///                 <th>
        ///                     
        ///                 </th>
        ///             </tr>
        ///         </thead>
        ///         <tbody>
        ///             <tr>
        ///                 <td>
        ///                     
        ///                 </td>
        ///                 <td>
        ///                     
        ///                 </td>
        ///             </tr>
        ///             <tr>
        ///                 <td>
        ///                     
        ///                 </td>
        ///                 <td>
        ///                     
        ///                 </td>
        ///             </tr>
        ///         </tbody>
        ///     </table>
        /// </summary>
        public string GetHTMLTable()
        {
            string html = "";
            html += "<table rules=\"all\" border=\"1\">";
            html += "<thead>";
            html += "<tr>";
            html += $"<th colspan=\"{Table.Fields.Count}\">";
            html += Table.Name;
            html += "</th>";
            html += "</tr>";
            html += "<tr>";
            for (int i = 0; i < Table.Fields.Count; i++)
            {
                html += "<th>";
                html += Table.Fields[i].Name;
                html += "</th>";
            }
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            for (int i = 0; i < Table.Entries.Count; i++)
            {
                html += "<tr>";
                for (int a = 0; a < Table.Fields.Count; a++)
                {
                    html += "<td>";
                    if (Table.Entries[i].Columns.Keys.Contains(Table.Fields[a]))
                    { 
                        html += Table.Entries[i].Columns[Table.Fields[a]]; 
                    }
                    else
                    {
                        html += "&nbsp;";
                    }
                    html += "</td>";
                }
                html += "</tr>";
            }
            html += "</tbody>";
            html += "</table>";
            return html;
        }
    }
}
