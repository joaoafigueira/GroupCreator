using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGroupCreator.Domain.Models
{
    public class Person
    {
        [Required]
        public virtual string Name { get; set; }

    }
}
