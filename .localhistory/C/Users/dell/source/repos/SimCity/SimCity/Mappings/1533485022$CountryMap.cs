using FluentNHibernate.Mapping;
using SimCity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Mappings
{
    class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Table("Country");

            Id(x => x.Id, "Id").GeneratedBy.Native();
            Map(x => x.Name, "Name");
            Map(x => x.Continent, "Continent");

            HasOne(x => x.President).Cascade.All();
            HasMany(x => x.Cities).Inverse().Cascade.All();
        }
    }
}
