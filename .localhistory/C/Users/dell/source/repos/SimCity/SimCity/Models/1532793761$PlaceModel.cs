using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Models
{
    public class PlaceModel
    {
        public virtual int Id { get; protected set; }
        public virtual string Street { get; set; }
        public virtual int PlacePopulation { get; set; }
        public virtual CityModel CityModel { get; set; }
        public virtual BuildingModel BuildingModel { get; set; }
    }
}
