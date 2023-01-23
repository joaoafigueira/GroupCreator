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
            var shuffledPeople = people.OrderBy(p => _randomNumber.Next()).ToList();

            return shuffledPeople;
        }

        //TODO: Implement our own Shuffle algorithm




    }
}
