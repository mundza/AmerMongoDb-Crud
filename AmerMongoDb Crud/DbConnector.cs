using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace AmerMongoDb_Crud
{
    public static class DbConnector
    {
        static IMongoClient client = new MongoClient(DbConstants.ConnectionString);
        public static IMongoDatabase Database = client.GetDatabase(DbConstants.DatabaseName);
    }
}
