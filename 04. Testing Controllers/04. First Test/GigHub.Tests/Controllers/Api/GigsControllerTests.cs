using System.Web.Http.Results;
using FluentAssertions;
using GigHub.Controllers.Api;
using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GigHub.Tests.Controllers.Api
{
    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;

        public GigsControllerTests()
        {
            var mockRepository = new Mock<IGigRepository>();

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.SetupGet(uow => uow.Gigs).Returns(mockRepository.Object);

            _controller = new GigsController(mockUow.Object);
            _controller.MockCurrentUser("user1@domain.com", "1");
        }

        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
