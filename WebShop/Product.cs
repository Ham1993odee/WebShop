using MongoDB.Driver;
using MongoDB.Bson;

namespace WebShop
{
    internal class Product : IProduct
    {
        MongoClient dbClient;
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;
        public Product(string connectionString, string database)
        {
            this.dbClient = new MongoClient(connectionString);
            this.database = dbClient.GetDatabase(database);
            collection = this.database.GetCollection<BsonDocument>("Products");
        }

        public void CreateProduct(int id, string? name, double price)
        {

            var document = new BsonDocument
            {
                { "id", id },
                { "name", name },
                { "price", price }
            };

            collection.InsertOne(document);
        }

        public bool DeleteProduct(int id)
        {

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("id", id);
            DeleteResult b = collection.DeleteOne(deleteFilter);

            if (b.DeletedCount != 0) return true;

            return false;
        }

        public CollectionProduct FindProduct(string? name)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("name", name);

            var document = collection.Find(filter).FirstOrDefault();

            if (document != null)
            {
                return new CollectionProduct(document[1].ToInt32(), document[2].ToString(), document[3].ToDouble());
            }
            return null;
        }

        public List<CollectionProduct> GetAllProducts()
        {

            var documents = collection.Find(new BsonDocument()).ToList();

            var result = new List<CollectionProduct>();

            foreach (var document in documents)
            {
                result.Add(new CollectionProduct(document[1].ToInt32(), document[2].ToString(), document[3].ToDouble()));
            }

            return result;
        }

        public bool UpdateProduct(int id, string? name, double price)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            var update = Builders<BsonDocument>.Update.Set("name", name).Set("price", price);
            UpdateResult u = collection.UpdateOne(filter, update);

            if (u.ModifiedCount != 0) return true;

            return false;
        }
    }
}
