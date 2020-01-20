using Serilog;

namespace BL.Services
{
    public class ServiceBase
    {
        protected ILogger _logger;

        public ServiceBase(ILogger logger)
        {
            _logger = logger;
        }
    }
}