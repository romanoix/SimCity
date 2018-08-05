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
        public static List<CountryModel> UpDataCountry(int id = 0, bool save = false, bool delete = false)
        {
            
            var countryModelsList = new List<CountryModel>();
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (save)
                    {
                        var country = new Country
                        {
                            Id = 1,
                            Name = "Polska"
                        };



                        session.SaveOrUpdate(country);
                        transaction.Commit();

                    }
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
