using SimCity.Entities;
using SimCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Services
{
    public class BuildingService
    {
        public static List<BuildingModel> UpDataBuilding(int id = 0, bool save = false, bool delete = false)
        {

            var buildingModelsList = new List<BuildingModel>();
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
                    var BuildingCreate = session.CreateCriteria(typeof(Building))
                      .List<Building>();

                    foreach (var bui in BuildingCreate)
                    {
                        var temp = new BuildingModel()
                        {
                            Id = bui.Id,
                            Type = bui.Type,
                            HasWindows = bui.HasWindows,
                            IsIndustrial = bui.IsIndustrial,
                            InfoWindows = bui.InfoWindows(),
                            InfoIndustrial = bui.InfoIndustrial()

                        };

                        buildingModelsList.Add(temp);
                    }

                    return buildingModelsList;
                }
            }
        }
    }
}
