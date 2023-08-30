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
        /// <summary>
        /// This function reads the list of classes the teacher is teaching at 
        /// </summary>
        /// <param name="t">
        /// Parameter is a Teacher object
        /// </param>
        /// <returns>
        /// Returns list of classes
        /// </returns>
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
        /// <summary>
        /// This function reads the list of classes the teacher is teaching at based on a filter
        /// </summary>
        /// <param name="t">
        /// Parameter is a Teacher object
        /// </param>
        /// <param name="filter">
        /// Parameter is a filter that is applied on the resulting list of classes
        /// </param>
        /// <returns>
        /// Returns list of classes based on filter
        /// </returns>
        public static List<Class> ReadData(Teacher t, string filter)
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
                        where t_c.IdTeacher == t.Id && (cl.Year.ToString() + cl.Name).Contains(filter)
                        select cl).ToList();
            }
            return list;
        }
        /// <summary>
        /// This function reads all students based on a class
        /// </summary>
        /// <param name="c">A class</param>
        /// <returns>List of all students from the class</returns>
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
        /// <summary>
        /// This function reads all students based on a class and a filter (string that a student must contain)
        /// </summary>
        /// <param name="c">A class</param>
        /// <param name="Filter">string that the student should contain</param>
        /// <returns>List of students from that class. The students must contain the filter</returns>
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
        /// <summary>
        /// Function that reads all grades from a student based on teacher's subject
        /// </summary>
        /// <param name="student">The student</param>
        /// <param name="teacher">The teacher</param>
        /// <returns>List of grades</returns>
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
        /// <summary>
        /// This function reads the truancies done by a student
        /// </summary>
        /// <param name="student">The student</param>
        /// <param name="teacher">The teacher</param>
        /// <returns>List of truancies</returns>
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
        /// <summary>
        /// This function reads the misconducts done by a student in a teacher's course
        /// </summary>
        /// <param name="student">The student</param>
        /// <param name="teacher">The teacher</param>
        /// <returns>The list of Misconducts</returns>
        public static List<Misconduct> ReadDataMisconducts(Student student, Teacher teacher) {
            List<Misconduct> list = new List<Misconduct>();
            if (student == null || teacher == null) return list;
            using (SQLite.SQLiteConnection sql = new SQLite.SQLiteConnection(connectionString))
            {
                sql.CreateTable<TSM>();
                sql.CreateTable<Misconduct>();
                list = (from tsm in sql.Table<TSM>()
                        where tsm.IdStudent == student.Id && tsm.IdTeacher == teacher.Id
                        join misconduct in sql.Table<Misconduct>()
                        on tsm.IdMisconduct equals misconduct.Id
                        select misconduct).ToList();
            }
            return list;
        }
    }
}
