using demo.IService;
using demo.mongo.common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{id}")]
        //public ActionResult<Person> Get(string id)
        public IActionResult Get(string id)
        {
            var result = _personService.FindById(id);

            if (result is null)
            {
                return NotFound("id person not found");
            }
            return Ok(result);
        }

        [HttpGet("all")]
        public ActionResult Get()
        {
            List<Person> result = _personService.FindAll().ToList();
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<Person>> Get([FromBody] Person person)
        {
            List<Person> result;

            result = _personService.Find(person).ToList();
            
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var result = _personService.InsertOne(person);
            return Ok(result);
        }

        [HttpPost("many")]
        public IActionResult Post([FromBody] IEnumerable<Person> persons)
        {
            var result = _personService.InsertMany(persons);
            return Ok(result);
        }


    }
}
