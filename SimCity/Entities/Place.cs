using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Entities
{
    public class Place
    {
        public virtual int Id { get; set; }
        public virtual string Street { get; set; }
        public virtual int PlacePopulation { get; set; }
        public virtual City City { get; set; }
        public virtual Building Building { get; set; }
    }
}
