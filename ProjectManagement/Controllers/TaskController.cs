using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase, IBaseController
    {
        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public void Delete()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult RetrieveAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public void RetrieveOne()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
