using SimCity.Entities;
using SimCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Services
{
    public class PlaceService
    {
        public static void SavePlace()
        {
            var countryModelsList = new List<CountryModel>();
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (true)
                    {
                        var country = new Country
                        {
                            Id = 1,
                            Name = "Polska",
                            Continent = "Europa"

                        };



                        session.SaveOrUpdate(country);
                        transaction.Commit();

                    }
                }
            }
        }
        public static List<PlaceModel> GetPlace()
        {

            var placeModelsList = new List<PlaceModel>();
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var PlaceCreate = session.CreateCriteria(typeof(Place))
                      .List<Place>();

                    foreach (var pla in PlaceCreate)
                    {
                        var temp = new PlaceModel()
                        {
                            Id = pla.Id,
                            Street = pla.Street,
                            PlacePopulation = pla.PlacePopulation,
                            CityModel = new CityModel{ Id = pla.City.Id },
                            BuildingModel= new BuildingModel { Id = pla.Building.Id}                            
                        };

                        placeModelsList.Add(temp);
                    }

                    return placeModelsList;
                }
            }
        }
    }
}
