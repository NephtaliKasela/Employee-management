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
    public partial class Confirmation_Reset_TheApp : Form
    {
        public Confirmation_Reset_TheApp()
        {
            InitializeComponent();
        }

        private void guna2btnReset_Click(object sender, EventArgs e)
        {
            if(guna2CstmRbtnResetHistory.Checked == true)
            {
                File.WriteAllText("Employees/History.txt", "");
                File.WriteAllText("Employees/Track_Added_Employees.txt", "");
                File.WriteAllText("Employees/Track_Deleted_Employees.txt", "");
                File.WriteAllText("Employees/Track_Updated_Employees.txt", "");

                this.Close();
                MessageBox.Show("Successful..!\nOnly the History was reseted.", "Info");
            }
            else if(guna2CstmRbtnReseEverything.Checked == true)
            {
                File.WriteAllText("Employees/inputEmployees.txt", "");
                File.WriteAllText("Employees/Salary.txt", "");
                File.WriteAllText("Employees/History.txt", "");
                File.WriteAllText("Employees/Departments.txt", "");
                File.WriteAllText("Employees/Employee_Identity_ToUpdate.txt", "");
                File.WriteAllText("Employees/Salary_ofThe_Employee_to_Update.txt", "");
                File.WriteAllText("Employees/Deleted_Employees.txt", "");
                File.WriteAllText("Employees/Track_Added_Employees.txt", "");
                File.WriteAllText("Employees/Track_Deleted_Employees.txt", "");
                File.WriteAllText("Employees/Track_Updated_Employees.txt", "");

                this.Close();
                MessageBox.Show("Successful..!\nEverything was reseted.", "Info");
            }
            else MessageBox.Show("Select what you need to reset !", "Info");
        }

        private void guna2btnNotReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
