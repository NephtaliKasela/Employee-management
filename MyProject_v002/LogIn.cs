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
using Guna.UI2.WinForms;

using MyProject_v002.BisinessObjects;
using MyProject_v002.DataAccess;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MyProject_v002
{
    public partial class LogIn : Form
    {
        public User_Repository user_Repository = new User_Repository();
        public LogIn()
        {
            InitializeComponent();
        }

        // Close the application
        private void guna2cbtnCloseTheApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2txtUserPassword_TextChanged(object sender, EventArgs e)
        {
            if(guna2txtUserPassword.Text.Length > 0) lblWorning.Text = string.Empty;
        }

        // Check if the password is correct before getting access to the app
        private void guna2btnLogIn_Click(object sender, EventArgs e)
        {
            // Check if the text box of the password is not empty
            if (guna2txtUserPassword.Text.Length > 0)
            {
                // Check the password
                // If the password does not match with any password in both data bases, that means the user has just installed the app
                // In that case, the user should provide the universal password which is "1234" and the user type should be "ADMIN"
                if (Check_Password() == false)
                {
                    if (guna2cbxUserType.Text.ToLower() == "admin" &&
                    guna2txtUserPassword.Text.ToLower() == "1234")
                    {
                        Save_UserType("admin");
                        Hide_The_Login_Interface();
                    }
                    else Worning(lblWorning, guna2txtUserPassword);
                }
            }
            else
            {
                Worning(lblWorning, guna2txtUserPassword);
            }
        }



        // Begining of personalized methodes
        public bool Check_Password()
        {
            Fls fls = new Fls();    
            // Check if the text box of the password is not empty
            if (guna2txtUserPassword.Text.Length > 0)
            {
                // Check if the user is an administrator (ADMIN) or a simple User
                // if admin, check if the password exist in the data base of administrators
                if (guna2cbxUserType.Text.ToLower() == "admin")
                {
                    user_Repository = new User_Repository();
                    //user_Repository.Read_Users("Users/ADMIN_UserName_and_password.txt");
                    user_Repository.Read_Users(fls.ADMIN_UserName_and_password());

                    if (user_Repository.Get_Users().Count > 0)
                    {
                        foreach (User user in user_Repository.Get_Users())
                        {
                            if (user.Password == guna2txtUserPassword.Text)
                            {
                                Save_UserType("admin");
                                Hide_The_Login_Interface();
                            }
                            else Worning(lblWorning, guna2txtUserPassword);
                        }
                        return true;
                    }
                }
                // if simple user, check if the password exist in the data base of simple users
                else if (guna2cbxUserType.Text.ToLower() == "simple user")
                {
                    user_Repository = new User_Repository();
                    //user_Repository.Read_Users("Users/SIMPLE_USER_UserName_and_password.txt");
                    user_Repository.Read_Users(fls.SIMPLE_USER_UserName_and_password());

                    if (user_Repository.Get_Users().Count > 0)
                    {
                        foreach (User user in user_Repository.Get_Users())
                        {
                            if (user.Password == guna2txtUserPassword.Text)
                            {
                                Save_UserType("simple user");
                                Hide_The_Login_Interface();
                            }
                            else Worning(lblWorning, guna2txtUserPassword);
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        public void Worning(Label worning, Guna2TextBox button)
        {
            button.BorderColor = Color.Red;
            worning.Text = "Password incorrect";
            worning.ForeColor = Color.Red;
        }

        public void Save_UserType(string userType)
        {
            Fls fls = new Fls();
            //user_Repository.Save_UserType_Connected("Users/User_Type_Connected.txt", userType);
            user_Repository.Save_UserType_Connected(fls.User_Type_Connected(), userType);
            //user_Repository.Save_Password("Users/User_Password_Connected.txt", guna2txtUserPassword.Text);
            user_Repository.Save_Password(fls.User_Password_Connected(), guna2txtUserPassword.Text);
        }

        public void Hide_The_Login_Interface()
        {
            this.Visible = false;
        }

        public bool Is_Valide()
        {
            string date = string.Empty;
            int time = 0;
            user_Repository.Read_Users("Validation/Time.txt");
            foreach (User us in user_Repository.Get_Users())
            {
                if (us.Name.Contains("[")) us.Name = us.Name.Replace("[", "");
                if (us.Name.Contains("]")) us.Name = us.Name.Replace("]", "");
                if (us.Password.Contains("[")) us.Password = us.Password.Replace("[", "");
                if (us.Password.Contains("]")) us.Password = us.Password.Replace("]", "");

                date = us.Name;
                time = int.Parse(us.Password);
                break;
            }
            try
            {
                DateTime PastDay = Convert.ToDateTime(date);
                DateTime today = DateTime.Now;


                if (time == 1)
                {
                    if ((today.Month - PastDay.Month) <= 1 && today.Day >= PastDay.Day)
                    {
                        MessageBox.Show("Vous avez 1 mois.");
                        return true;
                    }
                    
                }
                else if (time == 2)
                {
                    if ((today.Month - PastDay.Month) <= 2 && today.Day >= PastDay.Day) return true;
                }
                else if (time == 3)
                {
                    if ((today.Month - PastDay.Month) <= 3 && today.Day >= PastDay.Day) return true;
                }
                else if (time == 6)
                {
                    if ((today.Month - PastDay.Month) <= 5 && today.Day >= PastDay.Day) return true;
                }
                else if (time == 12)
                {
                    if ((today.Year - PastDay.Year) <= 1 && today.Month >= PastDay.Month && today.Day >= PastDay.Day) return true;
                }
                else if (time == 24)
                {
                    if ((today.Year - PastDay.Year) <= 2 && today.Month >= PastDay.Month && today.Day >= PastDay.Day) return true;
                }
                else if (time == 36)
                {
                    if ((today.Year - PastDay.Year) <= 3 && today.Month >= PastDay.Month && today.Day >= PastDay.Day) return true;
                }
                else if (time == 48)
                {
                    if ((today.Year - PastDay.Year) <= 4 && today.Month >= PastDay.Month && today.Day >= PastDay.Day) return true;
                }
                else if (time == 60)
                {
                    if ((today.Year - PastDay.Year) <= 5 && today.Month >= PastDay.Month && today.Day >= PastDay.Day) return true;
                }
            }
            catch { }
            return false;
        
        }

        // End of personalized methodes

    }
}
