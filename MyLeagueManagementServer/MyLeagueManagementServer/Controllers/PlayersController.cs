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
    public class PlayersController : ControllerBase
    {
        ConnectDatabase connect = new ConnectDatabase();
        [HttpGet]
        public IActionResult Get()
        {
            connect.ConnectFirebase();
            PlayersBUS players = new PlayersBUS();
            string result;
            players.get(out result);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PlayersDTO player)
        {
            connect.ConnectFirebase();
            PlayersBUS players = new PlayersBUS();
            string jsonData = @"{'ID':'" + player.ID + "','Name':'" + player.Name + "','DoB':'" + player.DoB + "','Key_Type':'" + player.Key_Type + "','AllGoal':'" + player.AllGoal + "','Teams_Key':'" + 
                player.Teams_Key + "','Position':'"+player.Position+ "','Nationality':'"+player.Nationality+"','Image':'"+player.Image +"','Number':'"+player.Number+ "'}";
            players.post(ref jsonData);
            return Ok(player);
        }
        [HttpPut]
        public IActionResult Put([FromBody] PlayersDTO player)
        {
            connect.ConnectFirebase();
            PlayersBUS players = new PlayersBUS();
            string jsonData = @"{'ID':'" + player.ID + "','Name':'" + player.Name + "','DoB':'" + player.DoB + "','Key_Type':'" + player.Key_Type + "','AllGoal':'" + player.AllGoal + "','Teams_Key':'" +
                player.Teams_Key + "','Position':'" + player.Position + "','Nationality':'" + player.Nationality + "','Image':'" + player.Image + "','Number':'" + player.Number + "'}";
            players.put(ref jsonData,player.Teams_Key);
            return Ok(player);
        }
    }
}
