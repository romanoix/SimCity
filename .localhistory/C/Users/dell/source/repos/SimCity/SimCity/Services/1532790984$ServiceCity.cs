using SimCity.Entities;
using SimCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Services
{
    public class ServiceCity
    {
        public static List<CityModel> GetPresident()
        {

            var presidentModelsList = new List<CityModel>();
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var CityCreate = session.CreateCriteria(typeof(City))
                      .List<City>();

                    foreach (var cit in CityCreate)
                    {
                        var temp = new PresidentModel()
                        {
                            Id = cit.Id,
                            Name = cit.Name,
                            Age = cit.Age,
                        };

                        presidentModelsList.Add(temp);
                    }

                    return presidentModelsList;
                }
            }
        }
    }
}
