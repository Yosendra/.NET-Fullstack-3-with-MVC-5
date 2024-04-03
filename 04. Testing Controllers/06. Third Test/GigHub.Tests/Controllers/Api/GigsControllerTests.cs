using System;
using System.Web.Http.Results;
using FluentAssertions;
using GigHub.Controllers.Api;
using GigHub.Core;
using GigHub.Core.Models;
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

        private readonly string _userId;    // promote to be field

        private readonly Mock<IGigRepository> _mockGigRepository;   

        public GigsControllerTests()
        {
            _mockGigRepository = new Mock<IGigRepository>();

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.SetupGet(uow => uow.Gigs).Returns(_mockGigRepository.Object);

            _userId = "1";
            _controller = new GigsController(mockUow.Object);
            _controller.MockCurrentUser(_userId, "user1@domain.com");
        }

        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_GigIsCanceled_ShouldReturnNotFound()
        {
            var gig = new Gig();
            gig.Cancel();

            _mockGigRepository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);

            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_UserCancelingAnotherUsersGig_ShouldReturnUnauthorized()
        {
            var gig = new Gig(_userId + "-", 
                1, 
                DateTime.Now, 
                "Random Place");

            _mockGigRepository.Setup(r => r.GetGigWithAttendees(1)).Returns(gig);

            var result = _controller.Cancel(1);
            result.Should().BeOfType<UnauthorizedResult>();
        }
    }
}
