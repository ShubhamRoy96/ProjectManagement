using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    interface IBaseController
    {
        IActionResult Create();
        IActionResult RetrieveAll();
        void RetrieveOne();
        void Update();
        void Delete();        
    }
}
