using ConsoleApp1;

var service = new EmployeeLookup();

var emp = service.GetEmployeeById(1);

if (emp != null)
{
   

    Console.WriteLine($"That employee is {emp.Name} and they make {emp.Salary:c}");
}
else
{
    Console.WriteLine("No Employee With That Id");
}

var emp1 = new Employee(1, "Jill Jones", 120_000);
var emp2 = new Employee(1, "Jill Jones", 120_000);


if(emp1 == emp2)
{
    Console.WriteLine("They are the same!");
} else
{
    Console.WriteLine("They Are different!");

}

var upgradedEmp1 = emp1 with { Salary = 220_000 };

Console.WriteLine(emp1 );
Console.WriteLine(upgradedEmp1);
