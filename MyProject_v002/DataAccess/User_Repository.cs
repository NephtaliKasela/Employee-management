using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MyProject_v002.BisinessObjects;

namespace MyProject_v002.DataAccess
{
    public class User_Repository
    {
        List<User> users = new List<User>();
        string userType_connected = string.Empty;
        string user_Password = string.Empty;

        // Read user identities
        public void Read_Users(string path)
        {
            users.Clear();
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] details = line.Split('\t');

                for (int i = 0; i < details.Length; i++)
                {
                    if (details[i].Contains("[")) details[i] = details[i].Replace("[", "");
                    if (details[i].Contains("]")) details[i] = details[i].Replace("]", "");
                }

                if (details.Length >= 2)
                {
                    User user = new User();
                    user.Name = details[0];
                    user.Password = details[1];
                    users.Add(user);
                }
            }
            reader.Close();
        }

        // Read user type of the user that was connected
        public string Read_UserTypeConnected(string path)
        {
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] details = line.Split('\t');

                if (details.Length >= 1)
                {
                    userType_connected = details[0];
                }
            }
            reader.Close();
            return userType_connected;
        }

        // Read the password of the user that was connected
        public void Read_Password(string path)
        {
            user_Password = Read_UserTypeConnected(path);
        }

        // Add a user
        public void Add_User(User user)
        {
            users.Add(user);
        }

        // Delete a user
        public void Delete_User(User user)
        {
            users.Remove(user);
        }

        // Get all user identities
        public List<User> Get_Users()
        {
            return users;
        }

        // Get the user type of the user that was connected
        public string Get_UserType_Connected()
        {
            return userType_connected;
        }

        // Get the user type of the user that was connected
        public string Get_UserPassword_Connected()
        {
            return user_Password;
        }

        // Save all user identities
        public void Save_Users(string path, List<User> users)
        {
            File.WriteAllText(path, "");

            for (int i = 0; i < users.Count; i++)
            {
                string file = string.Empty;

                if (users[i].Name == string.Empty) file += "[]";
                else file += $"[{users[i].Name}]";

                if (users[i].Password == string.Empty) file += "\t[]\n";
                else file += $"\t[{users[i].Password}]\n";

                File.AppendAllText(path, file);
            }
        }

        // Save the user type of the user that was connected
        public void Save_UserType_Connected(string path, string userType)
        {
            File.WriteAllText(path, userType);
            //StreamWriter reader = new StreamWriter(path);

            //reader.Write(userType);
            //reader.Close();
        }

        // Save the password of the user that was connected
        public void Save_Password(string path, string userType)
        {
            Save_UserType_Connected(path, userType);
        }
    }
}
