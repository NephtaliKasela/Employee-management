using MyProject_v002.BisinessObjects;
using MyProject_v002.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject_v002
{
    public partial class Confirmation_Delete_Employee : Form
    {
        public Repository repository = new Repository();
        public Confirmation_Delete_Employee()
        {
            InitializeComponent();
        }

        private void guna2btnDelete_Click(object sender, EventArgs e)
        {
            repository.Read_Employees("Employees/inputEmployees.txt");
            repository.Read_Deleted_Employees("Employees/Deleted_Employees.txt");

            foreach (Employee employee in repository.GetEmployees())
            {
                foreach(Employee emp in repository.Get_Deleted_Employee())
                {
                    if(emp.Name.ToLower() == employee.Name.ToLower() &&
                       emp.PostName.ToLower() == employee.PostName.ToLower() &&
                       emp.GivenName.ToLower() == employee.GivenName.ToLower() &&
                       emp.BirthDay.ToLower() == employee.BirthDay.ToLower())
                    {
                        DateTime today = DateTime.Now;
                        employee.Date = today.ToString();

                        repository.Delete_Employee_Identity(employee, "Employees/inputEmployees.txt");
                        repository.Add_EmployeesDeleted_inThe_History(employee);

                        repository.SaveEmployeesIdentities("Employees/inputEmployees.txt", repository.GetEmployees());
                        repository.Track_Employees("Employees/Track_Deleted_Employees.txt", "Employees/History.txt", repository.Get_History_of_Deleted_Employee(), "delete");

                        File.WriteAllText("Employees/Deleted_Employees.txt", "");
                        this.Close();
                        MessageBox.Show("Successful !!!");
                        return;
                    }
                }
            }
        }

        private void guna2btnNotDelete_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Employees/Deleted_Employees.txt", "");
            this.Close();
        }
    }
}
