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
using Guna.UI2.WinForms;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace MyProject_v002.User_Controlers
{
    public partial class UC_Salary : UserControl
    {
        public Repository repository = new Repository();
        public string currency = string.Empty;
        public List<Employee> Salary_ofThe_employee_to_Update = new List<Employee>();
        Fls fls = new Fls();
        public UC_Salary()
        {
            InitializeComponent();
        }

        private void UC_Salary_Load(object sender, EventArgs e)
        {
            //repository.Read_Department("Employees/Departments.txt");
            repository.Read_Department(fls.Department());
            repository.Get_Departmnts();
            foreach(var department in repository.Get_Departmnts())
            {
                guna2cbxDepartmt.Items.Add(department);
            }
        }

        private void guna2DataGridViewSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //repository.Read_Salary("Employees/inputEmployees.txt", "Employees/Salary.txt");
            repository.Read_Salary(fls.inputEmployees(), fls.Salary());

            if (e.RowIndex >= 0) // Si l'index est superieur a 0.
            {
                if (guna2DataGridViewSalary.Rows[e.RowIndex].IsNewRow == false) // Si ce n'est pas la ligne vide
                {
                    // Recuprere la valeur de la colonne 0 de la ligne cliquee.
                    string name = guna2DataGridViewSalary.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string postName = guna2DataGridViewSalary.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string givenName = guna2DataGridViewSalary.Rows[e.RowIndex].Cells[2].Value.ToString();

                    foreach (Employee emp in repository.Get_Salary())
                    {
                        if (emp.Name.ToLower() == name.ToLower() && emp.PostName.ToLower() == postName.ToLower() && emp.GivenName.ToLower() == givenName.ToLower())
                        {
                            // Save this employee in case we want to update
                            Salary_ofThe_employee_to_Update.Clear();
                            Salary_ofThe_employee_to_Update.Add(emp);
                            guna2btnUpdate.FillColor = Color.Teal;
                            guna2btnUpdate.ForeColor = Color.White;
                        }
                    }
                }
            }
            else
            {
                Salary_ofThe_employee_to_Update.Clear();
                guna2btnUpdate.FillColor = Color.DarkGray;
            }
        }

        // Search the employee according to the department
        private void guna2TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (repository.Get_Salary().Count != 0)

            {
                guna2DataGridViewSalary.Rows.Clear();

                for (int i = 0; i < repository.Get_Salary().Count; i++)
                {
                    Print_Employees_by_Category(repository.Get_Salary()[i], currency);  
                }
            }
        }

        private void guna2cbxDepartmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TxtCurrency.Text.Length <= 5)
            {
                Print_Employees_Salary(guna2TxtCurrency.Text);
            }
                
        }

        private void guna2TxtCurrency_TextChanged(object sender, EventArgs e)
        {
            if(guna2TxtCurrency.Text.Length <= 5 && guna2TxtCurrency.Text.Length > 0)
            {
                Print_Employees_Salary(guna2TxtCurrency.Text);
                currency = guna2TxtCurrency.Text;
            }
        }

        private void guna2cbxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(guna2cbxCurrency.Text.Length > 0)
            {
                Print_Employees_Salary(guna2cbxCurrency.Text);
                currency = guna2cbxCurrency.Text;
            }
        }

        private void guna2NupDwAddSalaryToAll_ValueChanged(object sender, EventArgs e)
        {
            Check_Amount(guna2NupDwAddSalaryToAll);
        }

        private void guna2NupDwSubstractSalaryToAll_ValueChanged(object sender, EventArgs e)
        {
            Check_Amount(guna2NupDwSubstractSalaryToAll);
        }

        private void guna2NupDwAddBonusToAll_ValueChanged(object sender, EventArgs e)
        {
            Check_Amount(guna2NupDwAddBonusToAll);
        }

        private void guna2NupDwSubstractBonusToAll_ValueChanged(object sender, EventArgs e)
        {
            Check_Amount(guna2NupDwSubstractBonusToAll);
        }

        // Add the usual salary to all employees according to the selected department
        private void guna2btnAddSalaryToAll_Click(object sender, EventArgs e)
        {
            Add_Or_Substract(guna2NupDwAddSalaryToAll);
        }

        // Add the bonus to all employees according to the selected department
        private void guna2btnAddBonusToAll_Click(object sender, EventArgs e)
        {
            Add_Or_Substract(guna2NupDwAddBonusToAll);
        }

        // Substract the usual salary to all employees according to the selected department
        private void guna2btnSubstractSalaryToAll_Click(object sender, EventArgs e)
        {
            Add_Or_Substract(guna2NupDwSubstractSalaryToAll);
        }

        // Substract the bonus to all employees according to the selected department
        private void guna2btnSubstractBonusToAll_Click(object sender, EventArgs e)
        {
            Add_Or_Substract(guna2NupDwSubstractBonusToAll);
        }

        // Update the salary of the employee 
        private void guna2btnUpdate_Click(object sender, EventArgs e)
        {
            if(Salary_ofThe_employee_to_Update.Count > 0)
            {
                //repository.Save_Salary_of_the_Employee_ToUpdate("Employees/Salary_ofThe_Employee_to_Update.txt", Salary_ofThe_employee_to_Update);
                repository.Save_Salary_of_the_Employee_ToUpdate(fls.Salary_ofThe_Employee_to_Update(), Salary_ofThe_employee_to_Update);
                Update_Salary up = new Update_Salary();
                up.ShowDialog();
            }
            else
            {
                if(guna2cbxDepartmt.Text == string.Empty) MessageBox.Show("Select the department...", "Warning !!!");
                else MessageBox.Show("Select the employee...", "Warning !!!");
            }
        }



        // Beginning of personalized methodes

        // Print employees' salary according to the department
        public void Print_Employees_Salary(string curr)
        {
            double total = 0;
            double total_Since = 0;

            //repository.Read_Salary("Employees/inputEmployees.txt", "Employees/Salary.txt");
            repository.Read_Salary(fls.inputEmployees(), fls.Salary());

            guna2DataGridViewSalary.Rows.Clear();

            foreach (var salary in repository.Get_Salary())
            {
                if (salary.Department.ToLower() == guna2cbxDepartmt.Text.ToLower())
                {
                    string date = string.Empty;
                    if(salary.LastPayment.Length > 0)
                    {
                        string[] splitDate = salary.LastPayment.Split();
                        date = splitDate[0];
                    }
                    guna2DataGridViewSalary.Rows.Add(salary.Name.ToUpper(), salary.PostName.ToUpper(), salary.GivenName.ToUpper(), salary.Id,
                                                        salary.UsualAmount + $" {curr}", date, salary.Mounth, salary.Overtime + " H",
                                                        salary.Bonus + $" {curr}", salary.Total + $" {curr}", salary.TotalAmountSinceYouStartedJob + $" {curr}");
                    total += salary.Total;
                    total_Since += salary.TotalAmountSinceYouStartedJob;
                }
            }
            lblTotal.Text = total.ToString() + " " + curr;
            lblTotalSince.Text = total_Since.ToString() + " " + curr;
        }

        // Add salary or bonus to all employees
        public void Add_Salary_or_Bonus_ToAll_Employees(double usualAmount, double bonus)
        {
            if(usualAmount > 0 || bonus > 0)
            {
                //repository.Read_Salary("Employees/inputEmployees.txt", "Employees/Salary.txt");
                repository.Read_Salary(fls.inputEmployees(), fls.Salary());
                
                foreach (Employee salary in repository.Get_Salary())
                {
                    if (salary.Department == guna2cbxDepartmt.Text)
                    {
                        if (usualAmount > 0)
                        {
                            if (salary.Mounth.ToLower() == guna2cbxMounth.Text.ToLower())
                            {
                                salary.UsualAmount += usualAmount;
                                salary.Total = salary.UsualAmount + salary.Bonus;
                                salary.TotalAmountSinceYouStartedJob += usualAmount;
                            }
                            else
                            {
                                salary.UsualAmount = usualAmount;
                                //salary.Bonus = bonus;
                                salary.Total = salary.UsualAmount + salary.Bonus;
                                salary.TotalAmountSinceYouStartedJob += usualAmount;
                            }
                            salary.Mounth = guna2cbxMounth.Text;
                            DateTime today = DateTime.Now;
                            salary.LastPayment = today.ToString();

                            Keep_All_UsualAmount_of_the_Year(salary);

                        }
                        else if(bonus > 0)
                        {
                            if(salary.MounthBonus.ToLower() != guna2cbxMounth.Text.ToLower())
                            {
                                //salary.UsualAmount = usualAmount;
                                salary.Bonus = bonus;
                                salary.Total = salary.Bonus + salary.UsualAmount;
                                salary.TotalAmountSinceYouStartedJob += bonus;
                            }
                            else
                            {
                                salary.Bonus += bonus;
                                salary.Total = salary.Bonus + salary.UsualAmount;
                                salary.TotalAmountSinceYouStartedJob += bonus;
                            }
                            salary.MounthBonus = guna2cbxMounth.Text;

                            Keep_All_Bonus_of_the_Year(salary);
                        }
                    }
                }
                usualAmount = 0;
                bonus = 0;

                //repository.SaveEmployees_Salary("Employees/Salary.txt", repository.Get_Salary());
                repository.SaveEmployees_Salary(fls.Salary(), repository.Get_Salary());
                
                MessageBox.Show("Successfull !!!", "Info !");
            }
        }

        // Substract salary or bonus to all employees
        public void Substract_Salary_or_Bonus_ToAll_Employees(double usualAmount, double bonus)
        {
            if (usualAmount > 0 || bonus > 0)
            {
                //repository.Read_Salary("Employees/inputEmployees.txt", "Employees/Salary.txt");
                repository.Read_Salary(fls.inputEmployees(), fls.Salary());
                foreach (Employee salary in repository.Get_Salary())
                {
                    if (salary.Department == guna2cbxDepartmt.Text)
                    {
                        if (usualAmount > 0)
                        {
                            if (salary.Mounth.ToLower() == guna2cbxMounth.Text.ToLower() && salary.UsualAmount >= usualAmount)
                            {
                                salary.UsualAmount -= usualAmount;
                                salary.Total = (salary.Total - usualAmount) + salary.Bonus;
                                salary.TotalAmountSinceYouStartedJob -= usualAmount;

                                Keep_All_UsualAmount_of_the_Year(salary);
                            }
                            else
                            {
                                MessageBox.Show($"Impossible...\nThe amount is bigger than the salary of employees.\nOr the the mounth is not equal to {salary.Mounth}", "Warning !");
                                return;
                            }
                        }
                        else if (bonus > 0)
                        {
                            if (salary.MounthBonus.ToLower() == guna2cbxMounth.Text.ToLower() && salary.Bonus >= bonus)
                            {
                                salary.Bonus -= bonus;
                                salary.Total = (salary.Total - salary.Bonus) + salary.UsualAmount;
                                salary.TotalAmountSinceYouStartedJob -= bonus;

                                Keep_All_Bonus_of_the_Year(salary);
                            }
                            else
                            {
                                MessageBox.Show($"Impossible...\nThe amount is bigger than the bonus of employees.\nOr the the mounth is not equal to {salary.Mounth}", "Warning !");
                                return;
                            }
                        }
                        salary.Mounth = guna2cbxMounth.Text;
                        DateTime today = DateTime.Now;
                        salary.LastPayment = today.ToString();
                    }
                }
                usualAmount = 0;
                bonus = 0;
                //repository.SaveEmployees_Salary("Employees/Salary.txt", repository.Get_Salary());
                repository.SaveEmployees_Salary(fls.Salary(), repository.Get_Salary());
                MessageBox.Show("Successfull !!!", "Info !");
            }
        }

        public void Print_Employees_by_Category(Employee employee, string curr)
        {
            if (employee.Name.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2TxtSearch.Text.ToLower()) &&
                       employee.Department == guna2cbxDepartmt.Text)
            {
                string date = string.Empty;
                if (employee.LastPayment.Length > 0)
                {
                    string[] splitDate = employee.LastPayment.Split();
                    date = splitDate[0];
                }

                guna2DataGridViewSalary.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id,
                                                        employee.UsualAmount + $" {curr}", date, employee.Mounth, employee.Overtime + " H",
                                                        employee.Bonus + $" {curr}", employee.Total + $" {curr}", employee.TotalAmountSinceYouStartedJob + $" {curr}");
            }
        }

        public void Add_Or_Substract(Guna2NumericUpDown value)
        {
            if (guna2cbxMounth.Text.Length > 0)
            {
                if (guna2cbxDepartmt.Text.Length > 0)
                {
                    if (value.Value > 0)
                    {
                        if (guna2NupDwAddSalaryToAll.Value > 0)
                        {
                            Add_Salary_or_Bonus_ToAll_Employees(Convert.ToDouble(guna2NupDwAddSalaryToAll.Value), 0);
                        }
                        else if (guna2NupDwAddBonusToAll.Value > 0)
                        {
                            Add_Salary_or_Bonus_ToAll_Employees(0, Convert.ToDouble(guna2NupDwAddBonusToAll.Value));
                        }
                        else if (guna2NupDwSubstractSalaryToAll.Value > 0)
                        {
                            Substract_Salary_or_Bonus_ToAll_Employees(Convert.ToDouble(guna2NupDwSubstractSalaryToAll.Value), 0);
                        }
                        else if (guna2NupDwSubstractBonusToAll.Value > 0)
                        {
                            Substract_Salary_or_Bonus_ToAll_Employees(0, Convert.ToDouble(guna2NupDwSubstractBonusToAll.Value));
                        }
                        guna2NupDwAddSalaryToAll.Value = 0;
                        guna2NupDwAddBonusToAll.Value = 0;
                        guna2NupDwSubstractSalaryToAll.Value = 0;
                        guna2NupDwSubstractBonusToAll.Value = 0;
                    }
                    else MessageBox.Show("Impossible...\nSpecify the amount.\nThe amount can not be 0", "Warning !");
                }
                else MessageBox.Show("Impossible...\nChoose a department.", "Warning !");
            }
            else MessageBox.Show("Impossible...\nSpecify the mounth.", "Warning !");
        }

        // check if the amount entered by the user is grater than 0
        public void Check_Amount(Guna2NumericUpDown value)
        {
            // Set all four buttons to the initial color before changing the color of the selected numericUpDown
            guna2btnAddSalaryToAll.FillColor = Color.IndianRed;
            guna2btnAddSalaryToAll.ForeColor = Color.Black;

            guna2btnAddBonusToAll.FillColor = Color.IndianRed;
            guna2btnAddBonusToAll.ForeColor = Color.Black;

            guna2btnSubstractSalaryToAll.FillColor = Color.IndianRed;
            guna2btnSubstractSalaryToAll.ForeColor = Color.Black;

            guna2btnSubstractBonusToAll.FillColor = Color.IndianRed;
            guna2btnSubstractBonusToAll.ForeColor = Color.Black;

            if (guna2cbxMounth.Text.Length > 0)
            {
                if (guna2cbxDepartmt.Text.Length > 0)
                {
                    if (value.Value > 0)
                    {
                        if (value.Name.ToLower() == "guna2NupDwAddSalaryToAll".ToLower())
                        {
                            guna2btnAddSalaryToAll.FillColor = Color.Teal;
                            guna2btnAddSalaryToAll.ForeColor = Color.White;
                        }
                        else if (value.Name.ToLower() == "guna2NupDwAddBonusToAll".ToLower())
                        {
                            guna2btnAddBonusToAll.FillColor = Color.Teal;
                            guna2btnAddBonusToAll.ForeColor = Color.White;
                        }
                        else if (value.Name.ToLower() == "guna2NupDwSubstractSalaryToAll".ToLower())
                        {
                            guna2btnSubstractSalaryToAll.FillColor = Color.Teal;
                            guna2btnSubstractSalaryToAll.ForeColor = Color.White;
                        }
                        else if (value.Name.ToLower() == "guna2NupDwSubstractBonusToAll".ToLower())
                        {
                            guna2btnSubstractBonusToAll.FillColor = Color.Teal;
                            guna2btnSubstractBonusToAll.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        // Keep all usual amounts of the year (just one year).
        // The next year, all amounts of de previous year will be deleted.
        public void Keep_All_UsualAmount_of_the_Year(Employee salary)
        {
            if (guna2cbxMounth.Text.ToLower() == "january")
            {
                //salary.All_Usual_Amount_In_a_Year[0] = salary.UsualAmount;
                //salary.All_Usual_Amount_In_a_Year[1] = 0;
                //salary.All_Usual_Amount_In_a_Year[2] = 0;
                //salary.All_Usual_Amount_In_a_Year[3] = 0;
                //salary.All_Usual_Amount_In_a_Year[4] = 0;
                //salary.All_Usual_Amount_In_a_Year[5] = 0;
                //salary.All_Usual_Amount_In_a_Year[6] = 0;
                //salary.All_Usual_Amount_In_a_Year[7] = 0;
                //salary.All_Usual_Amount_In_a_Year[8] = 0;
                //salary.All_Usual_Amount_In_a_Year[9] = 0;
                //salary.All_Usual_Amount_In_a_Year[10] = 0;
                //salary.All_Usual_Amount_In_a_Year[11] = 0;
                for(int i = 1; i < 12; i++)
                {
                    salary.All_Usual_Amount_In_a_Year[i] = 0;
                }
            }
            if (guna2cbxMounth.Text.ToLower() == "february") salary.All_Usual_Amount_In_a_Year[1] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "march") salary.All_Usual_Amount_In_a_Year[2] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "april") salary.All_Usual_Amount_In_a_Year[3] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "may") salary.All_Usual_Amount_In_a_Year[4] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "june") salary.All_Usual_Amount_In_a_Year[5] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "july") salary.All_Usual_Amount_In_a_Year[6] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "august") salary.All_Usual_Amount_In_a_Year[7] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "september") salary.All_Usual_Amount_In_a_Year[8] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "october") salary.All_Usual_Amount_In_a_Year[9] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "november") salary.All_Usual_Amount_In_a_Year[10] = salary.UsualAmount;
            if (guna2cbxMounth.Text.ToLower() == "december") salary.All_Usual_Amount_In_a_Year[11] = salary.UsualAmount;

            foreach (Employee emp in repository.Get_Salary())
            {
                if (emp.Name.ToLower() == salary.Name.ToLower() &&
                    emp.PostName.ToLower() == salary.PostName.ToLower() &&
                    emp.GivenName.ToLower() == salary.GivenName.ToLower() &&
                    emp.BirthDay.ToLower() == salary.BirthDay.ToLower())
                {
                    emp.All_Usual_Amount_In_a_Year = salary.All_Usual_Amount_In_a_Year;

                    //repository.SaveEmployees_Salary("Employees/Salary.txt", repository.Get_Salary());
                    repository.SaveEmployees_Salary(fls.Salary(), repository.Get_Salary());
                    return;
                }
            }
            
        }

        // Keep all bonus of the year (just one year).
        // The next year, all bonus of de previous year will be deleted.
        public void Keep_All_Bonus_of_the_Year(Employee salary)
        {
            if (guna2cbxMounth.Text.ToLower() == "january")
            {
                salary.All_Bonus_In_a_Year[0] = salary.Bonus;
                salary.All_Bonus_In_a_Year[1] = 0;
                salary.All_Bonus_In_a_Year[2] = 0;
                salary.All_Bonus_In_a_Year[3] = 0;
                salary.All_Bonus_In_a_Year[4] = 0;
                salary.All_Bonus_In_a_Year[5] = 0;
                salary.All_Bonus_In_a_Year[6] = 0;
                salary.All_Bonus_In_a_Year[7] = 0;
                salary.All_Bonus_In_a_Year[8] = 0;
                salary.All_Bonus_In_a_Year[9] = 0;
                salary.All_Bonus_In_a_Year[10] = 0;
                salary.All_Bonus_In_a_Year[11] = 0;
            }
            if (guna2cbxMounth.Text.ToLower() == "february") salary.All_Bonus_In_a_Year[1] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "march") salary.All_Bonus_In_a_Year[2] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "april") salary.All_Bonus_In_a_Year[3] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "may") salary.All_Bonus_In_a_Year[4] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "june") salary.All_Bonus_In_a_Year[5] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "july") salary.All_Bonus_In_a_Year[6] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "august") salary.All_Bonus_In_a_Year[7] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "september") salary.All_Bonus_In_a_Year[8] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "october") salary.All_Bonus_In_a_Year[9] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "november") salary.All_Bonus_In_a_Year[10] = salary.Bonus;
            if (guna2cbxMounth.Text.ToLower() == "december") salary.All_Bonus_In_a_Year[11] = salary.Bonus;

            foreach (Employee emp in repository.Get_Salary())
            {
                if (emp.Name.ToLower() == salary.Name.ToLower() &&
                    emp.PostName.ToLower() == salary.PostName.ToLower() &&
                    emp.GivenName.ToLower() == salary.GivenName.ToLower() &&
                    emp.BirthDay.ToLower() == salary.BirthDay.ToLower())
                {
                    emp.All_Usual_Amount_In_a_Year = salary.All_Usual_Amount_In_a_Year;

                    //repository.SaveEmployees_Salary("Employees/Salary.txt", repository.Get_Salary());
                    repository.SaveEmployees_Salary(fls.Salary(), repository.Get_Salary());
                    return;
                }
            }

        }

        // End of personalized methodes
    }
}
