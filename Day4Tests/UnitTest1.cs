using System.Linq;
using Day4;
using NUnit.Framework;

namespace Day4Tests
{
    public class PasswordFinderTests
    {
        
        [Test]
        public void FindViablePasswordShouldReturnGoodPasswords()
        {
            var pf = new PasswordFinder(110033, 123444);
            var passwords = pf.FindViablePasswords().ToList();

            Assert.That(passwords,Has.Member(112233));
            Assert.That(passwords, Has.No.Member(123444));
            Assert.That(passwords, Does.Contain(111122));
        }
    }
}