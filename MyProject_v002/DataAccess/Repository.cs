using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyProject_v002.BisinessObjects;

namespace MyProject_v002.DataAccess
{
    // Interacte with the the data base of employees
    public class Repository
    {
        List<Employee> employees = new List<Employee>();
        List<Employee> salaries = new List<Employee>();
        List<Employee> Update_Employee_Identity = new List<Employee>();
        List<Employee> Employee_to_delete = new List<Employee>();

        List<Employee> history_employeesAdded = new List<Employee>();
        List<Employee> history_employeesDeleted = new List<Employee>();
        List<Employee> history_employeesRestored = new List<Employee>();
        List<Employee> history_employeesUpdated = new List<Employee>();
        List<Employee> histories = new List<Employee>();

        List<string> departments = new List<string>();

        // Read data
        public List<Employee> Read_Employees(string path)
        {
            employees.Clear();
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] details = line.Split('\t');

                if (details.Length >= 16)
                {
                    for (int i = 0; i < details.Length; i++)
                    {
                        if (details[i].Contains("[")) details[i] = details[i].Replace("[", "");
                        if (details[i].Contains("]")) details[i] = details[i].Replace("]", "");
                    }

                    Employee employee = new Employee();

                    employee.Name = details[0];
                    employee.PostName = details[1];
                    employee.GivenName = details[2];
                    employee.Age = Convert.ToInt32(details[3]);
                    employee.BirthDay = details[4];
                    employee.Gender = Convert.ToChar(details[5]);
                    employee.Country = details[6];
                    employee.Post = details[7];
                    employee.Id = details[8];
                    employee.Department = details[9];
                    employee.ContractType = details[10];
                    employee.SocialStatus = details[11];
                    employee.StartJob = details[12];
                    employee.EndJob = details[13];
                    employee.State = details[14];
                    employee.Photo = details[15];

                    employees.Add(employee);
                }
            }
            Actualize_Employees(employees);
            reader.Close();

            return employees;
        }

        public void Read_Salary(string path1, string path2)
        {
            Repository repository = new Repository();
            repository.Read_Employees(path1);
            salaries.Clear();

            StreamReader reader = new StreamReader(path2);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] details = line.Split('\t');

                if (details.Length >= 41)
                {
                    for (int i = 0; i < details.Length; i++)
                    {
                        if (details[i].Contains("[")) details[i] = details[i].Replace("[", "");
                        if (details[i].Contains("]")) details[i] = details[i].Replace("]", "");
                    }

                    foreach (Employee emp in repository.GetEmployees())
                    {
                        if (emp.Name.ToLower() == details[0].ToLower() &&
                            emp.PostName.ToLower() == details[1].ToLower() &&
                            emp.GivenName.ToLower() == details[2].ToLower()) //&&
                                                                             //emp.Id.ToLower() == details[3].ToLower())
                        {
                            Employee employee = new Employee();

                            employee.Name = details[0];
                            employee.PostName = details[1];
                            employee.GivenName = details[2];
                            employee.Age = emp.Age;           // in case the age will be actualized
                            employee.BirthDay = details[4];
                            employee.Id = details[5];
                            employee.UsualAmount = Convert.ToInt32(details[6]);
                            employee.LastPayment = details[7];
                            employee.Mounth = details[8];
                            employee.Overtime = Convert.ToInt32(details[9]);
                            employee.Bonus = Convert.ToInt32(details[10]);
                            employee.Total = Convert.ToInt32(details[11]);
                            employee.TotalAmountSinceYouStartedJob = Convert.ToInt32(details[12]);
                            employee.MounthBonus = details[13];
                            employee.Department = details[14];

                            int n = 15;
                            // Get salaries for the all year
                            for (int i = 0; i < 12; i++)
                            {
                                n += 1;
                                employee.All_Usual_Amount_In_a_Year[i] = Convert.ToInt32(details[n]);
                            }

                            n += 1;
                            // Get bonus for the all year
                            for (int i = 0; i < 12; i++)
                            {
                                n += 1;
                                employee.All_Bonus_In_a_Year[i] = Convert.ToInt32(details[n]);
                            }

                            salaries.Add(employee);
                        }
                    }
                }
            }
            Actualize_Salary(salaries);
            reader.Close();
        }

        public void ReadHistory(string path)
        {
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream) 
            {
                string line = reader.ReadLine();
                string[] details = line.Split('\t');

                if (details.Length >= 6)
                {
                    for (int i = 0; i < details.Length; i++)
                    {
                        if (details[i].Contains("[")) details[i] = details[i].Replace("[", "");
                        if (details[i].Contains("]")) details[i] = details[i].Replace("]", "");
                    }

                    Employee employee = new Employee();

                    employee.Name = details[0];
                    employee.PostName = details[1];
                    employee.GivenName = details[2];
                    employee.Age = Convert.ToInt32(details[3]);
                    employee.BirthDay = details[4];
                    employee.Id = details[5];
                    employee.Raison = details[6];
                    employee.Date = details[7];

                    histories.Add(employee);
                }
            }
            //Actualize(employees);
            reader.Close();
        }

        public void Read_Department(string path)
        {
            departments.Clear();
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] details = line.Split(' ');

                if (details.Length > 0)
                {
                    departments.Add(details[0]);
                }
            }
            reader.Close();
        }

        // Read Employee's Identity to update
        public void Read_Employee_Identity_ToUpdate(string path)
        {
            Update_Employee_Identity = Read_Employees(path);

        }

        public void Read_Deleted_Employees(string path)
        {
            Employee_to_delete = Read_Employees(path);
        }


        // If two employees have the same identity, remove one.
        public void Actualize_Employees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                for (int j = 0; j < employees.Count; j++)
                {
                    if (i != j && i < employees.Count - 1)
                    {
                        if (employees[i].Name.ToLower() == employees[j].Name.ToLower() &&
                        employees[i].PostName.ToLower() == employees[j].PostName.ToLower() &&
                        employees[i].GivenName.ToLower() == employees[j].GivenName.ToLower() &&
                        employees[i].BirthDay.ToLower() == employees[j].BirthDay.ToLower())
                        {
                            employees.Remove(employees[i]);
                        }
                    }

                }
            }
        }

        public void Actualize_Salary(List<Employee> salaries)
        {
            for (int i = 0; i < salaries.Count; i++)
            {
                for (int j = 0; j < salaries.Count; j++)
                {
                    if (i != j && i < salaries.Count - 1)
                    {
                        if (salaries[i].Name.ToLower() == salaries[j].Name.ToLower() &&
                            salaries[i].PostName.ToLower() == salaries[j].PostName.ToLower() &&
                            salaries[i].GivenName.ToLower() == salaries[j].GivenName.ToLower() &&
                            salaries[i].BirthDay.ToLower() == salaries[j].BirthDay.ToLower() &&
                            salaries[i].TotalAmountSinceYouStartedJob <= salaries[j].TotalAmountSinceYouStartedJob)
                        {
                            salaries.Remove(salaries[i]);
                        }
                    }
                }
            }
        }

        // Actualize the age of employees
        public void Actualize_Age(string path)
        {
            string todayYear = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            string todayMounth = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
            string todayDay = DateTime.Parse(DateTime.Now.ToString()).Day.ToString();

            Read_Employees(path);
            foreach(Employee emp in GetEmployees())
            {
                string yearOfBirth = Convert.ToString(emp.BirthDay[6]) + Convert.ToString(emp.BirthDay[7]) + Convert.ToString(emp.BirthDay[8]) + Convert.ToString(emp.BirthDay[9]);
                string mounthOfBirth = Convert.ToString(emp.BirthDay[3]) + Convert.ToString(emp.BirthDay[4]);
                string dayOfBirth = Convert.ToString(emp.BirthDay[0]) + Convert.ToString(emp.BirthDay[1]);
                try
                {
                    int TdayYear = int.Parse(todayYear);
                    int yearOfBth = int.Parse(yearOfBirth);
                    if ((TdayYear - yearOfBth) >= 0)
                    {
                        int TdayMounth = int.Parse(todayMounth);
                        int MOfBirth = int.Parse(mounthOfBirth);
                        if (TdayMounth >= MOfBirth)
                        {
                            int TdayDay = int.Parse(todayDay);
                            int DyOfBirth = int.Parse(dayOfBirth);
                            if (TdayDay >= DyOfBirth)
                            {
                                emp.Age = TdayYear - yearOfBth;
                            }
                        }
                    } 
                }
                catch {}
            }
            SaveEmployeesIdentities(path, GetEmployees());
        }


        // Add employee management
        public void Add_Employees(Employee employee)
        {
            employees.Add(employee);
        }

        public void Add_EmployeeAdded_inThe_History(Employee employee)
        {
            history_employeesAdded.Add(employee);
        }

        public void Add_EmployeesDeleted_inThe_History(Employee employee)
        {
            history_employeesDeleted.Add(employee);
        }

        public void Add_EmployeesRestored_inThe_History(Employee employee)
        {
            history_employeesRestored.Add(employee);
        }

        public void Add_EmployeesUpdated_inThe_History(Employee employee)
        {
            history_employeesUpdated.Add(employee);
        }

        public void Add_Department(string department)
        {
            departments.Add(department);
        }

        public void Add_Salary(Employee employee)
        {
            salaries.Add(employee);
        }
        

        public void Add_Employee_Identity_ToUpdate(Employee employee)
        {
            Update_Employee_Identity.Add(employee);
        }

        public void Add_Employee_ToDelete(Employee employee)
        {
            Employee_to_delete.Add(employee);
        }


        // Get employees data
        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public List<Employee> Get_Employees_History()
        {
            return histories;
        }

        public List<string> Get_Departmnts()
        {
            return departments;
        }

        public List<Employee> Get_Salary()
        {
            return salaries;
        }

        public List<Employee> Get_Employee_Identity_ToUpdate()
        {
            return Update_Employee_Identity;
        }

        public List<Employee> Get_Deleted_Employee()
        {
            return Employee_to_delete;
        }

        public List<Employee> Get_History_of_Added_Employee()
        {
            return history_employeesAdded;
        }

        public List<Employee> Get_History_of_Deleted_Employee()
        {
            return history_employeesDeleted;
        }

        public List<Employee> Get_History_of_Restored_Employee()
        {
            return history_employeesRestored;
        }

        public List<Employee> Get_History_of_Updated_Employee()
        {
            return history_employeesUpdated;
        }


        // Delete employee management
        public void Delete_Employee_Identity(Employee employee, string path)
        {
            Read_Employees(path);

            for (int i = 0; i < GetEmployees().Count; i++)
            {
                if (GetEmployees()[i].Name.ToLower() == employee.Name.ToLower() &&
                    GetEmployees()[i].PostName.ToLower() == employee.PostName.ToLower() &&
                    GetEmployees()[i].GivenName.ToLower() == employee.GivenName.ToLower() &&
                    GetEmployees()[i].BirthDay.ToLower() == employee.BirthDay.ToLower())
                {
                    employees.RemoveAt(i);
                }
            }
        }

        public void Delete_Employee_Salary(Employee employee)
        {
            salaries.Remove(employee);
        }

        public void Clean_the_file(string path)
        {
            File.WriteAllText(path, "");
        }

        public void Delete_Department(string department)
        {
            departments.Remove(department);
        }

        // Update the employee's identity
        public void Update(Employee employee)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Name == employee.Name &&
                    employees[i].PostName == employee.PostName &&
                    employees[i].GivenName == employee.GivenName &&
                    employees[i].BirthDay == employee.BirthDay)
                {
                    employees[i].Name = employee.Name;
                    employees[i].PostName = employee.PostName;
                    employees[i].GivenName = employee.GivenName;

                    employees[i].Age = employee.Age;
                    employees[i].BirthDay = employee.BirthDay;
                    employees[i].Gender = employee.Gender;
                    employees[i].Country = employee.Country;
                    employees[i].Post = employee.Post;

                    employees[i].Id = employee.Id;
                    employees[i].Department = employee.Department;
                    employees[i].ContractType = employee.ContractType;
                    employees[i].SocialStatus = employee.SocialStatus;

                    employees[i].StartJob = employee.StartJob;
                    employees[i].EndJob = employee.EndJob;

                    employees[i].State = employee.State;
                    employees[i].Photo = employee.Photo;


                }
            }
        }



        // Save Employees data

        public void SaveEmployeesIdentities(string path, List<Employee> employees)
        {
            File.WriteAllText(path, "");

            Actualize_Employees(employees);

            for (int i = 0; i < employees.Count; i++)
            {
                string file = string.Empty;

                file += $"[{employees[i].Name}]";

                file += $"\t[{employees[i].PostName}]";

                file += $"\t[{employees[i].GivenName}]";

                file += $"\t[{employees[i].Age}]";

                file += $"\t[{employees[i].BirthDay}]";

                file += $"\t[{employees[i].Gender}]";

                file += $"\t[{employees[i].Country}]";

                file += $"\t[{employees[i].Post}]";

                file += $"\t[{employees[i].Id}]";

                file += $"\t[{employees[i].Department}]";

                file += $"\t[{employees[i].ContractType}]";

                file += $"\t[{employees[i].SocialStatus}]";

                file += $"\t[{employees[i].StartJob}]";

                file += $"\t[{employees[i].EndJob}]";

                file += $"\t[{employees[i].State}]";

                file += $"\t[{employees[i].Photo}]\n";

                File.AppendAllText(path, file);
            }
        }

        // Save salaries
        public void SaveEmployees_Salary(string path, List<Employee> salaries)
        {
            File.WriteAllText(path, "");

            Actualize_Salary(salaries);

            for (int i = 0; i < salaries.Count; i++)
            {
                string file = string.Empty;

                file += $"[{salaries[i].Name}]";

                file += $"\t[{salaries[i].PostName}]";

                file += $"\t[{salaries[i].GivenName}]";

                file += $"\t[{salaries[i].Age}]";

                file += $"\t[{salaries[i].BirthDay}]";

                file += $"\t[{salaries[i].Id}]";

                file += $"\t[{salaries[i].UsualAmount}]";

                file += $"\t[{salaries[i].LastPayment}]";

                file += $"\t[{salaries[i].Mounth}]";

                file += $"\t[{salaries[i].Overtime}]";

                file += $"\t[{salaries[i].Bonus}]";

                file += $"\t[{salaries[i].Total}]";

                file += $"\t[{salaries[i].TotalAmountSinceYouStartedJob}]";

                file += $"\t[{salaries[i].MounthBonus}]";

                file += $"\t[{salaries[i].Department}]";

                file += $"\tMounths:";

                foreach(double mounth in salaries[i].All_Usual_Amount_In_a_Year)
                {
                    file += $"\t[{mounth}]";
                }

                file += $"\tBonus:";

                for (int k = 0; k < 12; k++)
                {
                    if(k < 11)
                    {
                        file += $"\t[{salaries[i].All_Bonus_In_a_Year[k]}]";
                    }
                    else if(k == 11)
                    {
                        file += $"\t[{salaries[i].All_Bonus_In_a_Year[k]}]\n";
                    }
                }
                File.AppendAllText(path, file);
            }
        }

        // Save employees that where deleted
        public void Save_Deleted_Employees(string path, List<Employee> employees)
        {
            SaveEmployeesIdentities(path, employees);
        }

        // Save Departments
        public void Save_Departments(List<string> department, string path)
        {
            string file = string.Empty;
            for (int i = 0; i < department.Count; i++)
            {
                file += department[i] + "\n";
            }
            File.WriteAllText(path, file);
        }

        // save employee to update
        public void Save_Employee_Identity_ToUpdate(string path, List<Employee> employees)
        {
            SaveEmployeesIdentities(path, employees);
        }

        // Save the Salary of the Employee to Update
        public void Save_Salary_of_the_Employee_ToUpdate(string path, List<Employee> employees)
        {
            SaveEmployees_Salary(path, employees);
        }

        // Keep track of everything
        public void Track_Employees(string path1, string path2, List<Employee> employees, string raison)
        {
            Actualize_Employees(employees);

            for (int i = 0; i < employees.Count; i++)
            {
                string file = string.Empty;

                file += $"[{employees[i].Name}]";

                file += $"\t[{employees[i].PostName}]";

                file += $"\t[{employees[i].GivenName}]";

                file += $"\t[{employees[i].Age}]";

                file += $"\t[{employees[i].BirthDay}]";

                file += $"\t[{employees[i].Id}]";

                if (raison.ToLower() == "add")
                {
                    file += $"\t[Added]";
                }
                else if (raison.ToLower() == "delete")
                {
                    file += $"\t[Deleted]";
                }
                else if (raison.ToLower() == "update")
                {
                    file += $"\t[Updated]";
                }
                else if (raison.ToLower() == "restore")
                {
                    file += $"\t[Restored]";
                }

                if (employees[i].Date == string.Empty) file += "\t[]\n";
                else file += $"\t[{employees[i].Date}]\n";

                File.AppendAllText(path1, file);
                File.AppendAllText(path2, file);

            }
        }
    }
}