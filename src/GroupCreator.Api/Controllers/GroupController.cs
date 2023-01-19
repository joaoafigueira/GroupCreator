using GroupCreator.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GroupCreator.Api.Controllers
{
    [Route("/api[controller]")]
    [ApiController]
    [SwaggerTag("Add people and create groups which are randomly chosen")]
    public class GroupController : ControllerBase
    {

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create groups",
            Description = "Create groups of randomly people",
            OperationId = "GetGrouping"
            )]
        [Route("~/api/groups")]
        public async Task<IActionResult> CreateGroups()
        {
            return Ok();
        }
    }
}
