using System.ComponentModel.DataAnnotations;

namespace RandomGroupCreator.Domain.Dto
{
    public class PersonDto
    {
        [Required]
        public string Name { get; set; }
    }
}
