using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpendituresCalculatorApp.BackEnd.Controllers
{
    public class HomeController : ControllerBase
    {
        public Object Index()
        {
            return new { Status = "ok" };
        }
    }
}
