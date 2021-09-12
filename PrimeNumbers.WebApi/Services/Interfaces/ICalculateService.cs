using PrimeNumbers.WebApi.Services.Responses;

namespace PrimeNumbers.WebApi.Services.Interfaces
{
    public interface ICalculateService
    {
        FactoryPrimeNumbersResponse GetPrimeFactory(int number);
        bool IsPrimeNumber(int number);
    }
}
