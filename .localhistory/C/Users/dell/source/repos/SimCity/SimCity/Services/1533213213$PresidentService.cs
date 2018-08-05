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
        public static void DeletePresident()
        {
            var sessionFactory = SessionFactory.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var PresidentCreate = session.CreateCriteria(typeof(President))
                      .List<President>();

                    foreach (var con in PresidentCreate)
                    {
                        if (con.Id == 2)
                            session.Delete(con);                        
                    }
                    session.Transaction.Commit();
                }
            }
        }
        public static void SavePresident(string name, int age, int id)
        {
            President president;

            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    president = new President
                    {
                        Name = name,
                        Age = age,
                        Country= new Country() { Id=id}

                    };


                    session.SaveOrUpdate(president);
                    transaction.Commit();

                }
            }
        }

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

