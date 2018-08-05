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
        public static void DeleteBuilding(int id)
        {
            var sessionFactory = SessionFactory.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var BuildingCreate = session.CreateCriteria(typeof(Building))
                      .List<Building>();

                    foreach (var con in BuildingCreate)
                    {
                        if (con.Id == id)
                            session.Delete(con);
                    }
                    session.Transaction.Commit();
                }
            }
        }
        public static void SaveBuilding(string type, bool hasWindows, bool isIndustrial, int id =0)
        {
            Building building;            
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (id != 0)
                    {
                        building = new Building
                        {
                            Id = id,
                            Type= type,
                            HasWindows = hasWindows,
                            IsIndustrial = isIndustrial
                        };

                    }
                    else
                    {
                        building = new Building
                        { 
                            Type = type,
                            HasWindows = hasWindows,
                            IsIndustrial = isIndustrial
                        };
                    }
                    session.SaveOrUpdate(building);
                    transaction.Commit();

                }
            }
        }
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
