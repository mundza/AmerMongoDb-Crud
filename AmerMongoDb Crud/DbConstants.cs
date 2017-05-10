using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmerMongoDb_Crud
{
    public static class DbConstants
    {
        public static string ConnectionString { get; set; } = "mongodb://localhost:27017/TestModel";
        public static string DatabaseName { get; set; } = "TestModel";
    }
}
