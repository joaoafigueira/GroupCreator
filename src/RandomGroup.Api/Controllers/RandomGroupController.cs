using Microsoft.AspNetCore.Mvc;
using RandomGroupCreator.Domain.Dto;
using RandomGroupCreator.Domain.Enums;
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
            _randomGroupService = randomGroupService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create Random groups",
            Description = "Create random groups from a list of people",
            OperationId = "CreateGroups"
            )]
        [SwaggerResponse(200, "Random Group Created.", typeof(PersonGroupDto))]
        public IActionResult CreateRandomGroup(
            [FromBody,  SwaggerParameter(Required = true)] List<PersonDto> people, 
            [FromQuery, SwaggerParameter( Required = true)] int quantity, 
            [FromQuery, SwaggerParameter("Pass 0 to filter for a number of group or 1 to filter for number of persons per each group", Required = true)]  GroupType groupType)
        {
            try
            {
                var randomGroup = _randomGroupService.GenerateRandomGroup(people, quantity, groupType);

                return Ok(randomGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
