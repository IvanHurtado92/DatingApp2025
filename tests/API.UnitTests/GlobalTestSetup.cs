using API.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace API.UnitTests
{
    [SetUpFixture]
    public class GlobalTestSetup
    {
        public static AppDbContext AppDbContext { get; private set; }

        [OneTimeSetUp] // estrategia de N unit para inicializar el proyecto de una sola vez
        public async Task Setup()
        {
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=dating.db")
                .Options;

            AppDbContext = new AppDbContext(options);
            await AppDbContext.Database.MigrateAsync();
        }
        
        [OneTimeTearDown] // estrategia pero para terminar
        public async Task TearDown()
        {
            await AppDbContext.DisposeAsync();
        }
    
    }
}