using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public interface IMonitorSignosService
    {
        Task<IEnumerable<MonitorSignos>> GetMonitorAsync();
        Task<MonitorSignos> GetById(int codigo);
        Task CreateAsync(MonitorSignos monitorSignos);
        Task Update(int codigo, MonitorSignos monitorSignos);
        Task DeleteAsync(int codigo);
    }
}
