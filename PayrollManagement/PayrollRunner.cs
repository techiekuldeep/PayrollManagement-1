using Microsoft.Extensions.Logging;
using PayrollManagement.Services;
using System.Threading.Tasks;

namespace PayrollManagement
{
    public class PayrollRunner
    {
        private readonly ILogger<PayrollRunner> _log;
        private readonly ICsvReaderWriterService _csvReaderWriterService;
        public PayrollRunner(ILogger<PayrollRunner> log, ICsvReaderWriterService csvReaderWriterService)
        {
            _log = log;
            _csvReaderWriterService = csvReaderWriterService;
        }
        public async Task Run()
        {
            //logging test, it will neeed a reference to config
            //for (int i = 0; i < _config.GetValue<int>("LoopTimes"); i++)
            //{
            //    _log.LogError("Run number {runNumber}", i);
            //}
            var employeeList = await _csvReaderWriterService.ReadCsvFileToEmployeeModel();
            await _csvReaderWriterService.WriteNewCsvFile(employeeList);
        }
    }
}
