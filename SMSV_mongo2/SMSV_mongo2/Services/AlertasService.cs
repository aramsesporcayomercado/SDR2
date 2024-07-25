using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public class AlertasService : IAlertasService
    {
        private readonly IMongoCollection<Alertas> _alertaCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public AlertasService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoCliente = new MongoClient(dbSettings.Value.Server);
            var mongoDatabase = mongoCliente.GetDatabase(dbSettings.Value.Database);
            _alertaCollection = mongoDatabase.GetCollection<Alertas>(dbSettings.Value.CollectionAlertas);
        }

        //public async Task<IEnumerable<Alertas>> GetAlertasAsync()
        //{
        //    var alertas = _alertaCollection.Find(_=> true).ToListAsync();
        //    return alertas;
        //}

        public async Task<IEnumerable<Alertas>> GetAlertasAsync()=>
            await _alertaCollection.Find(_ => true).ToListAsync();

        public async Task<Alertas> GetById(string codigo) =>
            await _alertaCollection.Find(a => a.codigo == codigo).FirstOrDefaultAsync();
        
        public async Task CreateASync(Alertas alerta)=>
            await _alertaCollection.InsertOneAsync(alerta);

        public async Task Update(string codigo ,Alertas alerta) =>
            await _alertaCollection.ReplaceOneAsync(a => a.codigo == codigo, alerta);

        public async Task Delete(string codigo) =>
            await _alertaCollection.DeleteOneAsync(a => a.codigo==codigo);

    }
}
    