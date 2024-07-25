using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public interface IClientesService
    {
        Task<IEnumerable<Clientes>> GetClientesAsync();
        Task<Clientes> GetById(int numero);
        Task CreateASync(Clientes cliente);
        Task Update(int numero, Clientes cliente);
        Task Delete(int numero);
    }
}
