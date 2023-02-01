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

namespace MyProject_v002.User_Controlers
{
    public partial class UC_History : UserControl
    {
        public Repository repository = new Repository();
        public UC_History()
        {
            InitializeComponent();
        }

        // if the user controller is loaded, open the history file and print the all history of employees
        private void UC_History_Load(object sender, EventArgs e)
        {
            repository.ReadHistory("Employees/History.txt");
            repository.Get_Employees_History();

            guna2btnRepportAll_Click(sender, e);
            guna2btnRepportAll.Checked = true;
        }

        // if one button is selected, print the history according to the the selected button
        private void guna2btnRepportAll_Click(object sender, EventArgs e)
        {
            Check_button_and_PrintHistory(guna2btnRepportAll);
        }

        private void guna2btnRepportEmpAdded_Click(object sender, EventArgs e)
        {
            Check_button_and_PrintHistory(guna2btnRepportEmpAdded);
        }

        private void guna2btnRepportEmpDeleted_Click(object sender, EventArgs e)
        {
            Check_button_and_PrintHistory(guna2btnRepportEmpDeleted);
        }

        private void guna2btnRepportUserConnected_Click(object sender, EventArgs e)
        {
            //Check_button_and_PrintHistory(guna2btnRepportUserConnected);
        }

        private void guna2btnRepportEmpUpdated_Click(object sender, EventArgs e)
        {
            Check_button_and_PrintHistory(guna2btnRepportEmpUpdated);
        }

        // Search and print employees history in the reverse order. from the last report to the first one
        private void guna2TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (repository.Get_Employees_History().Count != 0)

            {
                guna2DataGridViewHistory.Rows.Clear();

                for (int i = repository.Get_Employees_History().Count - 1; i >= 0; i--)
                {
                    Search_and_PrintTheHistory_by_Category(repository.Get_Employees_History()[i]);
                }
            }
        }


        // Begining of personalized methodes

        // Print the history according to the selected button (All employees, etc...)
        public void PrintHistory()
        {
            guna2DataGridViewHistory.Rows.Clear();

            for(int i = repository.Get_Employees_History().Count - 1; i >= 0; i--)
            {
                Employee employee = repository.Get_Employees_History()[i];

                if (guna2btnRepportAll.Checked)
                {
                    guna2DataGridViewHistory.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id, "Was " + employee.Raison, employee.Date);
                }
                else if (guna2btnRepportEmpAdded.Checked)
                {

                    if (employee.Raison.ToLower() == "added")
                    {
                        guna2DataGridViewHistory.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id, "Was " + employee.Raison, employee.Date);
                    }
                }
                else if (guna2btnRepportEmpDeleted.Checked)
                {

                    if (employee.Raison.ToLower() == "deleted")
                    {
                        guna2DataGridViewHistory.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id, "Was " + employee.Raison, employee.Date);
                    }
                }
                else if (guna2btnRepportEmpUpdated.Checked)
                {

                    if (employee.Raison.ToLower() == "updated")
                    {
                        guna2DataGridViewHistory.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id, "Was " + employee.Raison, employee.Date);
                    }
                }
            }
        }

        // if the user write something in the text box, clean the history list and
        // search the employee that match with the name in the text box and print him
        public void Search_and_PrintTheHistory_by_Category(Employee employee)
        {
            if (guna2btnRepportAll.Checked)
            {
                if (employee.Name.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2TxtSearch.Text.ToLower()))
                {
                    guna2DataGridViewHistory.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id, "Was " + employee.Raison, employee.Date);
                }
            }
            else if (guna2btnRepportEmpAdded.Checked)
            {

                if ((employee.Name.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2TxtSearch.Text.ToLower())) && employee.Raison.ToLower() == "added")
                {
                    guna2DataGridViewHistory.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id, "Was " + employee.Raison, employee.Date);
                }
            }
            else if (guna2btnRepportEmpDeleted.Checked)
            {

                if ((employee.Name.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2TxtSearch.Text.ToLower())) && employee.Raison.ToLower() == "deleted")
                {
                    guna2DataGridViewHistory.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id, "Was " + employee.Raison, employee.Date);
                }
            }
            else if (guna2btnRepportEmpUpdated.Checked)
            {

                if ((employee.Name.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.PostName.ToLower().Contains(guna2TxtSearch.Text.ToLower()) ||
                       employee.GivenName.ToLower().Contains(guna2TxtSearch.Text.ToLower())) && employee.Raison.ToLower() == "updated")
                {
                    guna2DataGridViewHistory.Rows.Add(employee.Name.ToUpper(), employee.PostName.ToUpper(), employee.GivenName.ToUpper(), employee.Id, "Was " + employee.Raison, employee.Date);
                }
            }
        }

        // Check if at least one button is selected and print the history according to the selected button (all, deleted, updated...)
        public void Check_button_and_PrintHistory(Guna2Button button)
        {
            guna2btnRepportAll.Checked = false;
            guna2btnRepportEmpAdded.Checked = false;
            guna2btnRepportEmpDeleted.Checked = false;
            guna2btnRepportUserConnected.Checked = false;
            guna2btnRepportEmpUpdated.Checked = false;

            button.Checked = true;
            PrintHistory();
        }

        // End of personalized methodes
    }
}
