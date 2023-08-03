using GradeBook.MVVM.Model;
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
        public static List<Class> ReadData(Teacher t)
        {
            List<Class> list;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(connectionString))
            {
                sql.CreateTable<Teacher_Class>();
                sql.CreateTable<Class>();
                list = (from t_c in sql.Table<Teacher_Class>()
                       join cl in sql.Table<Class>()
                       on t_c.IdClass equals cl.Id
                       where t_c.IdTeacher == t.Id
                       select cl).ToList();
            }
            return list;
        }
        public static List<Student> ReadData(Class c)
        {
            List<Student> list;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(connectionString))
            {
                sql.CreateTable<Student>();
                list = sql.Table<Student>().Where(st => st.IdClass == c.Id).ToList();
            }
            return list;
        }
    }
}
