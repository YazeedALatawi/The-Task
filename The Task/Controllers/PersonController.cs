using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using The_Task.Models;
using The_Task.Models.DataRepository;

namespace The_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepo repository;
        public PersonController(IPersonRepo repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _person = repository.GetByID(id);
            return _person == null ? NotFound() : Ok(_person);
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            if (ModelState.IsValid)
            {
                repository.Add(person);
                return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
            }

            return BadRequest(ModelState); 

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Person _person)
        {
            if (ModelState.IsValid)
            {
                var check = repository.GetByID(id);
                if (check == null) return NotFound();
                repository.Update(id, _person);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return NoContent();
        }
    }
}
