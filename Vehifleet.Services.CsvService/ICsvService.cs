using System.Threading.Tasks;

namespace Vehifleet.Services.CsvService
{
    public interface ICsvService
    {
        Task GenerateReports(string reportsDir, int bookingsHistoryDays = 30);
    }
}