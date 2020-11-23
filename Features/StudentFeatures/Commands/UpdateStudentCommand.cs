using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoApi.DAL;
using DemoApi.Models;
using MediatR;

namespace DemoApi.Features.StudentFeatures.Commands
{
    public class UpdateStudentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public class UpdateStudentCommandHanler : IRequestHandler<UpdateStudentCommand,Guid>
        {
            private readonly StudentContext _studentContext;

            public UpdateStudentCommandHanler(StudentContext studentContext)
            {
                _studentContext = studentContext;
            }

            public async Task<Guid> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = _studentContext.Students.Where(std => std.Id == command.Id).FirstOrDefault();

                if(student != null)
                {
                    student.Name = command.Name;
                    student.Address = command.Address;
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
