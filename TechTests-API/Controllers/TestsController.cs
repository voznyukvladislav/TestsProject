using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
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
        [Route("questionGroups")]
        public IActionResult GetQuestionGroups()
        {
            List<QuestionGroupDTO> questionGroups = this.TestService.GetQuestionGroups();

            return Ok(questionGroups);
        }

        [HttpGet]
        [Route("questionGroup")]
        public IActionResult GetQuestionGroup(int questionGroupId)
        {
            QuestionGroupDTO questionGroupDTO = this.TestService.GetQuestionGroup(questionGroupId);

            return Ok(questionGroupDTO);
        }

        [HttpGet]
        [Route("questions")]
        public IActionResult GetQuestions(int questionGroupId)
        {
            return Ok(this.TestService.GetQuestions(questionGroupId));
        }

        [Authorize]
        [HttpGet]
        [Route("results")]
        public IActionResult GetResults()
        {
            try
            {
                Claim userIdClaim = this.HttpContext.User.Identities.First()
                    .Claims
                    .Where(c => c.Type == ClaimTypes.NameIdentifier)
                    .First();

                User user = this.DbContext.Users
                    .Where(u => u.Id == Convert.ToInt32(userIdClaim.Value))
                    .Include(u => u.Results)
                    .First();

                List<ResultShortDTO> shortResults = user.Results
                    .Select(r => FactoryDTO.GetResultDTO(r))
                    .ToList();
                if (shortResults.Count > 0) return Ok(shortResults);
                else
                {
                    Message message = Message.CreateFailed("Results", "No results to show");
                    return BadRequest(message);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("result")]
        public IActionResult GetResult(int resultId)
        {
            try
            {
                ResultDTO result = this.TestService.GetResultDTO(resultId);

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("answerTest")]
        public async Task<IActionResult> AnswerTestAsync([FromQuery] int questionGroupId, List<AnsweredQuestionDTO> questions)
        {
            try
            {
                ResultDTO result = this.TestService.AnswerTest(questionGroupId, questions);

                Claim userIdClaim = this.HttpContext.User.Identities.First()
                    .Claims
                    .Where(c => c.Type == ClaimTypes.NameIdentifier)
                    .First();
                
                User user = this.DbContext.Users
                    .First(u => u.Id == Convert.ToInt32(userIdClaim.Value));

                await this.TestService.SaveTestResultAsync(user, result);

                return Ok(result);
            }
            catch
            {
                Message message = Message.CreateFailed("Answer test", "Some error has happened during answering test!");

                return BadRequest(message);
            }
        }
    }
}
