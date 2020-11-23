//using System;
//using System.Collections.Generic;
//using DemoApi.DAL;
//using DemoApi.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;

//namespace DemoApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentsController : ControllerBase
//    {
//        private readonly StudentAccessProvider _studentAccessProvider;

//        private readonly StudentRepository _studentRepository;

//        public StudentsController()
//        {
//            _studentRepository = new StudentRepository(new StudentContext());
//        }

//        public StudentsController(StudentAccessProvider studentAccessProvider, StudentRepository studentRepository)
//        {
//            _studentAccessProvider = studentAccessProvider;
//            _studentRepository = studentRepository;
//        }

//        [HttpPost]
//        public IActionResult Add(Student student) {
//            if (ModelState.IsValid)
//            {
//                _studentAccessProvider.InsertStudent(student);
//                return Ok(student);
//            }

//            return BadRequest();
//        }

//        [HttpPut]
//        public IActionResult Update(Student student)
//        {
//            if (ModelState.IsValid)
//            {
//                _studentAccessProvider.UpdateStudent(student);
//                return Ok(student);
//            }

//            return BadRequest();
//        }

//        [HttpGet]
//        public IEnumerable<Student> GetAll()
//        {
//            return _studentRepository.FindAll();
//        }


//        [HttpGet("{id}")]
//        public Student Get(Guid id)
//        {
//            return _studentRepository.FindById(id);
//        }

//        [HttpDelete("{id}")]
//        public void Delete(Guid id)
//        {
//             _studentAccessProvider.DeleteStudent(id);
//        }
//    }
//}

using System.Threading.Tasks;
using DemoApi.Features.StudentFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using DemoApi.Features.StudentFeatures.Commands;
using System;
using DemoApi.Interface;
using DemoApi.Models;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    //private IMediator _mediator;

    //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    //[HttpPost]
    //public async Task<IActionResult> Create(CreateStudentCommand command)
    //{
    //    return Ok(await Mediator.Send(command));
    //}
    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //    return Ok(await Mediator.Send(new GetAllStudentsQuery()));
    //}
    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetById(Guid id)
    //{
    //    return Ok(await Mediator.Send(new GetStudentByIdQuery { Id = id }));
    //}
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    return Ok(await Mediator.Send(new DeleteStudentByIdCommand { Id = id }));
    //}
    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(Guid id, UpdateStudentCommand command)
    //{
    //    if (id != command.Id)
    //    {
    //        return BadRequest();
    //    }
    //    return Ok(await Mediator.Send(command));
    //}

    private readonly IUnitOfWork _unitOfWork;

    public StudentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetStudent()
    {
        var students = _unitOfWork.Students.GetStudent();
        return Ok(students);
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        _unitOfWork.Students.Add(student);
        _unitOfWork.Complete();
        return Ok(student.Id);
    }
}