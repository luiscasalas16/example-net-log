using Microsoft.Extensions.Logging;
using net_log_library_microsoft_utilities;

namespace net_log_library_microsoft_example
{
    public class GenericComponent
    {
        private ILogger<GenericComponent> logger;

        public GenericComponent()
        {
            logger = GenericFactoryLogger.Instance.CreateLogger<GenericComponent>();
        }

        public void Execute()
        {
            logger.LogCritical("GenericComponent logging critical.");
            logger.LogError("GenericComponent logging error.");
            logger.LogWarning("GenericComponent logging warning.");
            logger.LogInformation("GenericComponent logging information.");
            logger.LogDebug("GenericComponent logging debug.");
            logger.LogTrace("GenericComponent logging trace.");

            GenericUtilities.Utility1();

            GenericUtilities.Utility2();
        }
    }
}