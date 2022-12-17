using AbuDhabiPorts_BackEndApi.Models;


namespace WebApi.Test.Employees;
public static class EmployeeData
{
    //public static CreateEmployeeCommand MockCreateEmployeeCommand() => new()
    //{
    //    FirstName = "Mohamed",
    //    LastName = "Eltaher",
    //    Email = "dev.eltaher@gmail",
    //    Phone = "0585199391"
    //};
    public static List<Employee> MockEmployeeSamples() => new()
    {
        new Employee()
        {
            FullName = "Mohamed",
            Address = "Eltaher",
        },
        new Employee()
        {
           FullName = "Mohamed",
            Address = "Eltaher",
        }
    };

    //public static GetEmployeeByIdQuery MockGetEmployeeByIdQuery() => new() { Id = 1 };
    //public static UpdateEmployeeCommand MockUpdateEmployeeCommand() => new() { Id = 1, FirstName = "Mohammed" };
    //public static DeleteEmployeeByIdCommand MockDeleteEmployeeByIdCommand() => new() { Id =1  };
}
