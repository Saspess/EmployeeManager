using Application.Interfaces.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<DepartmentAddress> DepartmentsAddresses { get; set; } = null!;
        public DbSet<DepartmentDataset> DepartmentsDatasets { get; set; } = null!;
        public DbSet<Education> Educations { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<EmployeeAddress> EmployeesAddresses { get; set; } = null!;
        public DbSet<EmployeeDataset> EmployeesDatasets { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<OrganizationAddress> OrganizationsAddresses { get; set; } = null!;
        public DbSet<OrganizationContact> OrganizationsContacts { get; set; } = null!;
        public DbSet<OrganizationDataset> OrganizationsDatasets { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

