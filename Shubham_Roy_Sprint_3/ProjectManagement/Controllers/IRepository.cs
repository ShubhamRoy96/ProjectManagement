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
        T Create(T value);
        List<T> RetrieveAll();
        T RetrieveByID(int ID);
        T Update(T value);
        bool Delete(int ID);
    }
}
