using AbuDhabiPorts_BackEndApi.Interfaces;
using AbuDhabiPorts_BackEndApi.ViewModels.Employees;
using AbuDhabiPorts_BackEndApi.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbuDhabiPorts_BackEndApi.Controllers;

[ApiController]
[Authorize]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeInterface _employeeInterface;

    public EmployeesController(IEmployeeInterface employeeInterface)
    {
        _employeeInterface = employeeInterface;
    }
    [HttpGet]
    public async Task<List<EmployeeViewModel>> GetEmployees()
    {
        return await _employeeInterface.GetEmployees();
    }

    [HttpPost]
    public async Task<EmployeeViewModel> AddEmployee(AddEmployeeViewModel addEmployeeModel)
    {
        return await _employeeInterface.Add(addEmployeeModel);
    }

    [HttpPut("{employeeId}")]
    public async Task<EmployeeViewModel> UpdateEmployee(int employeeId, [FromBody] AddEmployeeViewModel addEmployeeModel)
    {
        return await _employeeInterface.Update(employeeId, addEmployeeModel);
    }

    [HttpDelete("{employeeId}")]
    public async Task DeleteEmployee(int employeeId)
    {
        await _employeeInterface.Delete(employeeId);
    }
}