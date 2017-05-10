using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmerMongoDb_Crud
{
    public interface IRepository<T>
    {
        T GetById(string id);
        IList<T> GetAll();
        IList<T> GetByProperty(string propertyName, object propertyValue);
        bool InsertMany(List<T> data);
        bool InsertOne(T data);
        bool Delete(string id);
        bool UpdateOne(T data);
    }
}
