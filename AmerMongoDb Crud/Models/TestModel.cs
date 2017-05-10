using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmerMongoDb_Crud.Models
{
    public class TestModel : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
