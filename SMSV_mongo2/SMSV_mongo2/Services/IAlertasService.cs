using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public interface IAlertasService
    {
        Task<IEnumerable<Alertas>> GetAlertasAsync();
        Task<Alertas> GetById(string codigo);
        Task CreateASync(Alertas alerta);
        Task Update(string codigo, Alertas alerta);
        Task Delete(string codigo);
    }
}