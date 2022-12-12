using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Department> Departments { get; set; }
        DbSet<DepartmentAddress> DepartmentsAddresses { get; set; }
        DbSet<DepartmentDataset> DepartmentsDatasets { get; set; }
        DbSet<Education> Educations { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<EmployeeAddress> EmployeesAddresses { get; set; }
        DbSet<EmployeeDataset> EmployeesDatasets { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<OrganizationAddress> OrganizationsAddresses { get; set; }
        DbSet<OrganizationContact> OrganizationsContacts { get; set; }
        DbSet<OrganizationDataset> OrganizationsDatasets { get; set; }
        DbSet<Position> Positions { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
