using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DemoApi.DAL;
using DemoApi.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DemoApi.Features.StudentFeatures.Queries
{
    public class GetStudentByIdQuery : IRequest <Student>
    {
       public Guid Id { get; set; }

        public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
        {
            private string connectionString;
            public GetStudentByIdQueryHandler( IConfiguration configuration) 
            {
                connectionString = configuration["ConnectionString"];   
            }

            public IDbConnection Connection
            {
                get
                {
                    return new NpgsqlConnection(connectionString);
                }
            }

            public async  Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken )
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sqlQuery = @"SELECT * FROM students WHERE id = @StudentId";
                    dbConnection.Open();
                    var student = await dbConnection.QueryFirstOrDefaultAsync<Student>(sqlQuery, new { StudentId = query.Id });

                    if (student == null)
                    {
                        return default;
                    }
                    return student;
                }   
            }

        }
    }
}
