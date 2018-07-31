using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public PresidentModel PresidentModel { get; set; }
        public IList<CityModel> CitiesModel { get; set; }
    }
}
