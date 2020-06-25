using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLeagueManagementServer.DTO;
using MyLeagueManagementServer.BUS;
using MyLeagueManagementServer.DAL;

namespace MyLeagueManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ConnectDatabase connectDatabase = new ConnectDatabase();
        [HttpGet]
        public IActionResult Get()
        {
            connectDatabase.ConnectFirebase();
            Method method = new Method();
            string result;
            method.get(out result);
            return Ok(result);
        }
    }
}
