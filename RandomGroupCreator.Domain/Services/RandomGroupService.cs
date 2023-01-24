using RandomGroupCreator.Domain.Dto;
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
