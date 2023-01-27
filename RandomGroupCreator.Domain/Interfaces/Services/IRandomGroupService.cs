using RandomGroupCreator.Domain.Dto;

namespace RandomGroupCreator.Domain.Interfaces.Services
{
    public interface IRandomGroupService
    {
        List<PersonDto> ShufflePeople(List<PersonDto> people);

        List<PersonGroupDto> GenerateRandomGroups(List<PersonDto> persons, int numberOfPersonInEachGroup);
    }
}
