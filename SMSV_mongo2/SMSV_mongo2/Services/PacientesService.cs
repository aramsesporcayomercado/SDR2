using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public class PacientesService : IPacientesService
    {
        private readonly IMongoCollection<Pacientes> _pacientesCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public PacientesService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoCliente = new MongoClient(dbSettings.Value.Server);
            var mongoDatabase = mongoCliente.GetDatabase(dbSettings.Value.Database);
            _pacientesCollection = mongoDatabase.GetCollection<Pacientes>(dbSettings.Value.CollectionPacientes);
        }

        public async Task<IEnumerable<Pacientes>> GetPacientesAsync() =>
            await _pacientesCollection.Find(_ => true).ToListAsync();

        public async Task<Pacientes> GetById(int numero) =>
            await _pacientesCollection.Find(a => a.numero == numero).FirstOrDefaultAsync();

        public async Task CreateASync(Pacientes paciente) =>
            await _pacientesCollection.InsertOneAsync(paciente);

        public async Task Update(int numero, Pacientes paciente) =>
            await _pacientesCollection.ReplaceOneAsync(a => a.numero == numero, paciente);

        public async Task Delete(int numero) =>
            await _pacientesCollection.DeleteOneAsync(a => a.numero == numero);
    }
}
