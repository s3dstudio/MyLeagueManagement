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
    public class RulesController : ControllerBase
    {
        ConnectDatabase connect = new ConnectDatabase();
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            connect.ConnectFirebase();
            RulesBUS rules = new RulesBUS();
            string result;
            rules.get(out result);
            return Ok(result);
        }
        [Route("api/Rules/getbykey/{Key?}")]
        public IActionResult GetByKey(string key)
        {
            connect.ConnectFirebase();
            RulesBUS rules = new RulesBUS();
            string result;
            rules.getbykey(out result, key);
            return Ok(result);
        }
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] RulesDTO rule)
        {
            connect.ConnectFirebase();
            RulesBUS rules = new RulesBUS();
            string jsonData = @"{'_Key' : '" + rule._Key + "', 'MinAge' : '" + rule.MinAge + "', 'MaxAge' : '" + rule.MaxAge + "', 'MaxSquadSize' : '" + rule.MaxSquadSize + "', 'MinSquadSize' : '" + rule.MinSquadSize + "', 'MaxForeign' : '" + rule.MaxForeign + "', 'WinPoit' : '" +
                               rule.WinPoint + "', 'LossPoit' : '" + rule.LossPoint + "', 'DrawPoit' : '" + rule.DrawPoint + "', 'Priority' : '" + rule.Priority + "', 'Stoppage' : '" + rule.Stoppage + "','MaxStoppageTime' : " + rule.MaxStoppageTime + "'}";
            rules.post(ref jsonData);
            return Ok(rule);
        }
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromBody] RulesDTO rule)
        {
            connect.ConnectFirebase();
            RulesBUS rules = new RulesBUS();
            string jsonData = @"{'_Key' : '" + rule._Key + "', 'MinAge' : '" + rule.MinAge + "', 'MaxAge' : '" + rule.MaxAge + "', 'MaxSquadSize' : '" + rule.MaxSquadSize + "', 'MinSquadSize' : '" + rule.MinSquadSize + "', 'MaxForeign' : '" + rule.MaxForeign + "', 'WinPoit' : '" +
                                rule.WinPoint + "', 'LossPoit' : '" + rule.LossPoint + "', 'DrawPoit' : '" + rule.DrawPoint + "', 'Priority' : '" + rule.Priority + "', 'Stoppage' : '" + rule.Stoppage + "','MaxStoppageTime' : "+rule.MaxStoppageTime+"'}";
            rules.put(ref jsonData,rule._Key);
            return Ok(rule);
        }
        [Route("api/Clubs/delete/{Key?}")]
        //[HttpDelete]
        public IActionResult Delete(string Key)
        {
            connect.ConnectFirebase();
            RulesBUS rules = new RulesBUS();
            rules.delete(Key);
            return StatusCode(200);
        }
    }

}
