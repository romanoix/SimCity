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
        public static List<BuildingModel> GetBuilding()
        {

            var buildingModelsList = new List<BuildingModel>();
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
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
                            
                        };

                        buildingModelsList.Add(temp);
                    }

                    return buildingModelsList;
                }
            }
        }
    }
}
