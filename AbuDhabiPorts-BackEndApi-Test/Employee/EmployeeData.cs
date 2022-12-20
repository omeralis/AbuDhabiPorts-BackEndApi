using AbuDhabiPorts_BackEndApi.Models;


namespace WebApi.Test.Employees;
public static class EmployeeData
{
    public static List<Employee> MockEmployeeSamples() => new()
    {
        new Employee()
        {
            FullName = "omer",
            Address = "dubai",
        },
        new Employee()
        {
           FullName = "omer",
            Address = "dubai",
        }
    };

    //public static GetEmployeeByIdQuery MockGetEmployeeByIdQuery() => new() { Id = 1 };
    //public static UpdateEmployeeCommand MockUpdateEmployeeCommand() => new() { Id = 1, FirstName = "Mohammed" };
    //public static DeleteEmployeeByIdCommand MockDeleteEmployeeByIdCommand() => new() { Id =1  };
}
