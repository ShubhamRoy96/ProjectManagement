using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public interface IRepository<T>
    {
        IActionResult Create(T value);
        IActionResult RetrieveAll();
        IActionResult RetrieveByID(int ID);
        IActionResult Update(T value);
        IActionResult Delete(int ID);
    }
}
