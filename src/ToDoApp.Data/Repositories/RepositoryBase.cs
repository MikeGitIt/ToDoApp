using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ToDoApp.Data.Repositories
{
    internal class RepositoryBase
    {
        private const string CONNECTIONSTRING_KEY = "ConnectionString";
        protected SqlConnection connection;

        public RepositoryBase(IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetSection(CONNECTIONSTRING_KEY);
            if (string.IsNullOrWhiteSpace(connectionString.Value))
            {
                throw new ArgumentException("Connection string not found or has not been provided.");
            }

            connection = new SqlConnection(connectionString.Value);
        }
    }
}
