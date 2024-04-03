using System;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Claims;
using GigHub.Controllers.Api;
using Moq;
using GigHub.Core;

namespace GigHub.Tests.Controllers.Api
{
    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;

        public GigsControllerTests()
        {
            var identity = new GenericIdentity("user1@domain.com");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "user1@domain.com"));
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principle = new GenericPrincipal(identity, null);
            
            var mockUow = new Mock<IUnitOfWork>();
            _controller = new GigsController(mockUow.Object)
            {
                User = principle
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
