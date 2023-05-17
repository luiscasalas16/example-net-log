using Microsoft.Extensions.Logging;
using net_log_library_microsoft_utilities;

namespace net_log_library_microsoft_example
{
    public class ParameterizedComponent
    {
        private ILogger<ParameterizedComponent> logger;

        public ParameterizedComponent()
        {
            logger = ParameterizedFactoryLogger.Instance.CreateLogger<ParameterizedComponent>();
        }

        public void Execute()
        {
            logger.LogCritical("ParameterizedComponent logging critical.");
            logger.LogError("ParameterizedComponent logging error.");
            logger.LogWarning("ParameterizedComponent logging warning.");
            logger.LogInformation("ParameterizedComponent logging information.");
            logger.LogDebug("ParameterizedComponent logging debug.");
            logger.LogTrace("ParameterizedComponent logging trace.");
        }
    }
}