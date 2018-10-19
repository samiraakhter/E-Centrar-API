using log4net;
using System;
using System.Reflection;
using System.Xml;
using log4net.Config;

namespace ServiceLayer.Utils
{
    public class Logger
    {
        private readonly static ILog logger = log4net.LogManager.GetLogger(typeof(Logger));
        public static void Debug(string msg)
        {
            logger.Debug(msg);
        }
        public static void Error(string msg)
        {
            logger.Error(msg);
        }
        public static void Warn(string msg)
        {
            logger.Warn(msg);
        }
        public static void Info(string msg)
        {
            logger.Info(msg);
        }
        public static void Setup()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.log4net);

            XmlConfigurator.Configure(logRepository, doc.DocumentElement);
        }
    }
}
