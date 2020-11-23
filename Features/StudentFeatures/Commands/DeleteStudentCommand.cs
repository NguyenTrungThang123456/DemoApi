using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoApi.DAL;
using MediatR;

namespace DemoApi.Features.StudentFeatures.Commands
{
    public class DeleteStudentByIdCommand :IRequest<Guid>
    {
        public  Guid Id { get; set; }

        public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, Guid>
        {

            private readonly StudentContext _studentContext; 
            public DeleteStudentByIdCommandHandler(StudentContext studentContext)
            {
                _studentContext = studentContext;
            }

            public async Task<Guid> Handle(DeleteStudentByIdCommand command, CancellationToken cancellationToken)
            {

                var student = _studentContext.Students.Where(std => std.Id == command.Id).FirstOrDefault();

                if (student != null)
                {
                    _studentContext.Students.Remove(student);
                    await _studentContext.SaveChangesAsync();
                    return student.Id;
                }
                else
                {
                    return default;
                }
            }
        }
       
    }
}
