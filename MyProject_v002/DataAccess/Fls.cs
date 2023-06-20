using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject_v002.DataAccess
{
    public enum EmployeeFiles
    {
        inputEmployees,
        Salary,
        Departments,
        History,
        Employee_Identity_ToUpdate,
        Deleted_Employees,
        Salary_ofThe_Employee_to_Update,
        Track_Added_Employees,
        Track_Deleted_Employees,
        Track_Updated_Employees,
        ADMIN_UserName_and_password
    }

    public enum UserFiles
    {
        ADMIN_UserName_and_password,
        SIMPLE_USER_UserName_and_password,
        User_Password_Connected,
        User_Type_Connected
    }
    public class Fls
    {
        // Employee files
        public string inputEmployees()
        {
            return CheckPath(EmployeeFiles.inputEmployees.ToString());
        }

        public string Deleted_Employees()
        {
            return CheckPath(EmployeeFiles.Deleted_Employees.ToString());
        }

        public string Employee_Identity_ToUpdate()
        {
            return CheckPath(EmployeeFiles.Employee_Identity_ToUpdate.ToString());
        }

        public string History()
        {
            return CheckPath(EmployeeFiles.History.ToString());
        }

        public string Salary()
        {
            return CheckPath(EmployeeFiles.Salary.ToString());
        }

        public string Salary_ofThe_Employee_to_Update()
        {
            return CheckPath(EmployeeFiles.Salary_ofThe_Employee_to_Update.ToString());
        }

        public string Track_Added_Employees()
        {
            return CheckPath(EmployeeFiles.Track_Added_Employees.ToString());
        }

        public string Track_Deleted_Employees()
        {
            return CheckPath(EmployeeFiles.Track_Deleted_Employees.ToString());
        }

        public string Track_Updated_Employees()
        {
            return CheckPath(EmployeeFiles.Track_Updated_Employees.ToString());
        }

        public string Department()
        {
            return CheckPath(EmployeeFiles.Departments.ToString());
        }

        // User files
        public string ADMIN_UserName_and_password()
        {
            return CheckPath(UserFiles.ADMIN_UserName_and_password.ToString());
        }

        public string SIMPLE_USER_UserName_and_password()
        {
            return CheckPath(UserFiles.SIMPLE_USER_UserName_and_password.ToString());
        }

        public string User_Password_Connected()
        {
            return CheckPath(UserFiles.User_Password_Connected.ToString());
        }

        public string User_Type_Connected()
        {
            return CheckPath(UserFiles.User_Type_Connected.ToString());
        }

        // Personalized methods
        public string CheckPath(string name)
        {
            string path = Path.GetTempPath();
            path = path.Replace("\\", "/");
            path = path + name + ".txt";

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            } 
            return path;
        }
    }
}
