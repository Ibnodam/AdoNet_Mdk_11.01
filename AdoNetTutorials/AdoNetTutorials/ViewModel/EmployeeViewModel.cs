using AdoNetTutorials.Model;
using AdoNetTutorials.Services;
using AdoNetTutorials.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTutorials.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private EmployeeService empService;

        private ObservableCollection<Employee> empList;
        public ObservableCollection<Employee> EmpList
        {
            get => empList; set { empList = value; OnPropertyChanged(nameof(EmpList)); }

        }

        //

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged(nameof(CurrentEmployee)); }
        }

        //

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(nameof(Message)); }
        }
        //
        public EmployeeViewModel()
        { 
            empService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveComa
        }

    }
}
