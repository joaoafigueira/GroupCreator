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
        [SwaggerResponse(200, "Random Group Created.", typeof(PersonGroupDto))]
        public IActionResult CreateRandomGroup(
            [FromBody] List<PersonDto> people,
            [FromQuery, SwaggerParameter("Filter By Number of groups", Required = false)] int quantityOfGroup = 0,
            [FromQuery, SwaggerParameter("Filter By Number of Person in each group", Required = false)] int numberOfPersonInEachGroup = 0)
        {
            var randomGroup =  _randomGroupService.AddPersonPerQuantityOfGroup(people, quantityOfGroup); //TODO: Add quantity of group, change methods modifiers and refactor code.

            return Ok(randomGroup);
        }
    }
}
