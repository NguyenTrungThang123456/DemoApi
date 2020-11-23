using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Linq;
using Dapper;
using DemoApi.Models;
using DemoApi.Interface;

namespace DemoApi.DAL
{
    public class StudentRepository:GenericRepository<Student>,IStudentRepository
    {
        public StudentRepository(StudentContext context) : base(context) { }
        

        public IEnumerable<Student> GetStudent()
        {
            return _context.Students.ToList();
        }
    }
}
