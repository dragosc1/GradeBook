using GradeBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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
            List<Class> list = new List<Class>();
            if (t == null) return list;
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
            List<Student> list = new List<Student>();
            if (c == null) return list; 
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(connectionString))
            {
                sql.CreateTable<Student>();
                list = sql.Table<Student>().Where(st => st.IdClass == c.Id).ToList();
            }
            return list;
        }
        public static List<Student> ReadData(Class c, string Filter)
        {
            List<Student> list = new List<Student>();
            if (c == null) return list;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(connectionString))
            {
                sql.CreateTable<Student>();
                list = sql.Table<Student>().Where(st => st.IdClass == c.Id && st.Name.ToLower().Contains(Filter.ToLower())).ToList();
            }
            return list;
        }
        public static List<Grade> ReadDataGrades(Student student, Teacher teacher)
        {
            List<Grade> list = new List<Grade>();
            if (student == null || teacher == null) return list;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(connectionString))
            {
                sql.CreateTable<TSG>();
                sql.CreateTable<Grade>();
                list = (from tsg in sql.Table<TSG>()
                       where tsg.IdStudent == student.Id && tsg.IdTeacher == teacher.Id
                       join grade in sql.Table<Grade>()
                       on tsg.IdGrade equals grade.Id
                       select grade).ToList();
            }
            return list;
        }
        public static List<Truancy> ReadDataTruancies(Student student, Teacher teacher)
        {
            List<Truancy> list = new List<Truancy>();
            if (student == null || teacher == null) return list;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(connectionString))
            {
                sql.CreateTable<TST>();
                sql.CreateTable<Truancy>();
                list = (from tst in sql.Table<TST>()
                        where tst.IdStudent == student.Id && tst.IdTeacher == teacher.Id
                        join truancy in sql.Table<Truancy>()
                        on tst.IdTruancy equals truancy.Id
                        select truancy).ToList();
            }
            return list;
        }
    }
}
