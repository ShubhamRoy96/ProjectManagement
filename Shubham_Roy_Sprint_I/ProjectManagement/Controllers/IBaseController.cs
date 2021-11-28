using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    interface IBaseController<T>
    {
        IActionResult Create(T value);
        IActionResult RetrieveAll();
        IActionResult RetrieveByID(int ID);
        IActionResult Update(T value);        
    }
}
