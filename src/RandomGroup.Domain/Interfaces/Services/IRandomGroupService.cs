using RandomGroupCreator.Domain.Dto;
using RandomGroupCreator.Domain.Enums;

namespace RandomGroupCreator.Domain.Interfaces.Services
{
    public interface IRandomGroupService
    {
        List<PersonDto> ShufflePeople(List<PersonDto> people);

        List<PersonGroupDto> GenerateRandomGroup(List<PersonDto> people, int quantity, GroupType groupType);

        List<PersonGroupDto> CreateGroup(List<PersonDto> shuffledPeople, GroupType groupType, int quantity);
    }
}
