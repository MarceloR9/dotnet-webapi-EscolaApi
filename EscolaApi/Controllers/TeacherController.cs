using EscolaApi.Models;
using EscolaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public TeacherController(IPersonRepository repository)
        {
            _repository = repository;
        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult Add(Teacher teacher)
        {
            _repository.Add(teacher);
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetAll()
        {
            var teachers = _repository.GetAll().OfType<Teacher>();
            return Ok(teachers);
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> GetById(int id)
        {
            var teacher = _repository.GetById(id) as Teacher;
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _repository.Update(teacher);
            return NoContent();
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingTeacher = _repository.GetById(id) as Teacher;
            if (existingTeacher == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}
