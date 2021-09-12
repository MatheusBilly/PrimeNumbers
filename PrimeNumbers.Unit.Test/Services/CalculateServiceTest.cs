using PrimeNumbers.Unit.Test.Services.Mocks;
using PrimeNumbers.WebApi.Services;
using Xunit;

namespace PrimeNumbers.Unit.Test.Services
{
    public class CalculateServiceTest
    {
        private readonly CalculateService _calculateService;

        public CalculateServiceTest()
        {
            _calculateService = new CalculateService();
        }

        [Fact]
        public void GetPrimeFactory_ShouldReturnFactoryPrimeNumbersResponse()
        {
            var mock = PrimeNumbersMock.ExpectedNumberFaker.Generate();

            var response = _calculateService.GetPrimeFactory(mock.Number);

            Assert.NotNull(response);
        }

        [Fact]
        public void GetPrimeFactory_ShouldReturnResponse_WithDivisibleOrPrimeNumbersPropertyEmpty()
        {
            var mock = PrimeNumbersMock.ZeroOrNegativeNumberFaker.Generate();

            var response = _calculateService.GetPrimeFactory(mock.Number);

            Assert.Empty(response.Divisibles);
            Assert.Empty(response.PrimeNumbers);
        }

        [Fact]
        public void IsPrimeNumber_ShouldBeTrue()
        {
            var number = 5;

            var response = _calculateService.IsPrimeNumber(number);

            Assert.True(response);
        }

        [Fact]
        public void IsPrimeNumber_ShouldBeFalse()
        {
            var number = 4;

            var response = _calculateService.IsPrimeNumber(number);

            Assert.False(response);
        }
    }
}
