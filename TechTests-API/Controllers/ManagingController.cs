using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTests_API.Data;

namespace TechTests_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagingController : ControllerBase
    {
        public TechTestsDbContext DbContext { get; set; }
        public ManagingController(TechTestsDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpDelete]
        [Route("clearQuestions")]
        public IActionResult ClearQuestions()
        {
            try
            {
                this.DbContext.Questions.RemoveRange(this.DbContext.Questions.ToList());
                this.DbContext.SaveChanges();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("clearDb")]
        public IActionResult ClearDb()
        {
            try
            {
                this.DbContext.Categories.RemoveRange(this.DbContext.Categories.ToList());
                this.DbContext.Descriptions.RemoveRange(this.DbContext.Descriptions.ToList());
                this.DbContext.Types.RemoveRange(this.DbContext.Types.ToList());
                this.DbContext.Answears.RemoveRange(this.DbContext.Answears.ToList());
                this.DbContext.AnswearValues.RemoveRange(this.DbContext.AnswearValues.ToList());
                this.DbContext.Questions.RemoveRange(this.DbContext.Questions.ToList());

                this.DbContext.SaveChanges();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
