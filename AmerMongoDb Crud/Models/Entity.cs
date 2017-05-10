using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmerMongoDb_Crud.Models
{
    public class Entity
    {
        public string _id { get; set; } = Guid.NewGuid().ToString();
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
