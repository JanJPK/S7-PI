using System.Threading.Tasks;

namespace Vehifleet.Services.CsvService
{
    public interface ICsvService
    {
        Task GenerateReports(int bookingsHistoryDays = 30);
    }
}