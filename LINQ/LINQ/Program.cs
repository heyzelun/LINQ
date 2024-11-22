using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, string position, decimal salary)
        {
            Id = id;
            Name = name;
            Position = position;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Id} \t{Name} \t {Position} \t\t{Salary}";
        }
    }

    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        // Create
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        // Read
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee FindEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        // Update
        public bool UpdateEmployee(int id, string name, string position, decimal salary)
        {
            var employee = FindEmployeeById(id);
            if (employee != null)
            {
                employee.Name = name;
                employee.Position = position;
                employee.Salary = salary;
                return true;
            }
            return false;
        }

        // Delete
        public bool DeleteEmployee(int id)
        {
            var employee = FindEmployeeById(id);
            if (employee != null)
            {
                employees.Remove(employee);
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager();

            while (true)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddEmployee(employeeManager);
                        break;
                    case 2:
                        ViewAllEmployees(employeeManager);
                        break;
                    case 3:
                        FindEmployeeById(employeeManager);
                        break;
                    case 4:
                        UpdateEmployee(employeeManager);
                        break;
                    case 5:
                        DeleteEmployee(employeeManager);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddEmployee(EmployeeManager employeeManager)
        {
            Console.Write("Enter employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();

            Console.Write("Enter employee position: ");
            string position = Console.ReadLine();

            Console.Write("Enter employee salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            employeeManager.AddEmployee(new Employee(id, name, position, salary));
            Console.WriteLine("Employee added successfully.");
        }

        static void ViewAllEmployees(EmployeeManager employeeManager)
        {
            Console.WriteLine("------All Employee----------");
            Console.WriteLine("Id \tName \tPosition \tSalary");
            foreach (var emp in employeeManager.GetAllEmployees())
            {
                Console.WriteLine(emp);
            }
        }

        static void FindEmployeeById(EmployeeManager employeeManager)
        {
            Console.Write("Enter employee ID to find: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employeeManager.FindEmployeeById(id);
            if (employee != null)
            {

                Console.WriteLine(employee);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void UpdateEmployee(EmployeeManager employeeManager)
        {
            Console.Write("Enter employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter new employee name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new employee position: ");
            string position = Console.ReadLine();

            Console.Write("Enter new employee salary: ");
            int salary = int.Parse(Console.ReadLine());

            if (employeeManager.UpdateEmployee(id, name, position, salary))
            {
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DeleteEmployee(EmployeeManager employeeManager)
        {
            Console.Write("Enter employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            if (employeeManager.DeleteEmployee(id))
            {
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}

