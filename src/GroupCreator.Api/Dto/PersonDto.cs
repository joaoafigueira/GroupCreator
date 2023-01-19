using System.ComponentModel.DataAnnotations;

namespace RandomGroupCreator.Api.Dto
{
    public class PersonDto
    {
        [Required]
        public string Name { get; set; }
    }
}
