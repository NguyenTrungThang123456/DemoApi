using System;
using System.Collections.Generic;
using System.Data;
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
    public class GetAllStudentsQuery:IRequest<IEnumerable<Student>>
    {
        
            public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
            {
                private readonly string connectionString ;
                public GetAllStudentsQueryHandler(IConfiguration configuration)
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
                public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
                {
                using (IDbConnection dbConnection = Connection)
                {
                    string sqlQuery = @"SELECT * FROM students";
                    dbConnection.Open();

                    var students = await dbConnection.QueryAsync<Student>(sqlQuery);

                    if(students == null)
                    {
                        return null;
                    }

                    return students;
                }
                }
            
        }
    }
}
