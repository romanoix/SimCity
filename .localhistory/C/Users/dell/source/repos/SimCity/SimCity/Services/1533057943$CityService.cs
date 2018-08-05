using SimCity.Entities;
using SimCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Services
{
    public class CityService
    {
        public static List<CityModel> GetCity()
        {

            var cityModelsList = new List<CityModel>();
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
                    var CityCreate = session.CreateCriteria(typeof(City))
                      .List<City>();

                    foreach (var cit in CityCreate)
                    {
                        var temp = new CityModel()
                        {
                            Id = cit.Id,
                            Name = cit.Name,
                            Population = cit.Population,
                            CountryModel = new CountryModel
                            {
                                Id = cit.Country.Id,
                            }
                        };

                        cityModelsList.Add(temp);
                    }

                    return cityModelsList;
                }
            }
        }
    }
}
