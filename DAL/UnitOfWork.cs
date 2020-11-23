using System;
using DemoApi.Interface;
using DemoApi.Models;

namespace DemoApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentContext _context;

        public UnitOfWork(StudentContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
        }

        public IStudentRepository Students { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}