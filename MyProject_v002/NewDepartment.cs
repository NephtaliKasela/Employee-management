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

namespace MyProject_v002
{
    public partial class NewDepartment : Form
    {
        public Repository repository = new Repository();
        Fls fls = new Fls();    
        public NewDepartment()
        {
            InitializeComponent();

            // Open the department file and get all department names and add them to the list
            //repository.Read_Department("Employees/Departments.txt");
            repository.Read_Department(fls.Department());
            if(repository.Get_Departmnts().Count > 0)
            {
                foreach (string s in repository.Get_Departmnts())
                {
                    listBox.Items.Add(s);
                }
            }
        }

        // Add a new department
        private void guna2btnAddNewDepartment_Click(object sender, EventArgs e)
        {
            if (guna2TxtDepartmt.Text != string.Empty)
            {
                repository.Add_Department(guna2TxtDepartmt.Text);
                //repository.Save_Departments(repository.Get_Departmnts(), "Employees/Departments.txt");
                repository.Save_Departments(repository.Get_Departmnts(), fls.Department());
                listBox.Items.Add(guna2TxtDepartmt.Text);
                lblWarning.Text = "Department was added successfully !";
                lblWarning.ForeColor = Color.Lime;
                guna2TxtDepartmt.Text = string.Empty;
            }
            else
            {
                lblWarning.Text = "Impossible to add !";
                lblWarning.ForeColor = Color.MediumVioletRed;
            }
        }

        // Delete a department if at least one is selected
        private void guna2btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                repository.Delete_Department(listBox.SelectedItem.ToString());
                //repository.Save_Departments(repository.Get_Departmnts(), "Employees/Departments.txt");
                repository.Save_Departments(repository.Get_Departmnts(), fls.Department());
                listBox.Items.Remove(listBox.SelectedItem.ToString());

                lblWarning.Text = "Department was deleted successfully !";
                lblWarning.ForeColor = Color.Lime;
            }
            else MessageBox.Show("Select the department", "Warning !");

        }

        private void guna2TxtDepartmt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
