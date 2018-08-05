using SimCity.Entities;
using SimCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Services
{
    public class PresidentService
    {
        public static List<PresidentModel> GetPresident()
        {

            var presidentModelsList = new List<PresidentModel>();
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var PresidentCreate = session.CreateCriteria(typeof(President))
                      .List<President>();

                    foreach (var con in PresidentCreate)
                    {
                        var temp = new PresidentModel()
                        {
                            Id = con.Id,
                            Name = con.Name,
                            Age = con.Age,
                        };

                        presidentModelsList.Add(temp);
                    }

                    return presidentModelsList;
                }
            }
        }
    }
}
