using Microsoft.AspNetCore.Mvc;
using StudentCatalog.Models;
using StudentCatalog.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _student;

        public StudentsController(IStudentService studentService)
        {
            this._student = studentService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public List<Student> Get()
        {
            return _student.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _student.Get(id);
            if(student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student value)
        {
            _student.Create(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Student> Put(string id, [FromBody] Student student)
        {
            var existingStudent = _student.Get(id);
            if(existingStudent == null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            _student.Update(id, student);
            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Student> Delete(string id)
        {
            var existingStudent = _student.Get(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            _student.Remove(id);
            return Ok($"Student with id = {id} is deleted!");
        }
    }
}
