using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Entities
{
    public class City
    {
        public virtual int Id { get;set; }
        public virtual string Name { get; set; }
        public virtual int Population { get; set; }
        public virtual Country Country { get; set; }
        public virtual IList<Place> Places { get; set; }
    }
}
