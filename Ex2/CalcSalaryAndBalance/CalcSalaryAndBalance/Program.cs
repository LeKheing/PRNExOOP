using CalcSalaryAndBalance;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        Person person1 = new Employee("Khang","VN",100);
        Person person2 = new Employee("Lam", "VN", 200);
        Person person3 = new Customer("Duc", "VN", 150);
        Person person4 = new Customer("Duong", "VN", 300);
        people.Add(person1);
        people.Add(person2);
        people.Add(person3);
        people.Add(person4);

        bool loop = true;
        while (loop)
        {
            Console.WriteLine("==============Menu==============");
            Console.WriteLine("1. Print List");
            Console.WriteLine("2. Print max employee's salary and customer's balance");
            Console.WriteLine("3. Find employee by name");
            Console.WriteLine("4. Print List");
            int choice = checkInt("Choose 1 option: ");
            switch (choice)
            {
                case 1:
                    foreach (Person p in people)
                    {
                        Console.WriteLine(p.Display());
                    }
                    break;
                case 2:
                    Person maxEmp = new Employee("","",0);
                    Person minCus = new Customer("","",int.MaxValue);
                    foreach (Person p in people)
                    {
                        if (p is Employee && p.Calc() > maxEmp.Calc())
                            maxEmp = p;
                        if (p is Customer && p.Calc() < minCus.Calc())
                            minCus = p;
                    }
                    Console.WriteLine($"Max employee's salary: {maxEmp.Display()}");
                    Console.WriteLine($"Min customer's balance: {minCus.Display()}");
                    break;
               case 3:
                    string find = checkString("Enter name to find: ");
                    bool isFind = false;
                    foreach (Person p in people)
                        if (p.Name == find)
                        { 
                            Console.WriteLine(p.Display()); 
                            isFind = true;
                        }
                    if (!isFind)
                        Console.WriteLine("Employe not found");
                    break;
                case 4:
                    string name = checkString("Enter name: ");
                    string address = checkString("Enter address: ");
                    int salary = checkInt("Enter salary");
                    people.Add(new Employee(name, address, salary));
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