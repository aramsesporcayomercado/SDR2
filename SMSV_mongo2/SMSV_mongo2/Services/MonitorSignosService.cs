using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public class MonitorSignosService : IMonitorSignosService
    {
        private readonly IMongoCollection<MonitorSignos> _MonitorCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public MonitorSignosService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.Server);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.Database);
            _MonitorCollection = mongoDatabase.GetCollection<MonitorSignos>(dbSettings.Value.CollectionMonitorSignos);
        }
        public async Task<IEnumerable<MonitorSignos>> GetMonitorAsync() =>
        await _MonitorCollection.Find(_ => true).ToListAsync();

        public async Task<MonitorSignos> GetById(int codigo) =>
            await _MonitorCollection.Find(a => a.codigo == codigo).FirstOrDefaultAsync();

        public async Task CreateAsync(MonitorSignos monitorSignos) =>
            await _MonitorCollection.InsertOneAsync(monitorSignos);

        public async Task Update(int codigo, MonitorSignos monitorSignos) =>
            await _MonitorCollection.ReplaceOneAsync(a => a.codigo == codigo, monitorSignos);

        public async Task DeleteAsync(int codigo) =>
            await _MonitorCollection.DeleteOneAsync(a => a.codigo == codigo);
    }
}
