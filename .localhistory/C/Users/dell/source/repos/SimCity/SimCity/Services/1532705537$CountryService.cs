﻿using SimCity.Entities;
using SimCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Services
{
    public static class CountryService
    {
        public static List<CountryModel> GetCountry()
        {
            var countryModelsList = new List<CountryModel>();
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var CountryCreate = session.CreateCriteria(typeof(Country))
                      .List<Country>();

                    foreach (var con in CountryCreate)
                    {
                        var temp = new CountryModel()
                        {
                            Name = con.Name,
                            Continent = con.Continent,
                        };

                        countryModelsList.Add(temp);
                    }
                    
                    return countryModelsList;
                }
            }            
        }
    }
}
