using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyProject_v002.DataAccess;
using MyProject_v002.BisinessObjects;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace MyProject_v002
{
    public partial class NewEmployee : Form
    {
        private string photo = string.Empty;
        Repository repository = new Repository();
        Employee employee_to_Update = new Employee();
        
        public NewEmployee()
        {
            InitializeComponent();

            Get_all_Departments();

            Check_if_Update_and_Print_all_Info();
        }

        // Check if the user entered all required informations
        private void guna2TxtName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox(guna2TxtName);
        }

        private void guna2TxtPostName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox(guna2TxtPostName);
        }

        private void guna2TxtGivenName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox(guna2TxtGivenName);
        }

        private void guna2NupDwAge_ValueChanged(object sender, EventArgs e)
        {
            if (guna2NupDwAge.Value <= 0) guna2NupDwAge.BackColor = Color.Red;
            else guna2NupDwAge.BackColor = Color.Green;
        }

        private void guna2TxtBirthDay_TextChanged(object sender, EventArgs e)
        {
            CheckTheDate(guna2TxtBirthDay);
        }

        private void guna2cbxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChechComboBox(guna2cbxGender);
        }

        private void guna2TxtCountry_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox(guna2TxtCountry);
        }

        private void guna2TxtPost_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox(guna2TxtPost);
        }

        private void guna2TxtID_TextChanged(object sender, EventArgs e)
        {
            CheckTextBox(guna2TxtID);
        }

        private void guna2cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChechComboBox(guna2cbxDepartment);
        }

        private void guna2cbxContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChechComboBox(guna2cbxContractType);
            if (guna2cbxContractType.Text.ToLower() == "indefinite") guna2TxtEndJob.Visible = false;
            else guna2TxtEndJob.Visible = true;
        }

        private void guna2cbxSocialStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChechComboBox(guna2cbxSocialStatus);
        }

        private void guna2TxtStartJob_TextChanged(object sender, EventArgs e)
        {
            CheckTheDate(guna2TxtStartJob);
        }

        private void guna2TxtEndJob_TextChanged(object sender, EventArgs e)
        {
            CheckTheDate(guna2TxtEndJob);
        }

        private void guna2btnPicture_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guna2cpPicture.Load(openFileDialog1.FileName);
                guna2cpPicture.SizeMode = PictureBoxSizeMode.StretchImage;

                if (openFileDialog1.FileName != string.Empty)
                {
                    guna2btnPicture.BackColor = Color.Green;
                    photo = openFileDialog1.FileName;
                }
            }
        }

        // Add the employee in the data base if everything is ok
        private void guna2btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckTextBox(guna2TxtName) &&
                CheckTextBox(guna2TxtPostName) &&
                CheckTextBox(guna2TxtGivenName) &&
                guna2NupDwAge.Value > 0 &&
                CheckTheDate(guna2TxtBirthDay) &&
                ChechComboBox(guna2cbxGender) &&
                CheckTextBox(guna2TxtCountry) &&
                CheckTextBox(guna2TxtPost) &&
                CheckTextBox(guna2TxtID) &&
                ChechComboBox(guna2cbxDepartment) &&
                ChechComboBox(guna2cbxContractType) &&
                ChechComboBox(guna2cbxSocialStatus) &&
                CheckTheDate(guna2TxtStartJob)
                )
            {
                Save_Info();

                // Check if it is a registration or Update
                // if registration, add the new employee in the data base of employees and salary
                // if update, search that employee in the data base of employee and salary and update

                if (lblTitle.Text.ToLower() == "registration")
                {
                    Register_Employee(Save_Info());
                }
                else if (lblTitle.Text.ToLower() == "update")
                {
                    Update_Employee(employee_to_Update, Save_Info());
                }
                // Print a message that inform the user that everthing was made successfully
                MessageBox.Show("Successful !!!", "Info");
            }
            else
            {
                lblWarning.Text = "Some informations are missing !";
                lblWarning.ForeColor = Color.Red;
                guna2btnSubmit.FillColor = Color.Gray;
            }
        }



        // Beginig of Personalized methodes
        private bool CheckTextBox(Guna2TextBox textBox)
        {
            Warning();
            if (textBox.Text.Trim() == string.Empty || textBox.Text.Trim().Contains("\t") || textBox.Text.Trim().Contains("\n"))
            {
                textBox.BorderColor = Color.Red;
                return false;
            }
            else
            {
                textBox.BorderColor = Color.Green;
                return true;
            }
        }

        private bool ChechComboBox(Guna2ComboBox comboBox)
        {
            Warning();
            if (comboBox.Text == string.Empty)
            {
                comboBox.BorderColor = Color.Red;
                return false;
            }
            else
            {
                comboBox.BorderColor = Color.Green;
                return true;
            }
        }

        private bool CheckTheDate(Guna2TextBox date)
        {
            Warning();

            if (date.Text.Length == 1) MessageBox.Show("Example: DD.MM.YYY\n\t01.01.1919", "Info");

            if (date.Text.Trim() == String.Empty || date.Text.Trim().Contains("\t") || date.Text.Trim().Contains("\n"))
            {
                date.BackColor = Color.Red;
            }
            else if (date.Text.Length == 10)
            {
                int count = 0;
                foreach (char ch in date.Text)
                {
                    if (ch == '.') count += 1;
                }
                if (count == 2)
                {
                    date.BackColor = Color.Green;
                    return true;
                }
                else
                {
                    date.BackColor = Color.Red;
                    MessageBox.Show("Example: DD.MM.YYY\n\t01.01.1919", "Info");
                }
            }
            else
            {
                if (date.Text.Length > 10) MessageBox.Show("Example:\n\t01.01.1919", "Info");
                date.BackColor = Color.Red;
            }
            return false;
        }

        public void Get_all_Departments()
        {
            repository.Read_Department("Employees/Departments.txt");
            repository.Get_Departmnts();
            foreach (var department in repository.Get_Departmnts())
            {
                guna2cbxDepartment.Items.Add(department);
            }
        }

        public void Check_if_Update_and_Print_all_Info()
        {
            // Open the file and get the employee's identity to update
            repository.Read_Employee_Identity_ToUpdate("Employees/Employee_Identity_ToUpdate.txt");

            if (repository.Get_Employee_Identity_ToUpdate().Count > 0)
            {
                Employee emp = repository.Get_Employee_Identity_ToUpdate()[repository.Get_Employee_Identity_ToUpdate().Count - 1];

                guna2TxtName.Text = emp.Name;
                guna2TxtPostName.Text = emp.PostName;
                guna2TxtGivenName.Text = emp.GivenName;
                guna2NupDwAge.Value = emp.Age;
                guna2TxtBirthDay.Text = emp.BirthDay;
                if (emp.Gender == 'M') guna2cbxGender.Text = "Male";
                else guna2cbxGender.Text = "Female";
                guna2TxtCountry.Text = emp.Country;
                guna2TxtPost.Text = emp.Post;
                guna2TxtID.Text = emp.Id;
                guna2cbxDepartment.Text = emp.Department;
                guna2cbxContractType.Text = emp.ContractType;
                guna2cbxSocialStatus.Text = emp.SocialStatus;
                guna2TxtStartJob.Text = emp.StartJob;
                guna2TxtEndJob.Text = emp.EndJob;
                guna2cbxState.Text = emp.State;
                if (emp.Photo != String.Empty)
                {
                    try
                    {
                        guna2cpPicture.Load(emp.Photo);
                        photo = emp.Photo;
                    }
                    catch
                    {
                        //MessageBox.Show("No photo");
                    }
                }
                employee_to_Update = emp;
                lblTitle.Text = "Update";
            }
            else
            {
                lblTitle.Text = "Registration";
                lblState.Visible = false;
                guna2cbxState.Visible = false;
            }
            // Clean the file
            repository.Clean_the_file("Employees/Employee_Identity_ToUpdate.txt");
        }

        public Employee Save_Info()
        {
            Employee employee = new Employee();

            employee.Name = guna2TxtName.Text;
            employee.PostName = guna2TxtPostName.Text;
            employee.GivenName = guna2TxtGivenName.Text;

            employee.Age = (int)guna2NupDwAge.Value;
            employee.BirthDay = guna2TxtBirthDay.Text;
            if (guna2cbxGender.Text.ToLower() == "male") employee.Gender = 'M';
            else employee.Gender = 'F';

            employee.Country = guna2TxtCountry.Text;
            employee.Post = guna2TxtPost.Text;
            employee.Id = guna2TxtID.Text;
            employee.Department = guna2cbxDepartment.Text;

            employee.ContractType = guna2cbxContractType.Text;

            employee.SocialStatus = guna2cbxSocialStatus.Text;
            employee.StartJob = guna2TxtStartJob.Text;

            if (guna2cbxContractType.Text.ToLower() == "definite") employee.EndJob = guna2TxtEndJob.Text;
            else employee.EndJob = string.Empty;

            employee.Photo = photo;

            DateTime today = DateTime.Now;
            employee.Date = Date();

            return employee;
        }

        public void Register_Employee(Employee employee)
        {
            employee.State = "Active";

            repository.Read_Employees("Employees/inputEmployees.txt");
            repository.Read_Salary("Employees/inputEmployees.txt", "Employees/Salary.txt");

            repository.Add_Employees(employee);
            repository.Add_Salary(employee);
            repository.Add_EmployeeAdded_inThe_History(employee);

            repository.SaveEmployeesIdentities("Employees/inputEmployees.txt", repository.GetEmployees());
            repository.SaveEmployees_Salary("Employees/Salary.txt", repository.Get_Salary());
            repository.Track_Employees("Employees/Track_Added_Employees.txt", "Employees/History.txt", repository.Get_History_of_Added_Employee(), "add");

            this.Close();
        }

        public void Update_Employee(Employee employee_to_update, Employee employee)
        {
            employee.State = guna2cbxState.Text;

            repository.Read_Employees("Employees/inputEmployees.txt");
            repository.Read_Salary("Employees/inputEmployees.txt", "Employees/Salary.txt");

            foreach (Employee emp in repository.GetEmployees())
            {
                if (emp.Name.ToLower() == employee_to_update.Name.ToLower() &&
                    emp.PostName.ToLower() == employee_to_update.PostName.ToLower() &&
                    emp.GivenName.ToLower() == employee_to_update.GivenName.ToLower() &&
                    emp.BirthDay.ToLower() == employee_to_update.BirthDay.ToLower())
                {
                    emp.Name = employee.Name;
                    emp.PostName = employee.PostName;
                    emp.GivenName = employee.GivenName;
                    emp.Age = employee.Age;
                    emp.BirthDay = employee.BirthDay;
                    emp.Gender = employee.Gender;
                    emp.Country = employee.Country;
                    emp.Post = employee.Post;
                    emp.Id = employee.Id;
                    emp.Department = employee.Department;
                    emp.ContractType = employee.ContractType;
                    emp.SocialStatus = employee.SocialStatus;
                    emp.StartJob = employee.StartJob;
                    emp.EndJob = employee.EndJob;
                    emp.State = employee.State;
                    emp.Photo = employee.Photo;

                    emp.Date = Date();

                    repository.SaveEmployeesIdentities("Employees/inputEmployees.txt", repository.GetEmployees());
                    foreach (Employee salary in repository.Get_Salary())
                    {
                        if (employee_to_update.Name.ToLower() == salary.Name.ToLower() &&
                           employee_to_update.PostName.ToLower() == salary.PostName.ToLower() &&
                           employee_to_update.GivenName.ToLower() == salary.GivenName.ToLower() &&
                           employee_to_update.BirthDay.ToLower() == salary.BirthDay.ToLower())
                        {
                            salary.Name = emp.Name;
                            salary.PostName = emp.PostName;
                            salary.GivenName = emp.GivenName;
                            salary.Age = emp.Age;
                            salary.BirthDay = emp.BirthDay;
                            salary.Id = emp.Id;
                            salary.Department = emp.Department;

                            repository.SaveEmployees_Salary("Employees/Salary.txt", repository.Get_Salary());
                        }
                    }
                    // Keep track
                    repository.Add_EmployeesUpdated_inThe_History(emp);
                    repository.Track_Employees("Employees/Track_Updated_Employees.txt", "Employees/History.txt", repository.Get_History_of_Updated_Employee(), "update");
                }
            }
            this.Close();
        }

        public string Date()
        {
            DateTime today = DateTime.Now;
            return today.ToString();

        }

        public void Warning()
        {
            lblWarning.Text = string.Empty;
            guna2btnSubmit.FillColor = Color.Teal;
        }


        // End of Personalized methodes
    }
}
