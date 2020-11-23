using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Linq;
using Dapper;
using DemoApi.Models;

namespace DemoApi.DAL
{
    public class StudentRepository:IRepository<Student>,IDisposable
    {
        private string connectionString;

        private bool disposed = false;

        private StudentContext _context;

        public StudentRepository(IConfiguration configuration, StudentContext context)
        {
            _context = context;
            connectionString = configuration["ConnectionString"];
        }

       
        public IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Student student)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public IEnumerable<Student> FindAll()
        {
            using (IDbConnection dbConnection= Connection) {
                string sqlQuery = @"SELECT * FROM students";
                dbConnection.Open();
                return dbConnection.Query<Student>(sqlQuery);
            }
        }

        public Student FindById(Guid id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"SELECT * FROM students WHERE Id = @ProductId";
                dbConnection.Open();
                return dbConnection.Query<Student>(sqlQuery, new { ProductId = id }).FirstOrDefault();
            }
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
