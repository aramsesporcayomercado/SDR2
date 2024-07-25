using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public class ReporteFallasService : IReporteFallasService
    {
        private readonly IMongoCollection<ReporteFallas> _reporteCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ReporteFallasService(IOptions <DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.Server);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.Database);
            _reporteCollection = mongoDatabase.GetCollection<ReporteFallas>(dbSettings.Value.CollectionReporteFallas);
        }
        public async Task<IEnumerable<ReporteFallas>> GetAllAsyc()=>
        await _reporteCollection.Find(_=> true).ToListAsync();

        public async Task<ReporteFallas> GetById(int numero) =>
            await _reporteCollection.Find(a => a.numero == numero).FirstOrDefaultAsync();

        public async Task CreatAsync(ReporteFallas reporteFallas)=>
            await _reporteCollection.InsertOneAsync(reporteFallas);

        public async Task Update(int numero, ReporteFallas reporteFallas) =>
            await _reporteCollection.ReplaceOneAsync(a => a.numero == numero, reporteFallas);

        public async Task DeleteAsync(int numero) =>
            await _reporteCollection.DeleteOneAsync(a => a.numero == numero);
    }
}
