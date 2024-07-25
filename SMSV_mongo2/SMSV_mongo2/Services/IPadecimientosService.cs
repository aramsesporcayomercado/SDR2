using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public interface IPadecimientosService
    {
        Task<IEnumerable<Padecimientos>> GetPadecimientosAsync();
        Task<Padecimientos> GetById(int codigo);
        Task CreateAsync(Padecimientos padecimientos);
        Task Update(int codigo, Padecimientos padecimientos);
        Task Delete(int codigo);
    }
}
