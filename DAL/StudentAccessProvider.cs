using System;
using DemoApi.Models;

namespace DemoApi.DAL
{
    public class StudentAccessProvider
    {

        private readonly StudentContext _studentContext;
        public StudentAccessProvider(StudentContext studentContext)
        {
            this._studentContext = studentContext; 
        }

        public void InsertStudent(Student student) {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();

        }

        public void UpdateStudent(Student student)
        {
            _studentContext.Students.Update(student);
            _studentContext.SaveChanges();
        }

        public void DeleteStudent(Guid id)
        {
            var _student = _studentContext.Students.Find(id);
            _studentContext.Students.Remove(_student);
            _studentContext.SaveChanges();
        }
    }
}
