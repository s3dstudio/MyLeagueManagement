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
    public class MatchResultsController : ControllerBase
    {
        ConnectDatabase connect = new ConnectDatabase();
        [HttpGet]
        public IActionResult Get()
        {
            connect.ConnectFirebase();
            MatchResultsBUS matchResults = new MatchResultsBUS();
            string result;
            matchResults.get(out result);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] MatchResultsDTO matchResult)
        {
            connect.ConnectFirebase();
            MatchResultsBUS matchResults = new MatchResultsBUS();
            string jsonData = @"{'ID':'" + matchResult.ID + "','Goals_Team1':'" + matchResult.Goals_Team1 + "','Goals_Team2':'" + matchResult.Goals_Team2 + "','DetailMatchResult_Key':'" + matchResult.DetailMatchResult_Key + "'}";
            matchResults.post(ref jsonData);
            return Ok(matchResult);
        }

    }
}
