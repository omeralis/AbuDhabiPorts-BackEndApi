using AbuDhabiPorts_BackEndApi.Context;
using AbuDhabiPorts_BackEndApi.Interfaces;
using AbuDhabiPorts_BackEndApi.Models;
using AbuDhabiPorts_BackEndApi.ViewModels.Employees;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AbuDhabiPorts_BackEndApi.Repositories;

public class EmployeeRepository : IEmployeeInterface
{

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmployeeViewModel> Add(AddEmployeeViewModel addEmployeeModel)
    {
        var employee = _mapper.Map<Employee>(addEmployeeModel);
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return _mapper.Map<EmployeeViewModel>(employee);
    }
    public async Task<List<EmployeeViewModel>> GetEmployees()
    {
        var employee = await _context.Employees.ToListAsync();
        return _mapper.Map<List<EmployeeViewModel>>(employee);
    }
    public async Task<EmployeeViewModel> Update(int employeeId, AddEmployeeViewModel updateEmployeeModel)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Id == employeeId);

        if (employee == null)
            throw new Exception("Employee not found");
        employee = _mapper.Map(updateEmployeeModel, employee);

        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();

        return _mapper.Map<EmployeeViewModel>(employee);

    }

    public async Task Delete(int employeeId)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Id == employeeId);

        if (employee == null)
            throw new Exception("Employee not found");

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }


}
