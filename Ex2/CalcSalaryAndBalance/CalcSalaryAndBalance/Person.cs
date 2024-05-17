using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcSalaryAndBalance
{
    public abstract class Person
    {

        public Person(string name, string address) 
        {
            Name = name;
            Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }

        public abstract string Display();
        public abstract int Calc();
    }

    public class Employee : Person
    {
        public int Salary { get; set;}

        public Employee(string name, string address, int salary) : base( name,address)
        {
            Salary = salary;
        }
        public override string Display()
        {
            return $"Name: {Name}, Address: {Address}, Salary: {Salary}";
        }

        public override int Calc()
        {
            return Salary;
        }
    }

    public class Customer : Person
    {
        public int Balance;

        public Customer(string name, string address, int balance) : base(name, address)
        {
            Balance = balance;
        }

        public override int Calc()
        {
            return Balance;
        }

        public override string Display()
        {
            return $"Name: {Name}, Address: {Address}, Salary: {Balance}";
        }
    }
}
