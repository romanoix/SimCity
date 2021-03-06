﻿using FluentNHibernate.Mapping;
using SimCity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Mappings
{
    public class PresidentMap : ClassMap<President>
    {
        public PresidentMap()
        {
            Table("President");

            Id(x => x.Id, "Id").GeneratedBy.Assigned();
            Map(x => x.Name, "Name");
            Map(x => x.Age, "Age");

            References(x => x.Country, "Id").Unique();
        }
    }
}
