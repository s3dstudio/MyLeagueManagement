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
    public class ClubsController : ControllerBase
    {
        ConnectDatabase connect = new ConnectDatabase();
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            connect.ConnectFirebase();
            ClubsBUS clubs = new ClubsBUS();
            string result;
            clubs.get(out result);
            return Ok(result);
        }
        [Route("api/Clubs/getbykey/{Key?}")]
        public IActionResult GetByKey(string key)
        {
            connect.ConnectFirebase();
            ClubsBUS clubs = new ClubsBUS();
            string result;
            clubs.getbykey(out result,key);
            return Ok(result);
        }
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] ClubsDTO club)
        {
            connect.ConnectFirebase();
            ClubsBUS clubs = new ClubsBUS();
            string jsonData = @"{'ID':'" + club.ID +"','_Key':'"+club._Key+ "','ClubName':'" + club.ClubName + "','Position':'" + club.Position + "','Stadium':'" + club.Stadium + "','Logo':'" + club.Logo + "','Manager':'" +
                club.Manager + "','Plays':'" + club.Plays + "','Won':'" + club.Won + "','Drawn':'" + club.Drawn + "','Lost':'" + club.Lost + "','Points':'" + club.Points + "','GF':'" + club.GF + "','GA':'" + club.GA
                + "','GD':'" + club.GD + "','BackGround':'" + club.BackGround + "','CoverImage':'" + club.CoverImage + "','LeagueKey' : '"+club.LeagueKey+"'}";
            clubs.post(ref jsonData);
            return Ok(club);
        }
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromBody] ClubsDTO club)
        {
            connect.ConnectFirebase();
            ClubsBUS clubs = new ClubsBUS();
            string jsonData = @"{'ID':'" + club.ID + "','_Key':'" + club._Key + "','ClubName':'" + club.ClubName + "','Position':'" + club.Position + "','Stadium':'" + club.Stadium + "','Logo':'" + club.Logo + "','Manager':'" +
                club.Manager + "','Plays':'" + club.Plays + "','Won':'" + club.Won + "','Drawn':'" + club.Drawn + "','Lost':'" + club.Lost + "','Points':'" + club.Points + "','GF':'" + club.GF + "','GA':'" + club.GA
                + "','GD':'" + club.GD + "','BackGround':'" + club.BackGround + "','CoverImage':'" + club.CoverImage + "','LeagueKey' : '" + club.LeagueKey + "'}";
            clubs.put(ref jsonData,club._Key);
            return Ok(club);
        }
        [Route("api/Clubs/delete/{Key?}")]
        public IActionResult Delete(string Key)
        {
            connect.ConnectFirebase();
            ClubsBUS clubs = new ClubsBUS();
            clubs.delete(Key);
            return StatusCode(200);
        }
    }

}
