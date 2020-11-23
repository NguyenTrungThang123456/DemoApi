using System;
using System.Collections;
using System.Collections.Generic;
using DemoApi.Models;

namespace DemoApi.Interface
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        IEnumerable<Student> GetStudent();
    }
}
