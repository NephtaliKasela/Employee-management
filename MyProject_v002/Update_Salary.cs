using Guna.UI2.WinForms;
using MyProject_v002.BisinessObjects;
using MyProject_v002.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject_v002
{
    public partial class Update_Salary : Form
    {
        Repository repository = new Repository();
        Employee employee_to_Update = new Employee();
        Fls fls = new Fls();
        public Update_Salary()
        {
            InitializeComponent();

            // fill all info about the employee
            //repository.Read_Salary("Employees/inputEmployees.txt", "Employees/Salary_ofThe_Employee_to_Update.txt");
            repository.Read_Salary(fls.inputEmployees(), fls.Salary_ofThe_Employee_to_Update());
            if(repository.Get_Salary().Count > 0)
            {
                lblEmployeeName.Text = (repository.Get_Salary()[0].Name + " " + repository.Get_Salary()[0].PostName + " " + repository.Get_Salary()[0].GivenName).ToUpper();
                lblEmployeeID.Text = repository.Get_Salary()[0].Id;
                guna2NupDwOvertime.Value = Convert.ToDecimal(repository.Get_Salary()[0].Overtime);

                for (int i = 11; i >= 0; i--)
                {
                    if (Display_amount(i) == true) break;
                    else continue;
                }
            }
        }


        // Beginning of personalized methodes
        public bool Display_amount(int index)
        {
            if (index == 11 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[11] > 0)
            {
                guna2cbxMounths.Text = "December";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[11]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[11]);
                return true;
            }
            else if (index == 10 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[10] > 0)
            {
                guna2cbxMounths.Text = "November";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[10]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[10]);
                return true;
            }
            else if (index == 9 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[9] > 0)
            {
                guna2cbxMounths.Text = "October";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[9]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[9]);
                return true;
            }
            else if (index == 8 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[8] > 0)
            {
                guna2cbxMounths.Text = "September";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[8]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[8]);
                return true;
            }
            else if (index == 7 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[7] > 0)
            {
                guna2cbxMounths.Text = "August";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[7]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[7]);
                return true;
            }
            else if (index == 6 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[6] > 0)
            {
                guna2cbxMounths.Text = "July";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[6]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[6]);
                return true;
            }
            else if (index == 5 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[5] > 0)
            {
                guna2cbxMounths.Text = "June";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[5]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[5]);
                return true;
            }
            else if (index == 4 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[4] > 0)
            {
                guna2cbxMounths.Text = "May";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[4]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[4]);
                return true;
            }
            else if (index == 3 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[3] > 0)
            {
                guna2cbxMounths.Text = "April";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[3]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[3]);
                return true;
            }
            else if (index == 2 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[2] > 0)
            {
                guna2cbxMounths.Text = "March";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[2]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[2]);
                return true;
            }
            else if (index == 1 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[1] > 0)
            {
                guna2cbxMounths.Text = "February";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[1]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[1]);
                return true;
            }
            else if (index == 0 && repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[0] > 0)
            {
                guna2cbxMounths.Text = "January";
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[0]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[0]);
                return true;
            }
            return false;
        }

        public void Display_amount_by_Mounth(Guna2ComboBox guna2cbxMounths)
        {
            if (guna2cbxMounths.Text.ToLower() == "january")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[0]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[0]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "february")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[1]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[1]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "march")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[2]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[2]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "april")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[3]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[3]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "may")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[4]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[4]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "june")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[5]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[5]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "july")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[6]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[6]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "august")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[7]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[7]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "september")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[8]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[8]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "october")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[9]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[9]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "november")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[10]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[10]);
            }
            else if (guna2cbxMounths.Text.ToLower() == "december")
            {
                guna2NupDwUsual_Amount.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Usual_Amount_In_a_Year[11]);
                guna2NupDwBonus.Value = Convert.ToDecimal(repository.Get_Salary()[0].All_Bonus_In_a_Year[11]);
            }
        }

        // End of personalized methodes

        private void guna2btnAddUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will be available in the next version !", "info !");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will be available in the next version !", "info !");
        }

        private void guna2cbxMounths_SelectedIndexChanged(object sender, EventArgs e)
        {
            Display_amount_by_Mounth(guna2cbxMounths);
        }
    }
}
