using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //To get data from database
        private readonly EmployeeContext _context = null;
        private readonly IMapper _mapper = null;
        public EmployeeRepository(EmployeeContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //To get all employees
        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            var records = await _context.Employee.ToListAsync();
            return _mapper.Map<List<EmployeeModel>>(records);
        }

        //To get employee by id
        public async Task<EmployeeModel> GetEmployeeByIdAsync(int empId)
        {
            var record = await _context.Employee.FindAsync(empId);
            return _mapper.Map<EmployeeModel>(record);

        }

        //To add employee
        public async Task<int> AddEmployeeAsync(EmployeeModel empModel)
        {
            var employee = new Employee()
            {
                FirstName = empModel.FirstName,
                MiddleName = empModel.MiddleName,
                LastName = empModel.LastName

            };

            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.Id;
        }

        //To update employee
        public async Task UpdateEmployeeAsync(int empId,
            EmployeeModel empModel)
        {
            var employee = new Employee()
            {
                Id = empId,
                FirstName = empModel.FirstName,
                MiddleName = empModel.MiddleName,
                LastName = empModel.LastName
            };

            _context.Employee.Update(employee);
            await _context.SaveChangesAsync();
        }

        //To delete employee
        public async Task DeleteEmployeeAsync(int empId)
        {
            var employee = new Employee() { Id = empId };

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }



    }
}
