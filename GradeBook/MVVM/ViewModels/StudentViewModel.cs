using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.GradeCommands.AddGrade;
using GradeBook.MVVM.ViewModels.GradeCommands.DeleteGrade;
using GradeBook.MVVM.ViewModels.GradeCommands.UpdateGrade;
using GradeBook.MVVM.ViewModels.Helpers;
using GradeBook.MVVM.ViewModels.MisconductCommands.AddMisconduct;
using GradeBook.MVVM.ViewModels.MisconductCommands.DeleteMisconduct;
using GradeBook.MVVM.ViewModels.TruancyCommands.AddTruancy;
using GradeBook.MVVM.ViewModels.TruancyCommands.DeleteTruancy;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public NavigationStore NavigationStore { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        
        public ObservableCollection<Grade> Grades { get; set; }
        public AddGradeCommand AddGradeCommand { get; set; }
        public UpdateGradeCommand UpdateGradeCommand { get; set; }
        public DeleteGradeCommand DeleteGradeCommand { get; set; }

        public ObservableCollection<Truancy> Truancies { get; set; }
        public AddTruancyCommand AddTruancyCommand { get; set; }
        public DeleteTruancyCommand DeleteTruancyCommand { get; set; }

        public ObservableCollection<Misconduct> Misconducts { get; set; }
        public AddMisconductCommand AddMisconductCommand { get; set; }
        public DeleteMisconductCommand DeleteMisconductCommand { get; set; }

        public StudentViewModel(NavigationStore nav, Student student, Teacher teacher)
        {
            NavigationStore = nav;
            Student = student;
            Teacher = teacher;
            Grades = new ObservableCollection<Grade>();
            foreach (Grade grade in DatabaseHelper.ReadDataGrades(Student, Teacher))
            {
                Grades.Add(grade);
            }
            AddGradeCommand = new AddGradeCommand(Grades, Student, Teacher);
            UpdateGradeCommand = new UpdateGradeCommand(Grades, Student, Teacher);
            DeleteGradeCommand = new DeleteGradeCommand(Grades, Student, Teacher);
            
            Truancies = new ObservableCollection<Truancy>();
            foreach (Truancy truancy in DatabaseHelper.ReadDataTruancies(Student, Teacher))
            {
                Truancies.Add(truancy);
            }
            AddTruancyCommand = new AddTruancyCommand(Truancies, Student, Teacher);
            DeleteTruancyCommand = new DeleteTruancyCommand(Truancies, Student, Teacher);

            Misconducts = new ObservableCollection<Misconduct>();
            foreach (Misconduct misconduct in DatabaseHelper.ReadDataMisconducts(Student, Teacher))
                Misconducts.Add(misconduct);
            AddMisconductCommand = new AddMisconductCommand(Misconducts, Student, Teacher);
            DeleteMisconductCommand = new DeleteMisconductCommand(Misconducts, Student, Teacher);
        }
    }
}
