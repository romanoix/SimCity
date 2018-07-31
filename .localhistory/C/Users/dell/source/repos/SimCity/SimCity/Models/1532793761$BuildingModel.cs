using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Models
{
    public class BuildingModel
    {
        public int Id { get; protected set; }
        public string Type { get; set; }
        public bool HasWindows { get; set; }
        public bool IsIndustrial { get; set; }
        public IList<PlaceModel> PlacesModel { get; set; }
    }
}
