using Lorena_TestTask.DataBase;
using Lorena_TestTask.Services;

namespace Lorena_TestTask.Tests
{
    [TestFixture]
    public class Tests
    {
        private LorenaDbContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new LorenaDbContext();
            _context.Database.EnsureCreated();
            _context.SeedData();
        }

        [TestCase("Амелия", 5360.00, 4877.60)]
        [TestCase("Тест1", 136540.00, 121520.60)]
        [TestCase("Тест2", 54054.00, 51891.84)]
        [TestCase("Курган", 57850.00, 51486.50)]
        [TestCase("Миасс", 57470.00, 55171.20)]
        public void CalculatePrice_ReturnsExpectedResult(string salonName, decimal price, decimal expectedFinalPrice)
        {
            var salon = _context.Salons.Single(s => s.Name == salonName);
            decimal finalPrice = PriceCalculator.CalculatePrice(price, salon);

            Assert.That(Convert.ToDouble(finalPrice), Is.EqualTo(Convert.ToDouble(expectedFinalPrice)).Within(0.01),
                        $"Для {salonName} ожидаемая цена {expectedFinalPrice}, но получена {finalPrice}.");
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}