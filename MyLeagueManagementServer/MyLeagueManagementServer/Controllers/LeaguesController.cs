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
    public class LeaguesController : ControllerBase
    {
        ConnectDatabase connect = new ConnectDatabase();
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            connect.ConnectFirebase();
            LeaguesBUS leagues = new LeaguesBUS();
            leagues.get(out string result);
            return Ok(result);
        }
        [Route("api/Leagues/getbykey/{Key?}")]
        public IActionResult GetByKey(string key)
        {
            connect.ConnectFirebase();
            LeaguesBUS leagues = new LeaguesBUS();
            leagues.getbykey(out string result, key);
            return Ok(result);
        }
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] LeaguesDTO league)
        {
            connect.ConnectFirebase();
            LeaguesBUS leagues = new LeaguesBUS();
            string jsonData = @"{'_Key' : '" + league._Key + "', 'LeagueName' : '" + league.LeagueName + "','Logo': '" + league.Logo + "', 'NumClub' : '" + league.NumClub + "','Nationality' : '" + league.Nationality + "', 'CoverImg' : '" + league.CoverImg + "', 'IsActive' : '" + league.IsActive + "', 'RuleKey' : '" + league.RuleKey + "'}";
            leagues.post(ref jsonData);
            return Ok(league);
        }
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromBody] LeaguesDTO league)
        {
            connect.ConnectFirebase();
            LeaguesBUS leagues = new LeaguesBUS();
            string jsonData = @"{'_Key' : '" + league._Key + "', 'LeagueName' : '" + league.LeagueName + "','Logo': '" + league.Logo + "', 'NumClub' : '" + league.NumClub + "','Nationality' : '" + league.Nationality + "', 'CoverImg' : '" + league.CoverImg + "', 'IsActive' : '" + league.IsActive + "', 'RuleKey' : '" + league.RuleKey + "'}";
            leagues.put(ref jsonData, league._Key);
            return Ok(league);
        }
        [Route("api/Leagues/delete/{Key?}")]
        //[HttpDelete]
        public IActionResult Delete(string Key)
        {
            connect.ConnectFirebase();
            LeaguesBUS leagues = new LeaguesBUS();
            leagues.delete(Key);
            return StatusCode(200);
        }
    }

}
