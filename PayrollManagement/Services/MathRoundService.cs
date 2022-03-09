using Microsoft.Extensions.Logging;
using System;

namespace PayrollManagement.Services
{
    public class MathRoundService : IMathRoundService
    {
        private readonly ILogger<MathRoundService> _log;

        public MathRoundService(ILogger<MathRoundService> log)
        {
            _log = log;
        }
        public int Round(double amount)
        {
            int result = (int)Math.Round(amount, MidpointRounding.AwayFromZero);

            return result;
        }
    }
}
