using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public interface IPacientesService
    {
        Task<IEnumerable<Pacientes>> GetPacientesAsync();
        Task<Pacientes> GetById(int numero);
        Task CreateASync(Pacientes paciente);
        Task Update(int numero, Pacientes paciente);
        Task Delete(int numero);
    }
}
