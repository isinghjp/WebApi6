using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            List<Student> students =_studentRepository.GetAllStudents();
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student student = _studentRepository.GetStudentById(id);
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post(Student student)
        {
            _studentRepository.AddStudent(student);
            
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, Student student)
        {
            student.ID= id;
            _studentRepository.UpdateStudent(student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
    }
}
