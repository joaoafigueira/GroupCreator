using RandomGroupCreator.Domain.Dto;
using RandomGroupCreator.Domain.Enums;
using RandomGroupCreator.Domain.Interfaces.Services;

namespace RandomGroupCreator.Domain.Services
{
    public class RandomGroupService : IRandomGroupService
    {
        private static readonly Random _randomNumber = new Random();

        public List<PersonGroupDto> GenerateRandomGroup(List<PersonDto> people, int quantity, GroupType groupType)
        {
            if (people.Count == 0 || quantity <= 0)
            {
                throw new ArgumentNullException("Paremeter can not be less or equal than zero.");
            }

            var shuffledPeople = ShufflePeople(people);

            var randomGroup = CreateGroup(shuffledPeople, groupType, quantity);

            return randomGroup;
        }


        public List<PersonGroupDto> CreateGroup(List<PersonDto> shuffledPeople, GroupType groupType, int quantity)
        {
            if (groupType == GroupType.People)
            {
                var splitPeople = SplitPeople(shuffledPeople, quantity);

                var personGroup = CreatePersonGroupList(splitPeople);

                return personGroup;
            }

            return null;
        }


        public List<PersonGroupDto> CreatePersonGroupList(List<List<PersonDto>> splittedGroups)
        {
            var personGroupList = new List<PersonGroupDto>();

            foreach (var group in splittedGroups)
            {
                var personGroup = new PersonGroupDto(group);

                personGroupList.Add(personGroup);
            }
         
            return personGroupList;
        }

        //public static List<List<PersonDto>> PartionGroup(List<PersonDto> shuffledPeople, int quantity)
        //{

        //}

        public static List<List<PersonDto>> SplitPeople(List<PersonDto> people, int numberOfPersonInEachGroup)
        {
            return people.Select((x, i) => new { Index = i, Value = x })
                   .GroupBy(x => x.Index / numberOfPersonInEachGroup)
                   .Select(x => x.Select(v => v.Value).ToList())
                   .ToList();
        }

        public List<PersonDto> ShufflePeople(List<PersonDto> people)
        {
            for (int i = people.Count - 1; i > 0; --i)
            {
                var randomIndex = _randomNumber.Next(i + 1);

                var lastPeople = people[i];
                people[i] = people[randomIndex];
                people[randomIndex] = lastPeople;
            }

            return people;
        }

    }
}
