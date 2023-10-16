using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    { 
        [HttpGet]
        public IEnumerable<string> GetNumberOfPlayers()
        {
            DBHAndler dBHAndler = new DBHAndler();
            string result = null;

            result = dBHAndler.RunStringQuery($"SELECT COUNT(*) FROM quiztest.players");
            return new string[] { result };
        }

        // GET api/<PlayerController>/5
        [HttpGet("{name}")]
        public string GetPlayerID(string name)
        {
            DBHAndler dBHAndler = new DBHAndler();
            string result = null;

            result = dBHAndler.RunStringQuery($"SELECT PlayerID FROM quiztest.players WHERE PlayerName = '{name}';");
            return result;
        }
        
        [HttpGet("isdone")]
        public string GetPlayerIsDone(string name)
        {
            DBHAndler dBHAndler = new DBHAndler();
            string result = null;

            result = dBHAndler.RunStringQuery($"SELECT IsDone FROM quiztest.players WHERE PlayerName NOT IN ('{name}')");
            return result;
        }
        
        [HttpGet("points")]
        public string GetPlayerScore(string name)
        {
            DBHAndler dBHAndler = new DBHAndler();
            string result = null;

            result = dBHAndler.RunStringQuery($"SELECT Score FROM quiztest.players WHERE PlayerName NOT IN ('{name}')");
            return result;
        }

        [HttpPost("name")]
        public void InsertPlayerName(string name)
        {
            DBHAndler dBHAndler = new DBHAndler();

            dBHAndler.RunStringQuery($"INSERT INTO quiztest.players (`PlayerName`) VALUES ('{name}')");
        }

        [HttpPost("score")]
        public void InsertPlayerScore(int score, string name)
        {
            string playerID = (GetPlayerID(name));

            DBHAndler dBHAndler = new DBHAndler();
            dBHAndler.RunStringQuery($"UPDATE `quiztest`.`players` SET `Score` = '{score}' WHERE (`PlayerID` = '{playerID}')");
        }

        [HttpPost("isdone")]

        public void InsertPlayerIsReady(int isdone, string name)
        {
            string playerID = (GetPlayerID(name));

            DBHAndler dBHAndler = new DBHAndler();
            dBHAndler.RunStringQuery($"UPDATE `quiztest`.`players` SET `IsDone` = {isdone} WHERE (`PlayerID` = '{playerID}')");
        }
    }
}
