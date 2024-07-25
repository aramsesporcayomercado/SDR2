using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SMSV_mongo2.Models;
namespace SMSV_mongo2.Services
{
    public class PadecimientosService : IPadecimientosService
    {
        private readonly IMongoCollection<Padecimientos> _padecimientosCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public PadecimientosService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoCliente = new MongoClient(dbSettings.Value.Server);
            var mongoDatabase = mongoCliente.GetDatabase(dbSettings.Value.Database);
            _padecimientosCollection = mongoDatabase.GetCollection<Padecimientos>(dbSettings.Value.CollectionPadecimientos);
        }
        public async Task<IEnumerable<Padecimientos>> GetPadecimientosAsync() =>
               await _padecimientosCollection.Find(_ => true).ToListAsync();

        public async Task<Padecimientos> GetById(int codigo) =>
            await _padecimientosCollection.Find(a => a.codigo == codigo).FirstOrDefaultAsync();

        public async Task CreateAsync(Padecimientos padecimientos) =>
            await _padecimientosCollection.InsertOneAsync(padecimientos);

        public async Task Update(int codigo, Padecimientos padecimientos) =>
            await _padecimientosCollection.ReplaceOneAsync(a => a.codigo == codigo, padecimientos);

        public async Task Delete(int codigo) =>
            await _padecimientosCollection.DeleteOneAsync(a => a.codigo == codigo);

    }
}
