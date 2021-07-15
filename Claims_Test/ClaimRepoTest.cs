using Claims_Models;
using Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Claims_Test
{
    [TestClass]
    public class ClaimRepoTest
    {
        [TestMethod]
        public void Create_ClaimIsDefault_ReturnFalse ()
        {
            ClaimRepository _claimRepo = new ClaimRepository();
            Claim claim = default;
            bool result = _claimRepo.Create(claim);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Create_ClaimExists_ReturnTrue()
        {
            ClaimRepository _claimRepo = new ClaimRepository();
            Claim exampleClaim = new Claim(1, ClaimType.Theft, "Stole their stereo", 500.00, new DateTime(2021, 3, 1), new DateTime(2021, 3, 10), true);
            bool result = _claimRepo.Create(exampleClaim);


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete_ClaimIsNull_ReturnFalse()
        {
            ClaimRepository _claimRepo = new ClaimRepository();
            bool result = _claimRepo.Delete();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Delete_ClaimIsNull_ReturnTrue()
        {
            ClaimRepository _claimRepo = new ClaimRepository();
            Claim exampleClaim = new Claim(1, ClaimType.Theft, "Stole their stereo", 500.00, new DateTime(2021, 3, 1), new DateTime(2021, 3, 10), true);
            _claimRepo.Create(exampleClaim);

            bool result = _claimRepo.Delete();
            Assert.IsTrue(result);
        }
    }
}
