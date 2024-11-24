using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_activity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Position: {Position}, Salary: {Salary:C}";
        }
    }

    public class EmployeeManagementSystem
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            Console.WriteLine("Employee added successfully.");
        }

        public void ListEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("Employee List:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public Employee FindEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = FindEmployeeById(id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Position = updatedEmployee.Position;
                employee.Salary = updatedEmployee.Salary;
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        public void DeleteEmployee(int id)
        {
            var employee = FindEmployeeById(id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }


internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManagementSystem ems = new EmployeeManagementSystem();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. List Employees");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Position: ");
                        string position = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());

                        ems.AddEmployee(new Employee { Id = id, Name = name, Position = position, Salary = salary });
                        break;

                    case "2":
                        ems.ListEmployees();
                        break;

                    case "3":
                        Console.Write("Enter Employee ID: ");
                        int searchId = int.Parse(Console.ReadLine());
                        var employee = ems.FindEmployeeById(searchId);
                        if (employee != null)
                        {
                            Console.WriteLine("Employee found: " + employee);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Employee ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new Position: ");
                        string newPosition = Console.ReadLine();
                        Console.Write("Enter new Salary: ");
                        decimal newSalary = decimal.Parse(Console.ReadLine());

                        ems.UpdateEmployee(updateId, new Employee { Name = newName, Position = newPosition, Salary = newSalary });
                        break;

                    case "5":
                        Console.Write("Enter Employee ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        ems.DeleteEmployee(deleteId);
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
