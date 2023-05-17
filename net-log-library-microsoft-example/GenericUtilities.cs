using Microsoft.Extensions.Logging;
using net_log_library_microsoft_utilities;

namespace net_log_library_microsoft_example
{
    public class GenericUtilities
    {
        public static void Utility1()
        {
            ILogger<GenericUtilities> logger = GenericFactoryLogger.Instance.CreateLogger<GenericUtilities>();

            logger.LogCritical("GenericUtilities-Utility1 logging critical.");
            logger.LogError("GenericUtilities-Utility1 logging error.");
            logger.LogWarning("GenericUtilities-Utility1 logging warning.");
            logger.LogInformation("GenericUtilities-Utility1 logging information.");
            logger.LogDebug("GenericUtilities-Utility1 logging debug.");
            logger.LogTrace("GenericUtilities-Utility1 logging trace.");
        }
        
        public static void Utility2()
        {
            ILogger<GenericUtilities> logger = GenericFactoryLogger.Instance.CreateLogger<GenericUtilities>();

            logger.LogCritical("GenericUtilities-Utility2 logging critical.");
            logger.LogError("GenericUtilities-Utility2 logging error.");
            logger.LogWarning("GenericUtilities-Utility2 logging warning.");
            logger.LogInformation("GenericUtilities-Utility2 logging information.");
            logger.LogDebug("GenericUtilities-Utility2 logging debug.");
            logger.LogTrace("GenericUtilities-Utility2 logging trace.");
        }
    }
}