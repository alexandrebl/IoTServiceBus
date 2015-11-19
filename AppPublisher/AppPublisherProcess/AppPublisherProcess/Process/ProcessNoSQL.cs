using AppPublisherProcess.Process.Interface;
using AppPublisherProcess.Utility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace AppPublisherProcess.Process {

    //mongod --port 27017 --dbpath  C:\IoT\Code\NoSQL\Db
    public class ProcessNoSQL : IProcessNoSQL {

        private IConfigurationUtility ConfigurationUtility { get; set; }
        public ProcessNoSQL(IConfigurationUtility configurationUtility) {
            this.ConfigurationUtility = configurationUtility;
        }
        public void SendDocument(string document) {
            var _client = new MongoClient(this.ConfigurationUtility.NoSQLConnection);

            var _database = _client.GetDatabase(this.ConfigurationUtility.NoSQLDataBase);

            var collection = _database.GetCollection<BsonDocument>(this.ConfigurationUtility.NoSQLCollection);


            BsonDocument data = BsonDocument.Parse(document);

            collection.InsertOneAsync(data).Wait();
        }
    }
}
