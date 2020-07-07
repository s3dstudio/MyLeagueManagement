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
    public class LeaguesController : ControllerBase
    {
        ConnectDatabase connect = new ConnectDatabase();
        [HttpGet]
        public IActionResult Get()
        {
            connect.ConnectFirebase();
            LeaguesBUS leagues = new LeaguesBUS();
            string result;
            leagues.get(out result);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] LeaguesDTO league)
        {
            connect.ConnectFirebase();
            LeaguesBUS leagues = new LeaguesBUS();
            string jsonData = @"{'ID':'" + league.ID + "','LeagueName':'" + league.LeagueName + "','NumClub':'" + league.NumClub + "','Logo':'" + league.Logo + "','Nationality':'" +league.Nationality+ "'}";
            leagues.post(ref jsonData);
            return Ok(league);
        }
    }
}
