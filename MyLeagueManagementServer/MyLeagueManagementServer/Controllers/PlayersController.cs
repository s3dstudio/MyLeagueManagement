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
        public IActionResult Post([FromBody] PlayersDTO player)
        {
            connect.ConnectFirebase();
            PlayersBUS players = new PlayersBUS();
            string jsonData = @"{'ID':'" + player.ID + "','Name':'" + player.Name + "','Birth':'" + player.Birth + "','Key_Type':'" + player.Key_Type + "','Goals':'" + player.Goals + "','Teams_Key':'" + player.Teams_Key + "'}";
            players.post(ref jsonData);
            return Ok(player);
        }
    }
}
