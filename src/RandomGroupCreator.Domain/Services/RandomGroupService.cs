using RandomGroupCreator.Domain.Dto;
using RandomGroupCreator.Domain.Enums;
using RandomGroupCreator.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGroupCreator.Domain.Services
{
    public class RandomGroupService : IRandomGroupService
    {
        private static readonly Random _randomNumber = new Random();

        public List<PersonGroupDto> GenerateRandomGroup(List<PersonDto> people, int quantity, GroupType groupType)
        {
            var shuffledPeople = ShufflePeople(people);

            var shuffledPeopleCount = shuffledPeople.Count;

            if (shuffledPeopleCount == quantity && groupType == GroupType.Group)
            {
                var personGroupPerGroup = AddPeoplePerGroup(shuffledPeople, quantity);

                return personGroupPerGroup;
            }

            var personGroupPerQuantity = AddPeoplePerQuantity(shuffledPeople, quantity);
           
            return personGroupPerQuantity;
        }


        public List<PersonGroupDto> AddPeoplePerQuantity(List<PersonDto> shuffledPeople, int quantity)
        {
            var partitionPeople = PartitionPeople(shuffledPeople, quantity);

            var personGroupList = new List<PersonGroupDto>();

            foreach (var partition in partitionPeople)
            {
                var personGroup = new PersonGroupDto()
                {
                    Group = partition
                };

                personGroupList.Add(personGroup);
            }

            return personGroupList;
        }


        public List<PersonGroupDto> AddPeoplePerGroup(List<PersonDto> shuffledPeople, int quantity)
        {
            var shuffledPeopleCount = shuffledPeople.Count;

            var personGroupList = new List<PersonGroupDto>();

            for (int i = 0; i <= shuffledPeopleCount - 1; i++)
            {
                var person = shuffledPeople[i];

                var personList = new List<PersonDto>
                {
                    person
                };

                var personGroup = new PersonGroupDto()
                {
                    Group = personList
                };

                personGroupList.Add(personGroup);
            }

            return personGroupList;
        }


        public static List<List<PersonDto>> PartitionPeople(List<PersonDto> people, int numberOfPersonInEachGroup)
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
                var randomNumber = _randomNumber.Next(i + 1);

                var lastPeople = people[i];
                people[i] = people[randomNumber];
                people[randomNumber] = lastPeople;
            }

            return people;
        }

    }
}
