using EmployeeManagement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployeeAsync(EmployeeModel empModel);
        Task DeleteEmployeeAsync(int empId);
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int empId);
        Task UpdateEmployeeAsync(int empId, EmployeeModel empModel);
    }
}