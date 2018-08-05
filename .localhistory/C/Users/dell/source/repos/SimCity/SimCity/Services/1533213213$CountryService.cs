using SimCity.Entities;
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
        public static void DeleteCountry()
        {

        }
        public static void SaveCountry(string name, string continent, int id = 0)
        {
            Country country;
            
            var sessionFactory = SessionFactory.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if(id != 0)
                    {
                        country = new Country
                        {

                            Id = id,
                            Name = name,
                            Continent = continent

                        };
                       

                    }
                    else
                    {
                        country = new Country
                        { 
                            Name = name,
                            Continent = continent
                        };
                        
                    }
                    session.SaveOrUpdate(country);
                    transaction.Commit();

                }
            }
        }
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
                            Id = con.Id,
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
