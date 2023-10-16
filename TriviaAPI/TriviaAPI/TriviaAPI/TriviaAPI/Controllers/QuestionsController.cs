using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        // GET: api/<QuestionsController>
        [HttpGet]
        public int Get()
        {
            //get the number of questions
            return 10;
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public Question GetQuestion(int id)
        {
            DBHAndler dBHAndler = new DBHAndler();
            return dBHAndler.GetQuestion(id);
        }
    }
}
