using PieShopHRM.Shared.Domain;

namespace PieShopHRM.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllEmployees(bool refreshRequired = false);

        Task<Employee> GetEmployeeDetails(int employeeId); //GetEmployeeById

        Task<Employee> AddEmployee(Employee employee);

        Task UpdateEmployee(Employee employee);

        Task DeleteEmployee(int employeeId);

    }
}
