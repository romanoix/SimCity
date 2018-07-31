using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Entities
{
    public class Building
    {
        public virtual int Id { get; protected set; }
        public virtual string Type { get; set; }
        public virtual bool HasWindows { get; set; }
        public virtual bool IsIndustrial { get; set; }
        public virtual IList<Place> Places { get; set; }

    }
}
