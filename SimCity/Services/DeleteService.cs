using SimCity.Entities;
using SimCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Services
{
    public class DeleteService
    {
        public static void DeleteAllCoutry(int id)
        {

            var sessionFactory = SessionFactory.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var CityCreate = session.CreateCriteria(typeof(City)).List<City>();
                    var CountryCreate = session.CreateCriteria(typeof(Country)).List<Country>();
                    var PresidentCreate = session.CreateCriteria(typeof(President)).List<President>();
                    var PlaceCreate = session.CreateCriteria(typeof(Place)).List<Place>();
                    var BuildingCreate = session.CreateCriteria(typeof(Building)).List<Building>();


                    IEnumerable <City> ListIdCity = CityCreate.Where( x=> x.Country.Id == id);
                    
                    foreach (var c in ListIdCity)
                    {
                        IEnumerable<Place> ListaIdPlace = PlaceCreate.Where(x => x.City.Id == c.Id);
                        
                        foreach (var d in ListaIdPlace)
                        {
                            
                           foreach(var e in BuildingCreate)
                            {
                                if(d.Building.Id == e.Id)
                                {
                                    session.Delete(e);
                                }
                            }
                            session.Delete(d);
                        }

                        session.Delete(c);
                    }
                    foreach(var p in PresidentCreate)
                    {
                        if (p.Id == id)
                            session.Delete(p);
                    }
                    foreach(var e in CountryCreate)
                    {
                        if (e.Id == id)
                            session.Delete(e);
                    }

                    session.Transaction.Commit();
                }
            }
        }
        public static void SaveCity(string name, int population, int countryId, int cityId = 0)
        {
            City city;

            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (cityId != 0)
                    {
                        city = new City
                        {
                            Id = cityId,
                            Name = name,
                            Population = population,
                            Country = new Country { Id = countryId }

                        };


                    }
                    else
                    {
                        city = new City
                        {
                            Name = name,
                            Population = population,
                            Country = new Country { Id = countryId }
                        };

                    }
                    session.SaveOrUpdate(city);
                    transaction.Commit();

                }
            }
        }
        public static List<CityModel> GetCity()
        {

            var cityModelsList = new List<CityModel>();
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
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
