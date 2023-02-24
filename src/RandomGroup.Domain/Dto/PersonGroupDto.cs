using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGroupCreator.Domain.Dto
{
    public class PersonGroupDto
    {
        public PersonGroupDto(List<PersonDto> group)
        {
            Group = group;
        }

        public List<PersonDto> Group { get; set; }

    }
}
