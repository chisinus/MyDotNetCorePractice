using MongoDB.Driver;
using System.Web;

namespace MyWebApi.Services
{
    public class DatabaseService
    {
        public IEnumerable<string> TestMongoDB()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbuser:" + HttpUtility.UrlEncode("aaaaaa$A") + "@cluster0.an1no.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");

            MongoClient dbClient = new MongoClient(settings);

            List<string> result = new List<string>();
            result.Add("The list of databases on this server is: ");

            var dbList = dbClient.ListDatabases().ToList();

            foreach (var db in dbList)
            {
                result.Add(db.ToString());
            }

            return result;
        }
    }
}
