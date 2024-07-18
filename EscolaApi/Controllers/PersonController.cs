using EscolaApi.Models;
using EscolaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        // POST api/<SchoolController>
        [HttpPost]
        public ActionResult Add(Person person)
        {
            _repository.Add(person);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var person = _repository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // PUT api/<SchoolController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            _repository.Update(person);
            return NoContent();
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingPerson = _repository.GetById(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}
