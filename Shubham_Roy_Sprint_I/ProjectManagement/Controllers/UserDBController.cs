using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserDBController : ControllerBase, IRepository<User>
    {
        //// GET: api/<UserDBController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserDBController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserDBController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserDBController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserDBController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public IActionResult Create(User value)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IActionResult RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public IActionResult RetrieveByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(User value)
        {
            throw new NotImplementedException();
        }
    }
}
