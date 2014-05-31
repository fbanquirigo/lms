using System;
using log4net;
using Moq;
using NUnit.Framework;

namespace SaG.Core.Log4Net.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        private Mock<ILog> log;
        private Logger target;
        private Exception someException;
        private object[] someError;
        private const string someFormat = "I am an {0}.";
        private const string someMsg = "Some Message.";
        
        [SetUp]
        public void Setup()
        {
            this.log = new Mock<ILog>();
            this.target = new Logger(this.log.Object);
            this.someException = new Exception("Some Exception.");
            this.someError = new object[] {"Error"};
        }

        [Test]
        public void TestDebug()
        {
            this.target.Debug(someMsg);   
            this.log.Verify(x => x.Debug(someMsg));
        }

        [Test]
        public void TestInfo()
        {
            this.target.Info(someMsg);
            this.log.Verify(x => x.Info(someMsg));
        }

        [Test]
        public void TestWarn()
        {
            this.target.Warn(someMsg);
            this.log.Verify(x => x.Warn(someMsg));
        }

        [Test]
        public void TestError()
        {
            this.target.Error(someMsg);
            this.log.Verify(x => x.Error(someMsg));
        }

        [Test]
        public void TestFatal()
        {
            this.target.Fatal(someMsg);
            this.log.Verify(x => x.Fatal(someMsg));
        }

        [Test]
        public void TestDebugException()
        {
            this.target.Debug(someMsg, someException);
            this.log.Verify(x => x.Debug(someMsg, this.someException));
        }

        [Test]
        public void TestInfoException()
        {
            this.target.Info(someMsg, someException);
            this.log.Verify(x => x.Info(someMsg, this.someException));
        }

        [Test]
        public void TestWarnException()
        {
            this.target.Warn(someMsg, someException);
            this.log.Verify(x => x.Warn(someMsg, this.someException));
        }

        [Test]
        public void TestErrorException()
        {
            this.target.Error(someMsg, someException);
            this.log.Verify(x => x.Error(someMsg, this.someException));
        }

        [Test]
        public void TestFatalException()
        {
            this.target.Fatal(someMsg, someException);
            this.log.Verify(x => x.Fatal(someMsg, this.someException));
        }

        [Test]
        public void TestDebugFormat()
        {
            this.target.DebugFormat(someFormat, this.someError);
            this.log.Verify(x => x.DebugFormat(someFormat, this.someError));
        }

        [Test]
        public void TestInfoFormat()
        {
            this.target.InfoFormat(someFormat, this.someError);
            this.log.Verify(x => x.InfoFormat(someFormat, this.someError));
        }

        [Test]
        public void TestWarnFormat()
        {
            this.target.WarnFormat(someFormat, this.someError);
            this.log.Verify(x => x.WarnFormat(someFormat, this.someError));
        }

        [Test]
        public void TestErrorFormat()
        {
            this.target.ErrorFormat(someFormat, this.someError);
            this.log.Verify(x => x.ErrorFormat(someFormat, this.someError));
        }

        [Test]
        public void TestFatalFormat()
        {
            this.target.FatalFormat(someFormat, this.someError);
            this.log.Verify(x => x.FatalFormat(someFormat, this.someError));
        }

    }
}
