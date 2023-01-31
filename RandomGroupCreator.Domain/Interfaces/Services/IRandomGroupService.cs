using RandomGroupCreator.Domain.Dto;

namespace RandomGroupCreator.Domain.Interfaces.Services
{
    public interface IRandomGroupService
    {
        List<PersonDto> ShufflePeople(List<PersonDto> people);

        //List<PersonGroupDto> GenerateRandomGroup(List<PersonDto> people, int numberOfPersonInEachGroup, int quantityOfGroup);

        List<GroupDto> AddPersonPerQuantityOfGroup(List<PersonDto> shuffledPeople, int quantityOfGroup);
    }
}
