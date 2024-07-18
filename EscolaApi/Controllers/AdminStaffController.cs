using EscolaApi.Models;
using EscolaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EscolaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminStaffController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public AdminStaffController(IPersonRepository repository)
        {
            _repository = repository;
        }

        // POST api/<AdminStaffController>
        [HttpPost]
        public ActionResult Add(AdminStaff adminStaff)
        {
            _repository.Add(adminStaff);
            return CreatedAtAction(nameof(GetById), new { id = adminStaff.Id }, adminStaff);
        }

        // GET: api/<AdminStaffController>
        [HttpGet]
        public ActionResult<IEnumerable<AdminStaff>> GetAll()
        {
            var adminStaffs = _repository.GetAll().OfType<AdminStaff>();
            return Ok(adminStaffs);
        }

        // GET api/<AdminStaffController>/5
        [HttpGet("{id}")]
        public ActionResult<AdminStaff> GetById(int id)
        {
            var adminStaffs = _repository.GetById(id) as AdminStaff;
            if (adminStaffs == null)
            {
                return NotFound();
            }
            return Ok(adminStaffs);
        }

        // PUT api/<AdminStaffController>/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, AdminStaff adminStaff)
        {
            if (id != adminStaff.Id)
            {
                return BadRequest();
            }
            _repository.Update(adminStaff);
            return NoContent();
        }

        // DELETE api/<AdminStaffController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingAdminStaff = _repository.GetById(id) as AdminStaff;
            if (existingAdminStaff == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            return NoContent();
        }
    }
}
