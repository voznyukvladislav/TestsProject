using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTests_API.Data;
using TechTests_API.DTOs;
using TechTests_API.Models;
using TechTests_API.Services;

namespace TechTests_API.Controllers
{
    [Route("api/tests")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        public TechTestsDbContext DbContext { get; set; }
        public TestService TestService { get; set; }
        public TestsController(TechTestsDbContext dbContext, TestService testService)
        {
            this.DbContext = dbContext;
            this.TestService = testService;
        }

        [HttpGet]
        [Route("getTest")]
        public IActionResult GetTests(int count)
        {
            try
            {
                List<QuestionDTO> questionDTOs = this.TestService.GetQuestions(count);
                return Ok(questionDTOs);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("answearTest")]
        public IActionResult AnswearTest(List<AnswearedQuestionDTO> questions)
        {
            try
            {
                ResultDTO result = this.TestService.AnswearTest(questions);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
