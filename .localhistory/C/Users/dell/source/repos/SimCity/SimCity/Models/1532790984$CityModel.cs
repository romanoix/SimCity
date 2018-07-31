using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Models
{
    public class CityModel
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public CountryModel CountryModel { get; set; }
        public IList<PlaceModel> PlacesModel { get; set; }
    }
}
