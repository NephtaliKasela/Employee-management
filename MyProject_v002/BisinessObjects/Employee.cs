using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_v002.BisinessObjects
{
    // Identity of the employee
    public class Employee
    {
        private List<double> all_Usual_Amount_In_a_Year = new List<double>(12) { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<double> all_Bonus_In_a_Year = new List<double>(12) { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //public Employee()
        //{
        //    mounths_In_a_Year_Usual_Amount = new List<string>(12);
        //    mounths_In_a_Year_Bonus = new List<string>(12);
        //}

        public string Name { get; set; }
        public string PostName { get; set; }
        public string GivenName { get; set; }
        public int Age { get; set; }
        public string BirthDay { get; set; }
        public char Gender { get; set; }
        public string Country { get; set; }
        public string Post { get; set; }
        public string Id { get; set; }
        public string Department { get; set; }
        public string ContractType { get; set; }
        public string SocialStatus { get; set; }
        public string StartJob { get; set; }
        public string EndJob { get; set; }
        public string State { get; set; }
        public string Photo { get; set; }

        // this attribute is provided for the history managment
        public string Raison { get; set; }
        public string Date { get; set; }

        // Attributes to manage the salary
        public double UsualAmount { get; set; }
        public string LastPayment { get; set; }
        public string Mounth { get; set; }
        public string MounthBonus { get; set; }
        public double Overtime { get; set; }
        public double Bonus { get; set; }
        public double Total { get; set; }
        public double TotalAmountSinceYouStartedJob { get; set; }
        public List<double> All_Usual_Amount_In_a_Year
        { 
            get { return all_Usual_Amount_In_a_Year; } 
            set {}
        }
        public List<double> All_Bonus_In_a_Year
        {
            get { return all_Bonus_In_a_Year; }
            set { }
        }
    }
}
