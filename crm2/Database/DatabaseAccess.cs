using crm2.Database.ModelMappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Exceptions;
using NHibernate.Tool.hbm2ddl;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace crm2.Database
{
    public class DatabaseAccess
    {
        private static object connectionLock = new object();
        private static object sessionLock = new object();
        private ISessionFactory sessionFactory;
        private static ISession session;
        private FluentConfiguration connectionConfig;
        private static DatabaseAccess instance;
        private DatabaseAccess()
        {
            SetUpConnection();
            CreateSessionFatctory();

        }

        private void SetUpConnection()
        {
            connectionConfig = Fluently.Configure()
                    .Database(PostgreSQLConfiguration.Standard.ConnectionString(
                        cs => cs.Host("localhost")
                            .Port(5432)
                            .Username("crm")
                            .Password("123456")
                            .Database("crm_main")
                             )
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersonMap>());
        }

        private void CreateSessionFatctory()
        {
            sessionFactory = connectionConfig.BuildSessionFactory();
        }

        public static DatabaseAccess GetInstance()
        {
            lock (connectionLock)
            {
                if (instance == null)
                {
                    instance = new DatabaseAccess();
                }
            }
            return instance;
        }
        public static ISession GetOpenSession()
        {
            lock(sessionLock)
            {
                if(session == null)
                {
                    session = GetInstance().sessionFactory.OpenSession();
                }
                else if(!session.IsConnected || !session.IsOpen)
                {
                    session.Reconnect();
                }
            }
            return session;
        }
        public static void UpdateSchema()
        {
            new SchemaUpdate(GetInstance().connectionConfig.BuildConfiguration()).Execute(false, true);
        }

        public static void SaveOrUpdate(object entity)
        {
            try
            {
                var session = GetOpenSession();
                session.SaveOrUpdate(entity);
                session.Flush();
            }
            catch (GenericADOException ex)
            {
                if (ex.InnerException is NpgsqlException)
                {
                    var inner = ex.InnerException as NpgsqlException;
                    MessageBox.Show(string.Format("SQL error while deleting{0}error: {1}{0}cause:{2}", Environment.NewLine, ex.Message, inner.Message));
                }
            }
        }

        public static void Delete(object entity)
        {
            try
            {
                var session = GetOpenSession();
                session.Delete(entity);
                session.Flush();
            }
            catch(GenericADOException ex)
            {
                if(ex.InnerException is NpgsqlException)
                {
                    var inner = ex.InnerException as NpgsqlException;
                    MessageBox.Show(string.Format("SQL error while deleting{0}error: {1}{0}cause:{2}", Environment.NewLine, ex.Message, inner.Message));
                }
            }
        }

        public static IEnumerable<T> GetEntitiesOfType<T>() where T:class
        {
            return GetOpenSession().CreateCriteria<T>().List<T>();
        }

        public static T GetEntity<T>(object id) where T : class
        {
            return GetOpenSession().Get<T>(id);
        }

        internal static void Persist(object entity)
        {
            try
            {
                var session = GetOpenSession();
                session.Persist(entity);
                session.Flush();
            }
            catch (GenericADOException ex)
            {
                if (ex.InnerException is NpgsqlException)
                {
                    var inner = ex.InnerException as NpgsqlException;
                    MessageBox.Show(string.Format("SQL error while deleting{0}error: {1}{0}cause:{2}", Environment.NewLine, ex.Message, inner.Message));
                }
            }
        }
    }
}
