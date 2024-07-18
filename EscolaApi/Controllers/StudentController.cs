using EscolaApi.Models;
using EscolaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public StudentController(IPersonRepository repository)
        {
            _repository = repository;
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Add(Student student)
        {
            _repository.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            var students = _repository.GetAll().OfType<Student>();
            return Ok(students);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = _repository.GetById(id) as Student;
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _repository.Update(student);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingStudent = _repository.GetById(id) as Student;
            if (existingStudent != null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}
