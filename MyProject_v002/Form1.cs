//using MyProject_v002.UIs;
using Guna.UI2.WinForms;
using MyProject_v002.User_Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyProject_v002.DataAccess;
using System.Windows;
using MyProject_v002.BisinessObjects;

namespace MyProject_v002
{
    public partial class Form1 : Form
    {
        public Repository repository = new Repository();
        public User_Repository user_repository = new User_Repository();
        private EventArgs e;
        private object sender;
        public string userType = string.Empty;

        public Form1()
        {
            LogIn lg = new LogIn();
            lg.ShowDialog();

            InitializeComponent();

            Check_UserType();
            Initialization();
        }

        // Begining of personalized methodes
        private void Add_UserController(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            userControl.AutoSize = true;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void Reinitialize_Buttons()
        {
            guna2btnHome.Checked = false;
            guna2btnFavorites.Checked = false;
            guna2btnEmployees.Checked = false;
            guna2btnSalary.Checked = false;
            guna2btnHistory.Checked = false;
            guna2btnInfo.Checked = false;
            guna2btnAddNewEmployee.Checked = false;
            guna2btnCorbeille.Checked = false;
            guna2btnNewDepartment.Checked = false;
        }

        public void ChangeColors(Guna2Button button)
        {
            guna2btnHome.FillColor = button.FillColor;
            guna2btnFavorites.FillColor = button.FillColor;
            guna2btnEmployees.FillColor = button.FillColor;
            guna2btnSalary.FillColor = button.FillColor;
            guna2btnHistory.FillColor = button.FillColor;
            guna2btnInfo.FillColor = button.FillColor;
            guna2Panel2.FillColor = button.FillColor;
            guna2btnAddNewEmployee.FillColor = button.FillColor;
            guna2btnCorbeille.FillColor = button.FillColor;
            guna2btnNewDepartment.FillColor = button.FillColor;

            guna2btnHome.ForeColor = button.ForeColor;
            guna2btnFavorites.ForeColor = button.ForeColor;
            guna2btnEmployees.ForeColor = button.ForeColor;
            guna2btnSalary.ForeColor = button.ForeColor;
            guna2btnHistory.ForeColor = button.ForeColor;
            guna2btnInfo.ForeColor = button.ForeColor;
            guna2Panel2.ForeColor = button.ForeColor;
            guna2btnAddNewEmployee.ForeColor = button.ForeColor;
            guna2btnCorbeille.ForeColor = button.ForeColor;
            guna2btnNewDepartment.ForeColor = button.ForeColor;

            button.Checked = true;

            if (button.Text.ToLower() == "home")
            {
                guna2cbtnUserProfile.FillColor = Color.PaleVioletRed;
            }
            else if (button.Text.ToLower() == "employees")
            {
                guna2cbtnUserProfile.FillColor = Color.MidnightBlue;
            }
            else if (button.Text.ToLower() == "salary")
            {
                guna2cbtnUserProfile.FillColor = Color.Salmon;
            }
            else if (button.Text.ToLower() == "history")
            {
                guna2cbtnUserProfile.FillColor = Color.DarkTurquoise;
            }
            else if (button.Text.ToLower() == "info")
            {
                guna2cbtnUserProfile.FillColor = Color.LightSteelBlue;
            }
        }

        // check the user type and print content according to user type
        // if admin, provide all content
        // if simple, hide the history and the salary buttons and the user can not have access to the profile settings
        public void Check_UserType()
        {
            user_repository.Read_UserTypeConnected("Users/User_Type_Connected.txt");
            if(user_repository.Get_UserType_Connected().Length > 0)
            {
                userType = user_repository.Get_UserType_Connected();
                if (userType.ToLower() == "simple user")
                {
                    guna2btnSalary.Visible = false;
                    guna2btnHistory.Visible = false;
                }
                Display_theName_of_the_User(userType);

                // Delete the user type that was connected from the file
                user_repository.Save_UserType_Connected("Users/User_Type_Connected.txt", "");
            }
        }

        // Display the name of the user who is connected
        public void Display_theName_of_the_User(string userType)
        {
            user_repository.Read_Password("Users/User_Password_Connected.txt");
            if (userType.ToLower() == "admin")
            {
                user_repository.Read_Users("Users/ADMIN_UserName_and_password.txt");
                
                foreach(User user in user_repository.Get_Users())
                {
                    if(user.Password == user_repository.Get_UserPassword_Connected())
                    {
                        lblUserName.Text = user.Name.ToUpper();
                        return;
                    }
                }
            }
            else if(userType.ToLower() == "simple user")
            {
                user_repository.Read_Users("Users/SIMPLE_USER_UserName_and_password.txt");

                foreach (User user in user_repository.Get_Users())
                {
                    if (user.Password == user_repository.Get_UserPassword_Connected())
                    {
                        lblUserName.Text = user.Name.ToUpper();
                        return;
                    }
                }
            }
        }

        public void Initialization()
        {
            guna2btnHome_Click(sender, e);
            guna2btnFavorites.Visible = false;
            guna2btnCorbeille.Visible = false;

            guna2cbtnUserProfile.Image = Image.FromFile("Logos/icon-gb75904f00_1280.png");
            guna2btnHome.Image = Image.FromFile("Logos/house-g3fd0ea44a_1280.png");
            //guna2btnFavorites.Image = Image.FromFile("Logos/494934.png");
            guna2btnEmployees.Image = Image.FromFile("Logos/Healthcare-Groups-icon.png");
            guna2btnSalary.Image = Image.FromFile("Logos/my-salary.png");
            guna2btnHistory.Image = Image.FromFile("Logos/flat-g4e81f12c8_1280.png");
            guna2btnInfo.Image = Image.FromFile("Logos/info-89.png");
            guna2btnNewDepartment.Image = Image.FromFile("Logos/Plus-Symbol-PNG-Image-File.png");
            guna2btnAddNewEmployee.Image = Image.FromFile("Logos/Plus-Symbol-PNG-Image-File.png");
        }

        // End of personalized methodes

        private void guna2btnHome_Click(object sender, EventArgs e)
        {
            UC_Home uc = new UC_Home();
            Add_UserController(uc);
            guna2btnHome.FillColor = Color.PaleVioletRed;
            guna2btnHome.ForeColor = Color.White;
            Reinitialize_Buttons();
            ChangeColors(guna2btnHome);
        }

        private void guna2btnEmployees_Click(object sender, EventArgs e)
        {
            UC_Employees uc = new UC_Employees();
            Add_UserController(uc);
            guna2btnEmployees.FillColor = Color.MidnightBlue;
            guna2btnEmployees.ForeColor = Color.White;
            Reinitialize_Buttons();
            ChangeColors(guna2btnEmployees);

        }

        private void guna2btnSalary_Click(object sender, EventArgs e)
        {
            UC_Salary uc = new UC_Salary();
            Add_UserController(uc);
            guna2btnSalary.FillColor = Color.Salmon;
            guna2btnSalary.ForeColor = Color.White;
            Reinitialize_Buttons();
            ChangeColors(guna2btnSalary);
        }

        private void guna2btnHistory_Click(object sender, EventArgs e)
        {
            UC_History uc = new UC_History();
            Add_UserController(uc);
            guna2btnHistory.FillColor = Color.DarkTurquoise;
            guna2btnHistory.ForeColor = Color.White;
            Reinitialize_Buttons();
            ChangeColors(guna2btnHistory);
        }

        private void guna2btnInfo_Click(object sender, EventArgs e)
        {
            UC_Info uc = new UC_Info();
            Add_UserController(uc);
            guna2btnInfo.FillColor = Color.LightSteelBlue;
            guna2btnInfo.ForeColor = Color.White;
            Reinitialize_Buttons();
            ChangeColors(guna2btnInfo);
        }

        private void guna2btnNewDepartment_Click(object sender, EventArgs e)
        {
            NewDepartment dep = new NewDepartment();
            dep.ShowDialog();
        }

        private void guna2btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            repository.Read_Department("Employees/Departments.txt");
            if (repository.Get_Departmnts().Count > 0)
            {
                NewEmployee newEmployee = new NewEmployee();
                newEmployee.ShowDialog();
            }
            else MessageBox.Show("Create at least one department before adding an employee.\nClick on the button 'Department'", "Warning !");
            

        }

        private void guna2cbtnUserProfile_Click(object sender, EventArgs e)
        {
            if (userType.ToLower() == "admin")
            {
                guna2btnEmployees_Click(sender, e);
                Reinitialize_Buttons();
                UC_User uc = new UC_User();
                Add_UserController(uc);
            }
            else MessageBox.Show("Sorry!\nYou are not an administrator..!", "Info");
        }

    }
}