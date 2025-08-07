using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLog4net.Log4net
{



    [TestClass]
    public class TestLogger
    {
        [TestMethod]
        public void TestLog4Net() {


            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%MessageLevel";
            patternLayout.ActivateOptions();


            //create appender
            var consoleAppender = new ConsoleAppender()
            {

                Name = "ConsoleAppender",
                Layout = patternLayout,
                Threshold = Level.All

            };


            consoleAppender.ActivateOptions();
            //configuration
            BasicConfigurator.Configure(consoleAppender);

            //getInstance
            ILog Logger = LogManager.GetLogger(typeof(TestLogger));

            Logger.Debug("This is Debug Information");
            Logger.Info("This is Info Information");
            Logger.Warn("This is Warn Information");
            Logger.Error("This is Error Information");
            Logger.Fatal("This is Fatal Information");
        }
    }
}
