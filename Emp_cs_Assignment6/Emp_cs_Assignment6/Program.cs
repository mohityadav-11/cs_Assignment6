using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_cs_Assignment6
{
    class Program
    {
		List<Employee> employeeList;
		List<Salary> salaryList;

		public Program()
		{
			employeeList = new List<Employee>() {
			new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
			new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
			new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
			new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
			new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
			new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
			new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
			}; 

			salaryList = new List<Salary>() {
			new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
			new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
			new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
			new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
			};
		}

		public static void Main()
		{
			Program program = new Program();

			program.Task1();

			program.Task2();

			program.Task3();
		}

		public void Task1()
		{
		
			var query = from emp in employeeList
						select new
						{
							nm = emp.EmployeeFirstName,
							srn = emp.EmployeeLastName,
							sl = from sal in salaryList
								 where sal.EmployeeID == emp.EmployeeID
								 select new
								 {
									slr = sal.Amount,
								 }
						};

			foreach (var ep in query)
			{
				int amt = 0;
				foreach (var s in ep.sl)
				{
					amt += s.slr;
				}
				
				Console.WriteLine(ep.nm + "  " + ep.srn + "  " + amt);
				
			}

			Console.WriteLine();

		}

		public void Task2()
		{
			var employees = employeeList.OrderByDescending(x => x.Age).Skip(1).FirstOrDefault();

			var sal = from sl in salaryList
					  where employees.EmployeeID == sl.EmployeeID
					  select new
					  {
						  salary = sl.Amount
					  };
			int amt = 0;
			foreach(var s in sal)
			{
				amt += s.salary;
			}

			Console.WriteLine(employees.EmployeeID+"  "+employees.EmployeeFirstName+"  "+employees.EmployeeLastName+"  "
				+employees.Age+"  "+amt);

			Console.WriteLine();
					



				
		}

		public void Task3()
		{
			var query = from emp in employeeList
						where emp.Age>30
						select new
						{
							nm = emp.EmployeeFirstName,
							srn = emp.EmployeeLastName,
							sl = from sal in salaryList
								 where sal.EmployeeID == emp.EmployeeID
								 select new
								 {
									 slr = sal.Amount,
								 }
						};

			foreach (var ep in query)
			{
				int amt = 0;
				int c = 0;
				foreach (var s in ep.sl)
				{
					amt += s.slr;
					c++;
				}

				Console.WriteLine(ep.nm + "  " + ep.srn + "  " + (float)amt/c);

			}

		}
	}

	public enum SalaryType
	{
		Monthly,
		Performance,
		Bonus
	}

	public class Employee
	{
		public int EmployeeID { get; set; }
		public string EmployeeFirstName { get; set; }
		public string EmployeeLastName { get; set; }
		public int Age { get; set; }
	}

	public class Salary
	{
		public int EmployeeID { get; set; }
		public int Amount { get; set; }
		public SalaryType Type { get; set; }
	}
}
