using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectNoSql.Controllers;

namespace ProjectNoSql.Context
{
    public class ObjContext
    {
        public IConfigurationRoot Configuration { get; }
        private IMongoDatabase _database = null;

        //Construtor monta conneccao
        public ObjContext(IOptions<Settings> setting)
        {
            Configuration = setting.Value.iConfigurationRoot;
            setting.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            setting.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(setting.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(setting.Value.Database);
            }
        }
        public IMongoCollection<Student> Students
        {
            get
            {
                return _database.GetCollection<Student>("Students");
            }
        }
    }
}


