using System;
using System.Collections.Generic;
using DemoApi.DAL;
using DemoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentAccessProvider _studentAccessProvider;

        private readonly StudentRepository _studentRepository;

        public StudentsController()
        {
            _studentRepository = new StudentRepository(new StudentContext());
        }

        public StudentsController(StudentAccessProvider studentAccessProvider, StudentRepository studentRepository)
        {
            _studentAccessProvider = studentAccessProvider;
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public IActionResult Add(Student student) {
            if (ModelState.IsValid)
            {
                _studentAccessProvider.InsertStudent(student);
                return Ok(student);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentAccessProvider.UpdateStudent(student);
                return Ok(student);
            }

            return BadRequest();
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.FindAll();
        }


        [HttpGet("{id}")]
        public Student Get(Guid id)
        {
            return _studentRepository.FindById(id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
             _studentAccessProvider.DeleteStudent(id);
        }
    }
}
