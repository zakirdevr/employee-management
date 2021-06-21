using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepository = null;
        public EmployeesController(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        //GET
        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _empRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        //GET single employee
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await _empRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //POST
        [HttpPost("")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeModel empModel)
        {
            int id = await _empRepository.AddEmployeeAsync(empModel);
            return CreatedAtAction(nameof(GetEmployeeById), new
            {
                id = id,
                controller = "Employees"
            }, id);
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id,
        [FromBody] EmployeeModel empModel)
        {
            await _empRepository.UpdateEmployeeAsync(id, empModel);
            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _empRepository.DeleteEmployeeAsync(id);
            return Ok();
        }


    }
}
