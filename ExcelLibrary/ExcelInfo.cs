using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelLibrary
{
    public class ExcelInfo
    {
        /// <summary>
        /// Full file path of where the data is located to be imported.
        /// </summary>
        public string FileName { get; set; }





        /// <summary>
        /// A boolean value indicating wheather or not the excel file has headers
        /// </summary>
        public bool HasHeaders { get; set; }





        /// <summary>
        /// Return a string stating wheather or not the property 'HesHeader' is true or false
        /// </summary>
        public string Header
        {
            get { return HasHeaders ? "YES" : "NO"; }
        }





        /// <summary>
        /// Integer index values of the sheet names contained in the excel PRPO files.
        /// </summary>
        public enum SheetNames
        {
            US_PRPO,
            MX_PRPO,
        }





        /// <summary>
        /// The sheet name within the excel files.
        /// </summary>
        public static readonly string[] sheetName = { "PRPO_US$", "PRPO_MX$" };





        /// <summary>
        /// The name of the sheet within the excel file.
        /// </summary>
        public string SheetName { get; set; }





        /// <summary>
        /// This function will build the connection string based on the properties that are supplied
        /// to the class. The final connection string is also dependant on the file extension of the
        /// excel file that is given by the user.
        /// </summary>
        /// <returns>
        /// This function will return the connection string based no the the properties
        /// that were supplied and the extension of the excel file.
        /// </returns>
        public string connectionString()
        {
            OleDbConnectionStringBuilder strbldr = new OleDbConnectionStringBuilder();
            if (Path.GetExtension(FileName).ToUpper() == "XLS")
            {
                strbldr.Provider = "Microsoft.Jet.OLEDB.4.0";
                strbldr.Add("Extended Properties", "Excel 8.0;IMEX=1;HDR" + Header);
            }
            else
            {
                strbldr.Provider = "Microsoft.ACE.OLEDB.12.0";
                strbldr.Add("Extended Properties", "Excel 12.0;IMEX=1;HDR=" + Header);
            }

            strbldr.DataSource = FileName;
            return strbldr.ConnectionString;
        }
    }
}
