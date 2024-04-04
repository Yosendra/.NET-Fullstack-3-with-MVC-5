using FluentAssertions;
using GigHub.Core.Models;
using GigHub.Persistence;
using GigHub.Persistence.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;

namespace GigHub.Tests.Persistence.Repositories
{

    [TestClass]
    public class GigRepositoryTests
    {
        private GigRepository _repository;
        private Mock<DbSet<Gig>> _mockGigs;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockContext = new Mock<IApplicationDbContext>();

            _mockGigs = new Mock<DbSet<Gig>>();
            mockContext.SetupGet(c => c.Gigs).Returns(_mockGigs.Object);

            _repository = new GigRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsInThePast_ShouldNotBeReturned()
        {
            var artistId = "1";
            
            var gig = new Gig(artistId, 1, DateTime.Now.AddDays(-1), "Venue");
            _mockGigs.setSource(new[] {gig});

            var gigs = _repository.GetUpcomingGigsByArtist(artistId);
            gigs.Should().BeEmpty();
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsCanceled_ShouldNotBeReturned()
        {
            var artistId = "1";

            var gig = new Gig(artistId, 1, DateTime.Now.AddDays(1), "Venue");
            gig.Cancel();

            _mockGigs.setSource(new[] { gig });

            var gigs = _repository.GetUpcomingGigsByArtist(artistId);
            gigs.Should().BeEmpty();
        }
    }
}
