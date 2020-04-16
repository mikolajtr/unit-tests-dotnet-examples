using Microsoft.EntityFrameworkCore;
using System;
using UnitTesting.DatabaseAccess;

namespace UnitTesting
{
    public class InMemoryDatabaseTestFixture : IDisposable
    {
        private bool disposed = false;
        protected readonly DbContextOptions<BlogContext> DbOptions;

        public InMemoryDatabaseTestFixture()
        {
            // guid is used to create new in-memory database for each repository to avoid conflicts between tests
            DbOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase("SampleDb" + Guid.NewGuid().ToString())
                .Options;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                using (var sampleDbContext = new BlogContext(DbOptions))
                {
                    sampleDbContext.Database.EnsureDeleted();
                }
            }

            disposed = true;
        }

        ~InMemoryDatabaseTestFixture()
        {
            Dispose(false);
        }
    }
}
