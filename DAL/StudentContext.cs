using System;
using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.DAL
{
    public class StudentContext:DbContext
    {
        public StudentContext()
        {
        }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        { 
        }

        public DbSet<Student> Students { get;set; }
    }
}
