using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    interface IBaseController
    {
        void Create();
        void RetrieveAll();
        void RetrieveOne();
        void Update();
        void Delete();        
    }
}
