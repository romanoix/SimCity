using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Entities
{
    public class Country
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Continent { get; set; }
        public virtual President President { get; set; }
        public virtual IList<City> Cities { get; set; }

    }
}
