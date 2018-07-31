using FluentNHibernate.Mapping;
using SimCity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Mappings
{
    public class PlaceMap : ClassMap<Place>
    {
        public PlaceMap()
        {
            Table("Place");

            Id(x => x.Id, "Id").GeneratedBy.Native();
            Map(x => x.Street, "Street");
            Map(x => x.PlacePopulation, "PlacePopulation");

            References(x => x.City, "IdCity");
            References(x => x.Building, "IdBuilding");
        }
    }
}
