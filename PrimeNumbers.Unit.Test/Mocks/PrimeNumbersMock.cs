using Bogus;
using PrimeNumbers.WebApi.ViewModel;

namespace PrimeNumbers.Unit.Test.Services.Mocks
{
    public static class PrimeNumbersMock
    {
        private const string locale = "pt_BR";

        public static Faker<NumbersViewModel> ExpectedNumberFaker =>
            new Faker<NumbersViewModel>(locale)
            .CustomInstantiator(x => new NumbersViewModel
            {
                Number = x.Random.Number(1, int.MaxValue)
            });

        public static Faker<NumbersViewModel> ZeroOrNegativeNumberFaker =>
            new Faker<NumbersViewModel>(locale)
            .CustomInstantiator(x => new NumbersViewModel
            {
                Number = x.Random.Number(int.MinValue, 0)
            });
    }
}
