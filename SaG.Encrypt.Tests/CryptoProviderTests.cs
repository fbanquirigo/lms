using NUnit.Framework;

namespace SaG.Encrypt.Tests
{
    [TestFixture]
    public class CryptoProviderTests
    {
        private ConsoleCryptoProvider target;

        [SetUp]
        public void Setup()
        {
            this.target = new ConsoleCryptoProvider();    
        }

        [Test]
        public void TestEncryptDecryptPassword()
        {
            const string valueToEncrypt = "password";
            string encryptedResult = this.target.EncryptDBValue(valueToEncrypt, 8); 
            string decryptedResult = this.target.DecryptDBValue(encryptedResult, 8);
            Assert.That(decryptedResult, Is.EqualTo(valueToEncrypt));   
        }

        [TearDown]
        public void TearDown()
        {
            this.target = null;
        }
    }
}
