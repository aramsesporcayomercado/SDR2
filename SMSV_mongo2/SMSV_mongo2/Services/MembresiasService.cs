using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public class MembresiasService : IMembresiasService
    {
        private readonly IMongoCollection<Membresias> _membresiasCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public MembresiasService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoCliente = new MongoClient(dbSettings.Value.Server);
            var mongoDatabase = mongoCliente.GetDatabase(dbSettings.Value.Database);
            _membresiasCollection = mongoDatabase.GetCollection<Membresias>(dbSettings.Value.CollectionMembresias);
        }


        public async Task<IEnumerable<Membresias>> GetMembresiasAsync() =>
            await _membresiasCollection.Find(_ => true).ToListAsync();

        public async Task<Membresias> GetById(string codigo) =>
            await _membresiasCollection.Find(a => a.codigo == codigo).FirstOrDefaultAsync();

        public async Task CreateASync(Membresias membresia) =>
            await _membresiasCollection.InsertOneAsync(membresia);

        public async Task Update(string codigo, Membresias membresia) =>
            await _membresiasCollection.ReplaceOneAsync(a => a.codigo == codigo, membresia);

        public async Task Delete(string codigo) =>
            await _membresiasCollection.DeleteOneAsync(a => a.codigo == codigo);
    }
}
