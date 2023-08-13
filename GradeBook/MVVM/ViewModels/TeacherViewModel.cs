using GradeBook.MVVM.Model;
using GradeBook.MVVM.ViewModels.ClassCommands;
using GradeBook.MVVM.ViewModels.ClassCommands.AddClass;
using GradeBook.MVVM.ViewModels.ClassCommands.DeleteClass;
using GradeBook.MVVM.ViewModels.ClassCommands.UpdateClass;
using GradeBook.MVVM.ViewModels.Helpers;
using GradeBook.MVVM.ViewModels.StudentCommands;
using GradeBook.MVVM.ViewModels.StudentCommands.AddStudent;
using GradeBook.MVVM.ViewModels.StudentCommands.DeleteStudent;
using GradeBook.MVVM.ViewModels.StudentCommands.UpdateStudent;
using GradeBook.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeBook.MVVM.ViewModels
{
    public class TeacherViewModel : ViewModelBase
    {
        public Teacher Teacher { get; set; }
        public NavigationStore NavigationStore { get; set; }

        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public AddClassCommand AddClassCommand { get; set; }
        public UpdateClassCommand UpdateClassCommand { get; set; }
        public DeleteClassCommand DeleteClassCommand { get; set; }
        public ClassChangedCommand ClassChangedCommand { get; set; }
        
        public AddStudentCommand AddStudentCommand { get; set; }
        public UpdateStudentCommand UpdateStudentCommand { get; set; }
        public DeleteStudentCommand DeleteStudentCommand { get; set; }

        public SearchTextChangedCommand SearchTextChangedCommand { get; set; }
        public ClassSearchTextChangedCommand ClassSearchTextChangedCommand { get; set; }
        public AccessStudentCommand AccessStudentCommand { get; set; }

        private string studentFilter;

        public string StudentFilter
        {
            get { return studentFilter; }
            set {
                studentFilter = value;
                OnPropertyChanged(nameof(StudentFilter));  
            }
        }

        private string classFilter;

        public string ClassFilter
        {
            get { return classFilter; }
            set { 
                classFilter = value;
                OnPropertyChanged(nameof(ClassFilter));
            }
        }

        public TeacherViewModel(NavigationStore nav, Teacher teacher) { 
            NavigationStore = nav;
            Teacher = teacher;

            Classes = new ObservableCollection<Class>(DatabaseHelper.ReadData(teacher));
            Students = new ObservableCollection<Student>();

            AddClassCommand = new AddClassCommand(Classes, teacher);
            UpdateClassCommand = new UpdateClassCommand(Classes, teacher);  
            DeleteClassCommand = new DeleteClassCommand(Classes, teacher);

            AddStudentCommand = new AddStudentCommand(Students);
            UpdateStudentCommand = new UpdateStudentCommand(Students);
            DeleteStudentCommand = new DeleteStudentCommand(Students);
            ClassChangedCommand = new ClassChangedCommand(Students);

            StudentFilter = "";
            SearchTextChangedCommand = new SearchTextChangedCommand(Students);

            ClassFilter = "";
            ClassSearchTextChangedCommand = new ClassSearchTextChangedCommand(Teacher, Classes);

            AccessStudentCommand = new AccessStudentCommand(NavigationStore, Teacher);
        }
    }
}
