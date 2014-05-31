using System.Reflection;
using NUnit.Framework;

namespace SaG.Services.Tests
{
    [TestFixture]
    public class SystemInformationServiceTests
    {
        private SystemInformationService target;

        [SetUp]
        public void Setup()
        {
            this.target = new SystemInformationService();
        }

        [Test]
        public void TestGetSystemVersion()
        {
            string result = this.target.GetSystemVersion();
            string expected = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestGetProductName()
        {
            string result = this.target.GetProductName();
            const string expected = "Sargent and Greenleaf Lock Management API";
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
