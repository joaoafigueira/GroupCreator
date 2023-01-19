using GroupCreator.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using RandomGroupCreator.Api.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace GroupCreator.Api.Controllers
{
    [Route("/api[controller]")]
    [ApiController]
    [SwaggerTag("Add people and form random groups with them!")]
    public class RandomGroupController : ControllerBase
    {
        [HttpPost]
        [Route("~/api/random-groups")]
        [SwaggerOperation(
            Summary = "Create Random groups",
            Description = "Create random groups from a list of people",
            OperationId = "CreateGroups"
            )]
        [SwaggerResponse(200, "Random Group Created.", typeof(PersonDto))]
        [SwaggerResponse(400, "Data is invalid!")]
        public async Task<IActionResult> CreateGroups(
            [FromQuery, SwaggerParameter("Filter By Person in each group", Required = false)] int quantityOfGroup,
            [FromQuery, SwaggerParameter("Filter By Number of Person in each group", Required = false)] int numberOfPersonInEachGroup,
            [FromBody] List<PersonDto> people
            )
        {
            if(people== null) throw new ArgumentNullException(nameof(people));


            return Ok();
        }
    }
}
