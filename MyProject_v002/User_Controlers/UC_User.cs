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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyProject_v002.User_Controlers
{
    public partial class UC_User : UserControl
    {
        User_Repository user_repository = new User_Repository();
        User userConnected = new User();
        public UC_User()
        {
            InitializeComponent();
        }

        private void UC_User_Load(object sender, EventArgs e)
        {
            Display_theName_of_the_User();

            // Get all user ADMIN and print them
            user_repository.Read_Users("Users/ADMIN_UserName_and_password.txt");
            if (user_repository.Get_Users().Count > 0)
            {
                foreach (User user in user_repository.Get_Users())
                {
                    guna2cbxUserADMIN.Items.Add(user.Name);
                }
            }

            // Get all SIMPLE USER and print them
            user_repository.Read_Users("Users/SIMPLE_USER_UserName_and_password.txt");
            if (user_repository.Get_Users().Count > 0)
            {
                foreach (User user in user_repository.Get_Users())
                {
                    guna2cbxUser_SIMPLE_USER.Items.Add(user.Name);
                }
            }
        }

        // Beginig of Personalized methodes
        private bool CheckTextBox(Guna2TextBox textBox, Label lab, Guna2Button button)
        {
            Warning(lab, button);
            if (textBox.Text.Trim() == string.Empty || textBox.Text.Trim().Contains("\t") || textBox.Text.Trim().Contains("\n") || textBox.Text.Trim().Contains(' '))
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

        private bool CheckComboBox(Guna2ComboBox comboBox, Label lab, Guna2Button button)
        {
            Warning(lab, button);
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

        public void Warning(Label lab, Guna2Button button)
        {
            if(button.Text.ToLower() == "add" || button.Text.ToLower() == "update")
            {
                lab.Text = string.Empty;
                button.FillColor = Color.Navy;
            }
            else
            {
                lab.Text = string.Empty;
                button.FillColor = Color.IndianRed;
            }
            
        }

        public void SaveUser(Guna2TextBox name, Guna2TextBox password, List<User> users, string path)
        {
            User user = new User();
            user.Name = name.Text;
            user.Password = password.Text;
            user_repository.Add_User(user);

            user_repository.Save_Users(path, users);
            MessageBox.Show($"'{name.Text}' was added successfully !", "INfo");
        }

        public bool AddUser(string userType)
        {
            if (userType.ToLower() == "admin")
            {
                user_repository.Read_Users("Users/ADMIN_UserName_and_password.txt");
                if (user_repository.Get_Users().Count > 0)
                {
                    bool flag = false;
                    foreach (User user in user_repository.Get_Users())
                    {
                        if (user.Name.ToLower() == guna2txtUserName.Text.ToLower() || user.Password == guna2txtUserPassword.Text)
                        {
                            guna2btnAddUser.FillColor = Color.Gray;
                            lblWarningAdd.Text = "The name or the password already exist !\nTry another one.";
                            flag = true;
                            if (user.Name == guna2txtUserName.Text) guna2txtUserName.BorderColor = Color.Red;
                            if (user.Password == guna2txtUserPassword.Text) guna2txtUserPassword.BorderColor = Color.Red;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        SaveUser(guna2txtUserName, guna2txtUserPassword, user_repository.Get_Users(), "Users/ADMIN_UserName_and_password.txt");
                        return true;
                    }
                }
                else
                {
                    SaveUser(guna2txtUserName, guna2txtUserPassword, user_repository.Get_Users(), "Users/ADMIN_UserName_and_password.txt");
                    return true;
                }
            }
            else if (userType.ToLower() == "simple user")
            {
                user_repository.Read_Users("Users/SIMPLE_USER_UserName_and_password.txt");
                if (user_repository.Get_Users().Count > 0)
                {
                    bool flag = false;
                    foreach (User user in user_repository.Get_Users())
                    {
                        if (user.Name.ToLower() == guna2txtUserName.Text.ToLower() || user.Password == guna2txtUserPassword.Text)
                        {
                            guna2btnAddUser.FillColor = Color.Gray;
                            lblWarningAdd.Text = "The name or the password already exist !\nTry another one.";
                            flag = true;
                            if (user.Name == guna2txtUserName.Text) guna2txtUserName.BorderColor = Color.Red;
                            if (user.Password == guna2txtUserPassword.Text) guna2txtUserPassword.BorderColor = Color.Red;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        SaveUser(guna2txtUserName, guna2txtUserPassword, user_repository.Get_Users(), "Users/SIMPLE_USER_UserName_and_password.txt");
                        return true;
                    }
                }
                else
                { 
                    SaveUser(guna2txtUserName, guna2txtUserPassword, user_repository.Get_Users(), "Users/SIMPLE_USER_UserName_and_password.txt");
                    return true;
                }
            }
            return false;
        }

        // Display the name of the user who is connected
        public void Display_theName_of_the_User()
        {
            user_repository.Read_Password("Users/User_Password_Connected.txt");

            user_repository.Read_Users("Users/ADMIN_UserName_and_password.txt");

            foreach (User user in user_repository.Get_Users())
            {
                if (user.Password == user_repository.Get_UserPassword_Connected())
                {
                    lblUserNameConnected.Text = user.Name.ToUpper();
                    userConnected.Name = user.Name;
                    userConnected.Password = user.Password;
                    return;
                }
            }
        }

        // End of Personalized methodes

        // Reset the application
        private void guna2btnResetTheApp_Click(object sender, EventArgs e)
        {
            Confirmation_Reset_TheApp reset = new Confirmation_Reset_TheApp();
            reset.ShowDialog();
        }

        // Add a user
        private void guna2btnAddUser_Click(object sender, EventArgs e)
        {
            if (CheckComboBox(guna2cbxUserType, lblWarningAdd, guna2btnAddUser) &&
                CheckTextBox(guna2txtUserName, lblWarningAdd, guna2btnAddUser) &&
                CheckTextBox(guna2txtUserPassword, lblWarningAdd, guna2btnAddUser))
            {
                if (AddUser(guna2cbxUserType.Text))
                {
                    if (guna2cbxUserType.Text.ToLower() == "admin") guna2cbxUserADMIN.Items.Add(guna2txtUserName.Text);
                    if (guna2cbxUserType.Text.ToLower() == "simple user") guna2cbxUser_SIMPLE_USER.Items.Add(guna2txtUserName.Text);

                    guna2txtUserName.Text = string.Empty;
                    guna2txtUserPassword.Text = string.Empty;
                }
            }
            else lblWarningAdd.Text = "Some informations are missing !";
        }

        // Delete a user
        private void guna2cbxUserADMIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckComboBox(guna2cbxUserADMIN, lblWarningDeleteUserADMIN, guna2btnDeleteUser_ADMIN);
        }
        private void guna2cbxUser_SIMPLE_USER_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckComboBox(guna2cbxUser_SIMPLE_USER, lblWarningDeleteSIMPLE_USER, guna2btnDeleteUser_SIMPLE_USER);
        }
        private void guna2btnDeleteUser_ADMIN_Click(object sender, EventArgs e)
        {
            // Check if the user to delete is not equal to the user name that is connected and delete him
            if(CheckComboBox(guna2cbxUserADMIN, lblWarningDeleteUserADMIN, guna2btnDeleteUser_ADMIN))
            {
                if(guna2cbxUserADMIN.Text.Length > 0)
                {
                    user_repository.Read_Users("Users/ADMIN_UserName_and_password.txt");
                    for (int i = 0; i < user_repository.Get_Users().Count; i++)
                    {
                        if (user_repository.Get_Users()[i].Name.ToLower() == guna2cbxUserADMIN.Text.ToLower())
                        {
                            if (user_repository.Get_Users()[i].Name.ToLower() == userConnected.Name.ToLower() &&
                                user_repository.Get_Users()[i].Password == userConnected.Password)
                            {
                                MessageBox.Show("You can not delete your own account...", "Warning");
                                break;
                            }
                            else
                            {
                                string name = user_repository.Get_Users()[i].Name;
                                user_repository.Delete_User(user_repository.Get_Users()[i]);
                                user_repository.Save_Users("Users/ADMIN_UserName_and_password.txt", user_repository.Get_Users());
                                MessageBox.Show($"'{name}' was deleted successfully !", "Info");
                                guna2cbxUserADMIN.Items.Remove(name);
                                break;
                            }
                        }
                    }
                }
            }
            else lblWarningDeleteUserADMIN.Text = "Select the user to delete...";
        }
        private void guna2btnDeleteUser_SIMPLE_USER_Click(object sender, EventArgs e)
        {
            if (CheckComboBox(guna2cbxUser_SIMPLE_USER, lblWarningDeleteSIMPLE_USER, guna2btnDeleteUser_SIMPLE_USER))
            {
                if (guna2cbxUser_SIMPLE_USER.Text.Length > 0)
                {
                    user_repository.Read_Users("Users/SIMPLE_USER_UserName_and_password.txt");
                    for (int i = 0; i < user_repository.Get_Users().Count; i++)
                    {
                        if (user_repository.Get_Users()[i].Name.ToLower() == guna2cbxUser_SIMPLE_USER.Text.ToLower())
                        {
                            string name = user_repository.Get_Users()[i].Name;
                            user_repository.Delete_User(user_repository.Get_Users()[i]);
                            user_repository.Save_Users("Users/SIMPLE_USER_UserName_and_password.txt", user_repository.Get_Users());
                            MessageBox.Show($"'{name}' was deleted successfully !", "Info");
                            guna2cbxUser_SIMPLE_USER.Items.Remove(name);
                            break;
                        }
                    }
                }
            }
            else lblWarningDeleteSIMPLE_USER.Text = "Select the user to delete...";
        }

        // Change the password of a user
        private void guna2btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will be available in the next version.");
        }

        
    }
}
