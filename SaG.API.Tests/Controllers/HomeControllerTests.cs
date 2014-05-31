using System.Web.Mvc;
using NUnit.Framework;
using SaG.API.Controllers;

namespace SaG.API.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController target;

        [SetUp]
        public void Setup()
        {
            this.target = new HomeController();
        }

        [Test]
        public void TestIndex()
        {
            ViewResult result = this.target.Index();
            Assert.That(result, Is.Not.Null);
        }
    }
}
