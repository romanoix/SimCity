using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Models
{
    public class PresidentModel
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual CountryModel CountryModel { get; set; }

    }
}
