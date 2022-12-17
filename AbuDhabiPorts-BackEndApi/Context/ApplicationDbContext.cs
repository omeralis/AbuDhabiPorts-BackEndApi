using AbuDhabiPorts_BackEndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AbuDhabiPorts_BackEndApi.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
