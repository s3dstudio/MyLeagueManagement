using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLeagueManagementServer.BUS;
using MyLeagueManagementServer.DAL;
using MyLeagueManagementServer.DTO;

namespace MyLeagueManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ConnectDatabase connectDatabase = new ConnectDatabase();

        [HttpGet]
        public IActionResult Get()
        {
            connectDatabase.ConnectFirebase();
            TeamsBUS teams = new TeamsBUS();
            string result;
            teams.get(out result);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] TeamsDTO team)
        {
            connectDatabase.ConnectFirebase();
            TeamsBUS teams = new TeamsBUS();
            string jsonData = @"{'ID':'" + team.ID + "','Name':'" + team.Name + "','NoPlayer':'" + team.NoPlayer + "','HomeGround':'" + team.HomeGround + "'}";
            teams.post(ref jsonData);
            return Ok(team);
        }
    }
}
