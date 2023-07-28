using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.Helpers
{
    /// <summary>
    /// This is a database helper for the SQLite database
    /// </summary>
    public class DatabaseHelper
    {
        static string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string dataBaseName = "GradeBook.db";
        public static string connectionString = Path.Combine(myDocumentsPath, dataBaseName);
        public static List<T> ReadData<T>() where T : class, new()
        {
            List<T> list;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(connectionString))
            {
                list = sql.Table<T>().ToList();
            }
            return list;
        }
    }
}
