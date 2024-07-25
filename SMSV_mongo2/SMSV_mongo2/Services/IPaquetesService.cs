using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public interface IPaquetesService
    {
        Task<IEnumerable<Paquetes>> GetPaquetesAsync();
        Task<Paquetes> GetById(string codigo);
        Task CreateASync(Paquetes paquete);
        Task Update(string codigo, Paquetes paquete);
        Task Delete(string codigo);
            
    }
}
