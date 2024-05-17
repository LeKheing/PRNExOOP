using CalcSalary;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        Employee employee1 = new PartTimeEmployee("Lam",5,3);
        Employee employee2 = new FullTimeEmployee("Khang", 5);
        Employee employee3 = new PartTimeEmployee("Duong", 5, 3);
        Employee employee4 = new FullTimeEmployee("Duc", 5);
        employees.Add(employee1);
        employees.Add(employee2);
        employees.Add(employee3);
        employees.Add(employee4);
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("==============Menu==============");
            Console.WriteLine("1. Print List");
            Console.WriteLine("2. Find max fulltime and max parttime");
            Console.WriteLine("3. Find employee by name");
            Console.WriteLine("4. Add employee");
            int choice = checkInt("Choose 1 option: ");
            switch (choice)
            {
                case 1:
                    foreach (Employee e in employees)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case 2:
                    Employee maxFull = new FullTimeEmployee("",0);
                    Employee maxPart = new PartTimeEmployee("",0,0);
                    foreach (Employee e in employees)
                    {
                        if (e is FullTimeEmployee && e.CalculateSalary() > maxFull.CalculateSalary())
                            maxFull = e;
                        if(e is PartTimeEmployee && e.CalculateSalary() > maxPart.CalculateSalary())
                            maxPart = e;
                    }
                    Console.WriteLine($"Max salary fulltime: {maxFull.ToString()}");
                    Console.WriteLine($"Max salary parttime: {maxPart.ToString()}");
                    break;
                case 3:
                    string find = checkString("Enter name to find: ");
                    bool isFind = false;
                    foreach (Employee e in employees)
                        if (e.Name == find)
                        { 
                            Console.WriteLine(e.ToString()); 
                            isFind = true;
                        }
                    if (!isFind) Console.WriteLine("Employee not found");
                    break;
                case 4:
                    string name = checkString("Enter name: ");
                    int paymentPerHour = checkInt("Enter payment: ");
                    employees.Add(new FullTimeEmployee(name, paymentPerHour));
                    break;
                default:
                    Console.WriteLine("Exit");
                    loop = false;
                    break;

            }
        }
    }

    public static int checkInt(String msg)
    {
        bool check = false;
        int num = 0;
        while (!check)
        {
            Console.WriteLine(msg);
            string a = Console.ReadLine();
            try
            {
                num = Convert.ToInt32(a);
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
        }
        return num;
    }

    public static string checkString(string msg)
    {
        while (true)
        {
            try
            {
                Console.WriteLine(msg);
                string s = Console.ReadLine();
                if (String.IsNullOrEmpty(s) || String.IsNullOrWhiteSpace(s) || !Regex.IsMatch(s, @"^[A-Za-z\s-]+$"))
                {
                    throw new Exception();
                }
                return s;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid string input");
            }
        }
    }
}