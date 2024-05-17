using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcSalary
{
    public interface IEmployee
    {
        public int CalculateSalary();
        public string GetName();
    }

    public abstract class Employee : IEmployee
    {
        public Employee(string name, int paymentPerHour) 
        {
            Name = name;
            PaymentPerHour = paymentPerHour;
        }

        public string Name { get; set; }
        public int PaymentPerHour { get; set; }

        public abstract int CalculateSalary();

        public string GetName()
        {
            return Name;
        }

        public abstract string ToString();
    }

    public class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(string name, int paymentPerHour, int workingHours) : base(name, paymentPerHour)
        {
            WorkingHours = workingHours;
        }

        public int WorkingHours { get; set; }
        public override int CalculateSalary()
        {
            return WorkingHours * PaymentPerHour;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Salary: {CalculateSalary()}";
        }
    }

    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string name, int paymentPerHour ) : base(name, paymentPerHour)
        {
        }

        public override int CalculateSalary()
        {
            return 8 * PaymentPerHour;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Salary: {CalculateSalary()}";
        }
    }

}
