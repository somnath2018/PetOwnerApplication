namespace PetOwnerApplication.Utilities
{
    using System;
    using NLog;

    public class Logging
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void AuditLog(string message)
        {
            logger.Info(message);
        }

        public static void HandleException(Exception exception)
        {
            // log exception here..
            logger.Error(exception.InnerException + ":" + exception.StackTrace);
        }

        public static void LogError(string message)
        {
            logger.Error(message);
        }
        public static void LogAudit(string userName, string ipAddress, string areaAccessed, string message)
        {
            logger.Info(Guid.NewGuid().ToString() + ":" + ipAddress + ":" + areaAccessed + ":" + message);
        }
    }
}
