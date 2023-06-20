using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

using MyProject_v002.DataAccess;
using MyProject_v002.BisinessObjects;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace MyProject_v002.User_Controlers
{
    public partial class UC_Employees : UserControl
    {
        public Repository repository = new Repository();
        public Employee employee_To_Delete_or_Update = new Employee();
        Fls fls = new Fls();
        public UC_Employees()
        {
            InitializeComponent();
        }

        private void UC_Employees_Load(object sender, EventArgs e)
        {
            // Get all employees, actualize the age and print them
            //repository.Actualize_Age("Employees/inputEmployees.txt");
            //repository.Read_Employees("Employees/inputEmployees.txt");

            repository.Actualize_Age(fls.inputEmployees());
            repository.Read_Employees(fls.inputEmployees());
            //repository.GetEmployees();
            // Get all department and print print them
            //repository.Read_Department("Employees/Departments.txt");

            repository.Read_Department(fls.Department());
            repository.Get_Departmnts();
            foreach (var department in repository.Get_Departmnts())
            {
                guna2cbxDepartment.Items.Add(department);
            }

            // Set one button to true
            guna2btnAllemployees.Checked = true;
            guna2btnAllemployees_Click(sender, e);
        }

        // Search the employee by a fragment of his name
        private void guna2txtSearchByName_TextChanged_1(object sender, EventArgs e)
        {
            if (repository.GetEmployees().Count != 0)
            {
                guna2DataGridView.Rows.Clear();

                foreach (Employee employee in repository.GetEmployees())
                {
                    SearchTheName(employee);
                }
            }
        }

        // Print the employee's identity when he is selected
        private void guna2DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Si l'index est superieur a 0.
            {
                if (guna2DataGridView.Rows[e.RowIndex].IsNewRow == false) // Si ce n'est pas la ligne vide
                {
                    // Recuprere la valeur de la colonne 0 de la ligne cliquee.
                    string name = guna2DataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string postName = guna2DataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string givenName = guna2DataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();

                    foreach (Employee emp in repository.GetEmployees())
                    {
                        if (emp.Name.ToLower() == name.ToLower() && emp.PostName.ToLower() == postName.ToLower() && emp.GivenName.ToLower() == givenName.ToLower())
                        {
                            lblName.Text = emp.Name.ToUpper();
                            lblPostName.Text = emp.PostName.ToUpper();
                            lblGivenNane.Text = emp.GivenName.ToUpper();

                            lblAge.Text = emp.Age.ToString();
                            lblBirthDay.Text = emp.BirthDay;
                            lblGender.Text = emp.Gender.ToString();
                            lblCountry.Text = emp.Country;

                            lblPost.Text = emp.Post.ToUpper();
                            lbl_ID.Text = emp.Id;
                            lblDepartement.Text = emp.Department;
                            lblContractType.Text = emp.ContractType;
                            lblSocialStatus.Text = emp.SocialStatus;

                            lblStartJob.Text = emp.StartJob;
                            lblEndJob.Text = emp.EndJob;

                            lblState.Text = emp.State;
                            if (lblState.Text.ToLower() == "active") 
                            { 
                                lblState.ForeColor = Color.Lime; 
                                guna2cbxState.BorderColor = Color.Lime;
                            }
                            else if(lblState.Text.ToLower() == "non active")
                            {
                                lblState.ForeColor = Color.DeepPink;
                                guna2cbxState.BorderColor = Color.DeepPink;
                            }
                            else if (lblState.Text.ToLower() == "holiday")
                            {
                                lblState.ForeColor = Color.DarkGoldenrod;
                                guna2cbxState.BorderColor = Color.DarkGoldenrod;
                            }

                            try
                            {
                                Picture.Load(emp.Photo);
                                Picture.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            catch
                            {
                                //MessageBox.Show("No photo");
                            }

                            // Save this employee in case we want to delete him or update
                            employee_To_Delete_or_Update = emp;
                        }
                    }
                }
            }
        }

        // Print employees' identities according to the selected button (All employees, Active, etc...)
        private void guna2btnAllemployees_Click(object sender, EventArgs e)
        {
            Check_Selected_Button(guna2btnAllemployees);
            PrintNames();
        }

        private void guna2btnDefiniteCont_Click(object sender, EventArgs e)
        {
            Check_Selected_Button(guna2btnDefiniteCont);
            PrintNames();
        }

        private void guna2btnInDefiniteCont_Click(object sender, EventArgs e)
        {
            Check_Selected_Button(guna2btnInDefiniteCont);
            PrintNames();
        }

        private void guna2btnActive_Click(object sender, EventArgs e)
        {
            Check_Selected_Button(guna2btnActive);
            PrintNames();
        }

        private void guna2btnNoneActive_Click(object sender, EventArgs e)
        {
            Check_Selected_Button(guna2btnNoneActive);
            PrintNames();
        }

        // Search the employee by date
        private void guna2TxtSearchByStartJob_TextChanged(object sender, EventArgs e)
        {
            guna2TxtSearchByEndJob.Text = string.Empty;
            if (guna2TxtSearchByStartJob.Text.Length == 1) MessageBox.Show("Example: DD.MM.YYYY\n\t01.01.1919\n\t     01.1919\n\t          1919", "Info");
            PrintNamesByDate(guna2TxtSearchByStartJob, "start");
            if (guna2TxtSearchByStartJob.Text.Length > 10) MessageBox.Show("Example: DD.MM.YYYY\n\t01.01.1919\n\t     01.1919\n\t          1919", "Info");
        }

        private void guna2TxtSearchByEndJob_TextChanged(object sender, EventArgs e)
        {
            guna2TxtSearchByStartJob.Text = string.Empty;
            if (guna2TxtSearchByEndJob.Text.Length == 1) MessageBox.Show("Example: DD.MM.YYYY\n\t01.01.1919\n\t     01.1919\n\t          1919", "Info");
            PrintNamesByDate(guna2TxtSearchByEndJob, "end");
            if (guna2TxtSearchByEndJob.Text.Length > 10) MessageBox.Show("Example: DD.MM.YYYY\n\t01.01.1919\n\t     01.1919\n\t          1919", "Info");
        }

        private void guna2btnDelete_Click(object sender, EventArgs e)
        {
            if (lblName.Text.Length > 0)
            {
                //System.IO.File.WriteAllText("Employees/Deleted_Employees.txt", "");
                File.WriteAllText(fls.Deleted_Employees(), "");

                repository.Add_Employee_ToDelete(employee_To_Delete_or_Update);
                //repository.Save_Deleted_Employees("Employees/Deleted_Employees.txt", repository.Get_Deleted_Employee());
                repository.Save_Deleted_Employees(fls.Deleted_Employees(), repository.Get_Deleted_Employee());

                Confirmation_Delete_Employee conf = new Confirmation_Delete_Employee();
                conf.ShowDialog();
            }
            else MessageBox.Show("Select the employee..!", "Warning");
        }

        private void guna2btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblName.Text.Length > 0)
            {
                repository.Add_Employee_Identity_ToUpdate(employee_To_Delete_or_Update);
                //repository.Save_Employee_Identity_ToUpdate("Employees/Employee_Identity_ToUpdate.txt", repository.Get_Employee_Identity_ToUpdate());
                repository.Save_Employee_Identity_ToUpdate(fls.Employee_Identity_ToUpdate(), repository.Get_Employee_Identity_ToUpdate());

                NewEmployee nw = new NewEmployee();
                nw.ShowDialog();
            }
            else MessageBox.Show("Select the employee..!", "Warning");
        }

        private void guna2cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Uncheck_SelectedButton();
            guna2DataGridView.Rows.Clear();

            foreach (Employee employee in repository.GetEmployees())
            {
                if (employee.Department.ToLower() == guna2cbxDepartment.Text.ToLower())
                {
                    guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                }
            }
        }


        // Begining of Personalized methodes

        // Search by name
        public void SearchTheName(Employee employee)
        {
            if(guna2btnAllemployees.Checked)
            {
                if (employee.Name.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2txtSearchByName.Text.ToLower()))
                {
                    guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                }
            }
            else if(guna2btnDefiniteCont.Checked)
            {

                if ((employee.Name.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2txtSearchByName.Text.ToLower())) && employee.ContractType.ToLower() == "definite")
                {
                    guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                }
            }
            else if (guna2btnInDefiniteCont.Checked)
            {

                if ((employee.Name.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2txtSearchByName.Text.ToLower())) && employee.ContractType.ToLower() == "indefinite")
                {
                    guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                }
            }
            else if (guna2btnActive.Checked)
            {

                if ((employee.Name.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2txtSearchByName.Text.ToLower())) && employee.State.ToLower() == "active")
                {
                    guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                }
            }
            else if (guna2btnNoneActive.Checked)
            {

                if ((employee.Name.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2txtSearchByName.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2txtSearchByName.Text.ToLower())) && employee.State.ToLower() == "none active" || employee.State.ToLower() == "holiday")
                {
                    guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                }
            }

        }

        // Print employees' identities according to the selected button (All employees, Active, etc...)
        public void PrintNames()
        {
            guna2DataGridView.Rows.Clear();

            foreach (Employee employee in repository.GetEmployees())
            {
                if (guna2btnAllemployees.Checked)
                {
                    guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                }
                else if (guna2btnDefiniteCont.Checked)
                {

                    if (employee.ContractType.ToLower() == "definite")
                    {
                        guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                    }
                }
                else if (guna2btnInDefiniteCont.Checked)
                {

                    if (employee.ContractType.ToLower() == "indefinite")
                    {
                        guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                    }
                }
                else if (guna2btnActive.Checked)
                {

                    if (employee.State.ToLower() == "active")
                    {
                        guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                    }
                }
                else if (guna2btnNoneActive.Checked)
                {

                    if (employee.State.ToLower() == "non active" || employee.State.ToLower() == "holiday")
                    {
                        guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                    }
                }
            }
        }

        // Print employees' identities according to the date (start or end of job)
        public void PrintNamesByDate(Guna2TextBox text, string start_or_End)
        {
            guna2DataGridView.Rows.Clear();

            foreach (Employee employee in repository.GetEmployees())
            {
                if (guna2btnAllemployees.Checked)
                {
                    CheckTheDate(employee, text, start_or_End);
                }
                else if (guna2btnDefiniteCont.Checked)
                {

                    if (employee.ContractType.ToLower() == "definite")
                    {
                        CheckTheDate(employee, text, start_or_End);
                    }
                }
                else if (guna2btnInDefiniteCont.Checked)
                {

                    if (employee.ContractType.ToLower() == "indefinite")
                    {
                        CheckTheDate(employee, text, start_or_End);
                    }
                }
                else if (guna2btnActive.Checked)
                {

                    if (employee.State.ToLower() == "active")
                    {
                        CheckTheDate(employee, text, start_or_End);
                    }
                }
                else if (guna2btnNoneActive.Checked)
                {

                    if (employee.State.ToLower() == "non active" || employee.State.ToLower() == "holiday")
                    {
                        CheckTheDate(employee, text, start_or_End);
                    }
                }
            }
        }

        private void CheckTheDate(Employee employee, Guna2TextBox text, string start_or_End)
        {
            if (text.Text.Length <= 10 && text.Text.Length > 0)
            {
                if(start_or_End.ToLower() == "start")
                {
                    if(employee.StartJob.ToLower().Contains(guna2TxtSearchByStartJob.Text))
                    {
                        guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                    }
                }
                else
                {
                    if (employee.EndJob.ToLower().Contains(guna2TxtSearchByEndJob.Text))
                    {
                        guna2DataGridView.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper());
                    }
                }
            }
            else PrintNames();
        }

        public void Check_Selected_Button(Guna2Button button)
        {
            guna2cbxDepartment.Text = string.Empty;

            guna2btnAllemployees.Checked = false;
            guna2btnDefiniteCont.Checked = false;
            guna2btnInDefiniteCont.Checked = false;
            guna2btnActive.Checked = false;
            guna2btnNoneActive.Checked = false;

            button.Checked = true;
        }

        public void Uncheck_SelectedButton()
        {
            guna2btnAllemployees.Checked = false;
            guna2btnDefiniteCont.Checked = false;
            guna2btnInDefiniteCont.Checked = false;
            guna2btnActive.Checked = false;
            guna2btnNoneActive.Checked = false;
        }


        // End of Personalized methodes
    }
}
