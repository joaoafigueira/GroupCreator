using Microsoft.AspNetCore.Mvc;
using RandomGroupCreator.Domain.Dto;
using RandomGroupCreator.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RandomGroupCreator.Api.Controllers
{
    [Route("/api/random-groups")]
    [ApiController]
    [SwaggerTag("Add people and form random groups with them!")]
    public class RandomGroupController : ControllerBase
    {
        private readonly IRandomGroupService _randomGroupService;

        public RandomGroupController(IRandomGroupService randomGroupService)
        {
            _randomGroupService= randomGroupService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create Random groups",
            Description = "Create random groups from a list of people",
            OperationId = "CreateGroups"
            )]
        [SwaggerResponse(200, "Random Group Created.", typeof(PersonDto))]
        public async Task<IActionResult> CreateRandomGroup(
            [FromQuery, SwaggerParameter("Filter By Person in each group", Required = false)] int quantityOfGroup,
            [FromQuery, SwaggerParameter("Filter By Number of Person in each group", Required = false)] int numberOfPersonInEachGroup,
            [FromBody] List<PersonDto> people
            )
        {
            var shuffledPeople = _randomGroupService.ShufflePeople(people);

            return Ok(shuffledPeople);
        }
    }
}
