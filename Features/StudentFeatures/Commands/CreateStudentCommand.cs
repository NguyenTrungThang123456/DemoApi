using System;
using System.Threading;
using System.Threading.Tasks;
using DemoApi.DAL;
using DemoApi.Models;
using MediatR;
namespace DemoApi.Features.StudentFeatures.Commands
{ 
    public class CreateStudentCommand : IRequest<Guid>
    {
        public string Name { get; set; }
   
        public string Address { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly StudentContext _context;

        public CreateProductCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = new Student();

            student.Name = command.Name;
            student.Address = command.Address;


            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student.Id;
        }
    }
}