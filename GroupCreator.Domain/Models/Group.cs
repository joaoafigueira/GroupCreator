using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupCreator.Domain.Models
{
    public class Group
    {
        public virtual Person Person { get; set; }

        public virtual int NumberOfGroups { get; set; }

        public virtual int PersonPerGroup { get; set; }
    }
}
