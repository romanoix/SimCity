using FluentNHibernate.Mapping;
using SimCity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Mappings
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Table("City");

            Id(x => x.Id, "Id").GeneratedBy.Native();
            Map(x => x.Name, "Name");
            Map(x => x.Population, "Population");

            HasMany(x => x.Places).Inverse().Cascade.All();
            References(x => x.Country, "IdCountry");

        }
    }
}
