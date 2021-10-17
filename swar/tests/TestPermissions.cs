using configs;
using dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class TestPermissions
    {
        [TestMethod]
        public void TestWriteFileHasAuthority()
        {
            Permissions acl = new Permissions();
            acl.SetACLMode(FeaturesUnlocked.PREMIUM);
            
            bool authority = acl.HasAuthority(PermissionsList.SAVE_XPTS);

            Assert.IsTrue(authority);
        }

        [TestMethod]
        public void TestWriteFileHasNoAuthority()
        {
            Permissions acl = new Permissions();
            acl.SetACLMode(FeaturesUnlocked.DEMO);

            bool authority = acl.HasAuthority(PermissionsList.SAVE_XPTS);

            Assert.IsFalse(authority);
        }
    }
}
