namespace AbuDhabiPorts_BackEndApi.Models;

public class Employee
{
    public int Id { get; set; } 
    public string FullName { get; set; }
    public string JobTitle { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public double Salary { get; set; }
    public string Address { get; set; }
}
