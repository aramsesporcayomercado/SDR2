using SMSV_mongo2.Models;

namespace SMSV_mongo2.Services
{
    public interface IReporteFallasService
    {
        Task<IEnumerable<ReporteFallas>> GetAllAsyc();
        Task<ReporteFallas> GetById(int numero);

        Task CreatAsync(ReporteFallas reporteFallas);

        Task Update(int numero, ReporteFallas reporteFallas);

        Task DeleteAsync(int numero);
    }
}