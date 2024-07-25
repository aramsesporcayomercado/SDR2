using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public interface IMembresiasService
    {
       Task<IEnumerable<Membresias>> GetMembresiasAsync();


        Task<Membresias> GetById(string codigo);


      Task CreateASync(Membresias membresia);


        Task Update(string codigo, Membresias membresia);


        Task Delete(string codigo);

    }
}
