using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.Helpers
{
    public class DatabaseHelper
    {
        static string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string dataBaseName = "GradeBook.db";
        public static string connectionString = Path.Combine(myDocumentsPath, dataBaseName);
    }
}
