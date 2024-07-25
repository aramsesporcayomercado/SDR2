using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SMSV_mongo2.Models;
namespace SMSV_mongo2.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IMongoCollection<Clientes> _clientesCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ClientesService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoCliente = new MongoClient(dbSettings.Value.Server);
            var mongoDatabase = mongoCliente.GetDatabase(dbSettings.Value.Database);
            _clientesCollection = mongoDatabase.GetCollection<Clientes>(dbSettings.Value.CollectionClientes);
        }
        public async Task<IEnumerable<Clientes>> GetClientesAsync() =>
               await _clientesCollection.Find(_ => true).ToListAsync();

        public async Task<Clientes> GetById(int numero) =>
            await _clientesCollection.Find(a => a.numero == numero).FirstOrDefaultAsync();

        public async Task CreateASync(Clientes cliente) =>
            await _clientesCollection.InsertOneAsync(cliente);

        public async Task Update(int numero, Clientes cliente) =>
            await _clientesCollection.ReplaceOneAsync(a => a.numero == numero, cliente);

        public async Task Delete(int numero) =>
            await _clientesCollection.DeleteOneAsync(a => a.numero == numero);

    }
}
