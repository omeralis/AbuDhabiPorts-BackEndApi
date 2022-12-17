using AbuDhabiPorts_BackEndApi.ViewModels.Employees;
using System.Collections.Generic;

namespace AbuDhabiPorts_BackEndApi.Interfaces;

public interface IEmployeeInterface
{
    Task<List<EmployeeViewModel>> GetEmployees();
    Task<EmployeeViewModel> Add(AddEmployeeViewModel addEmployeeModel);
    Task<EmployeeViewModel> Update(int employee,AddEmployeeViewModel addEmployeeModel);
    Task Delete(int employeeId);
}