# AmerMongoDb-Crud
Generic Crud using MongoDb driver

Class Library for Mongo database managment. - Uses MongoDb driver.

Usage:
- Clone or download this Project.
- Change connecion string and db name in DbConstants
- Create your Model/s
- Use the repository in your project :)

Example:

    public class TestingAmerMongoDb
    {
        public readonly IRepository<Testing> _testingRepository;

        public TestingAmerMongoDb(IRepository<Testing> testingRepository)
        {
            _testingRepository = testingRepository;
        }

        public IList<Testing> GetAllTestingModelsFromDatabase()
        {
            return _testingRepository.GetAll();
        }

        public bool InsertNewTesting(Testing newTesting)
        {
            return _testingRepository.InsertOne(newTesting);
        }
    }

    public class Testing : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
