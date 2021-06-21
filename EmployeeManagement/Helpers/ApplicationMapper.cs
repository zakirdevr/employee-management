using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helpers
{
    public class ApplicationMapper : Profile
    {
       public ApplicationMapper()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
