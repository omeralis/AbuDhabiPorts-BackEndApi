
using AbuDhabiPorts_BackEndApi.Context;
using AbuDhabiPorts_BackEndApi.Repositories;
using AbuDhabiPorts_BackEndApi.ViewModels.Employees;
using Moq;
using System.Threading.Tasks;
using WebApi.Test.Employees;
using Xunit;

namespace WebApi.Test.Lookup.Employee;
public class EmployeeTest : IClassFixture<SharedDatabaseFixture>
{
    public SharedDatabaseFixture Fixture { get; }
    private readonly Mock<ApplicationDbContext> _mockContext;

    public EmployeeTest(SharedDatabaseFixture fixture)
    {
        Fixture = fixture;
        _mockContext = new Mock<ApplicationDbContext>();
        _mockContext.Setup(db => db.Employees).Returns(SharedDatabaseFixture.CreateContext().Employees);
    }
    [Fact]
    public async Task Can_Get_All_Employees()
    {

        var employeeRepo = new EmployeeRepository(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
        var result = await employeeRepo.GetEmployees();
        var Employee = result;
        Assert.NotNull(Employee);
        Assert.Equal(EmployeeData.MockEmployeeSamples()[0].FullName, Employee[0].FullName);
    }
    //[Fact]
    //public async Task Can_Get_Employee_By_Id()
    //{
    //    GetEmployeeByIdQueryHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
    //    var result = await handler.Handle(EmployeeData.MockGetEmployeeByIdQuery(), CancellationToken.None);
    //    var Employee = result.Data;

    //    Assert.Equal(EmployeeData.MockEmployeeSamples()[0].FirstName, Employee.FirstName);
    //}
    //[Fact]
    //public async Task Can_Add_Employee()
    //{
    //    CreateEmployeeCommandHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
    //    var result = await handler.Handle(EmployeeData.MockCreateEmployeeCommand(), CancellationToken.None);
    //    var Employee = result.Data;

    //    Assert.Equal(EmployeeData.MockCreateEmployeeCommand().FirstName, Employee.FirstName);
    //}
    //[Fact]
    //public async Task Can_Update_Employee()
    //{
    //    UpdateEmployeeCommandHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
    //    var result = await handler.Handle(EmployeeData.MockUpdateEmployeeCommand(), CancellationToken.None);
    //    var Employee = result.Data;

    //    Assert.Equal(EmployeeData.MockUpdateEmployeeCommand().FirstName, Employee.FirstName);
    //}
    //[Fact]
    //public async Task Can_Delete_Employee()
    //{
    //    DeleteEmployeeByIdCommandHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
    //    var result = await handler.Handle(EmployeeData.MockDeleteEmployeeByIdCommand(), CancellationToken.None);
    //    var Employee = result.Data;

    //    Assert.Equal(EmployeeData.MockEmployeeSamples()[0].FirstName, Employee.FirstName);
    //}
}




