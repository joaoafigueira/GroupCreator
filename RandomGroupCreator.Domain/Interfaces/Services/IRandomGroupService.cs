using RandomGroupCreator.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGroupCreator.Domain.Interfaces.Services
{
    public interface IRandomGroupService
    {
        List<PersonDto> ShufflePeople(List<PersonDto> people);
    }
}
