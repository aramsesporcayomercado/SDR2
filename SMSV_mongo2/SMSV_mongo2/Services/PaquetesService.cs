using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public class PaquetesService : IPaquetesService
    {
        private readonly IMongoCollection<Paquetes> _paquetesCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public PaquetesService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoCliente = new MongoClient(dbSettings.Value.Server);
            var mongoDatabase = mongoCliente.GetDatabase(dbSettings.Value.Database);
            _paquetesCollection = mongoDatabase.GetCollection<Paquetes>(dbSettings.Value.CollectionPaquetes);
        }

        public async Task<IEnumerable<Paquetes>> GetPaquetesAsync() =>
            await _paquetesCollection.Find(_ => true).ToListAsync();

        public async Task<Paquetes> GetById(string codigo) =>
            await _paquetesCollection.Find(a => a.codigo == codigo).FirstOrDefaultAsync();

        public async Task CreateASync(Paquetes paquete) =>
            await _paquetesCollection.InsertOneAsync(paquete);

        public async Task Update(string codigo, Paquetes paquete) =>
            await _paquetesCollection.ReplaceOneAsync(a => a.codigo == codigo, paquete);

        public async Task Delete(string codigo) =>
            await _paquetesCollection.DeleteOneAsync(a => a.codigo == codigo);
    }
}
