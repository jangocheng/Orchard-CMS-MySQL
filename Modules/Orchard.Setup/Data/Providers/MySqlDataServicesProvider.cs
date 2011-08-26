using System;
using FluentNHibernate.Cfg.Db;
using Orchard.Data.Providers;
using Orchard.Environment.Extensions;

namespace Orchard.Setup.Data.Providers {
    [OrchardFeature("Orchard.MySql")]
    public class MySqlDataServicesProvider : AbstractDataServicesProvider {
        private readonly string _dataFolder;
        private readonly string _connectionString;

        public MySqlDataServicesProvider(string dataFolder, string connectionString) {
            _dataFolder = dataFolder;
            _connectionString = connectionString;
        }

        public static string ProviderName {
            get { return "MySql"; }
        }

        public override IPersistenceConfigurer GetPersistenceConfigurer(bool createDatabase) {
            var persistence = MySQLConfiguration.Standard;
            if (string.IsNullOrEmpty(_connectionString)) {
                throw new ArgumentException("The connection string is empty");
            }

            persistence = persistence.ConnectionString(_connectionString);
            return persistence;
        }
    }
}
