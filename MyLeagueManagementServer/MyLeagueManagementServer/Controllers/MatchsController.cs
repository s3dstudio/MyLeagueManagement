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
    public class MatchsController : ControllerBase
    {
        ConnectDatabase connect = new ConnectDatabase();
        [HttpGet]
        public IActionResult Get()
        {
            connect.ConnectFirebase();
            MatchsBUS matchs = new MatchsBUS();
            string result;
            matchs.get(out result);
            return Ok(result);
        }
        public IActionResult Post([FromBody] MatchsDTO match)
        {
            connect.ConnectFirebase();
            MatchsBUS matchs = new MatchsBUS();
            string jsonData = @"{'ID':'" + match.ID + "','ID_Team1':'" + match.ID_Team1 + "','ID_Team2':'" + match.ID_Team2 + "','Stadium':'" + match.Stadium + "','MatchResult_Key':'" + match.MatchResult_Key + "'}";
            matchs.post(ref jsonData);
            return Ok(match);
        }
    }
}
