using FluentNHibernate.Mapping;
using SimCity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Mappings
{
    public class BuildingMap : ClassMap<Building>
    {
        public BuildingMap()
        {
            Table("Building");

            Id(x => x.Id, "Id").GeneratedBy.Native();
            Map(x => x.Type);
            Map(x => x.HasWindows, "HasWindows");
            Map(x => x.IsIndustrial, "IsIndustrial");

            HasMany(x => x.Places);
        }
    }
}
