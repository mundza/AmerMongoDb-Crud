using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmerMongoDb_Crud.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace AmerMongoDb_Crud
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly IMongoDatabase _db = DbConnector.Database;

        public IList<T> GetAll()
        {
            try
            {
                return
                    _db.GetCollection<T>(typeof(T).Name)
                        .AsQueryable()
                        .ToList();
            }
            catch (Exception e)
            {
                return new List<T>();
            }

        }

        public IList<T> GetByProperty(string propertyName, object propertyValue)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq(propertyName, propertyValue);
                var collection = _db.GetCollection<BsonDocument>(typeof(T).Name);
                var bsonDocuments = collection.Find(filter).ToList();
                return bsonDocuments.Select(bson => BsonSerializer.Deserialize<T>(bson)).ToList();
            }
            catch (Exception e)
            {
                return new List<T>();
            }

        }

        public T GetById(string id)
        {
            try
            {
                return GetCollectionAsQueryable().FirstOrDefault(i => i._id == id);
            }
            catch (Exception e)
            {
                return new T();
            }
        }

        public bool InsertMany(List<T> data)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);

            try
            {
                collection.InsertMany(data);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool InsertOne(T data)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);

            try
            {
                collection.InsertOne(data);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);

            try
            {
                var filter = Builders<T>.Filter.Eq("_id", id);

                collection.DeleteOne(filter);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //For developer use only - It will delete the whole table
        public bool DeleteAll()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);

            try
            {
                var filter = Builders<T>.Filter.Empty;

                collection.DeleteMany(filter);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool UpdateOne(T data)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", data._id);


                var collection = _db.GetCollection<BsonDocument>(typeof(T).Name);

                var dataBson = data.ToBsonDocument();

                var update = Builders<BsonDocument>.Update.CurrentDate("TimeStamp");

                collection.ReplaceOne(filter, dataBson);
                collection.UpdateOne(filter, update);


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal IQueryable<T> GetCollectionAsQueryable()
        {
            return _db.GetCollection<T>(typeof(T).Name).AsQueryable();
        }
    }
}
