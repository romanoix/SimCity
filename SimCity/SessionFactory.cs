using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimCity
{
    public static class SessionFactory
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                               .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=DESKTOP-8TM1SVS\\SQLEXPRESS;Initial Catalog=BazaDanychPawel;Integrated Security=True"))
                               .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                               .BuildSessionFactory();
        }

    }
}
