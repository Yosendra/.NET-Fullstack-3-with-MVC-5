using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Tests.Extensions
{
    public static class MockDbSetExtensions
    {
        public static void setSource<T>(this Mock<DbSet<T>> mockSet, IList<T> source) where T : class
        {
            // https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking
            var data = source.AsQueryable();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
        }
    }
}
