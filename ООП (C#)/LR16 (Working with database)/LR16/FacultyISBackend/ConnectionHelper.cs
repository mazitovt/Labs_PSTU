using System;
using System.Configuration;

namespace FacultyISBackend
{
    public static class ConnectionHelper
    {
        public static string GetConnectionString(string conName)
        {
            return ConfigurationManager.ConnectionStrings[conName].ConnectionString;
        }
    }
}