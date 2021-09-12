using PrimeNumbers.WebApi.Services.Interfaces;
using PrimeNumbers.WebApi.Services.Responses;

namespace PrimeNumbers.WebApi.Services
{
    public class CalculateService : ICalculateService
    {
        public FactoryPrimeNumbersResponse GetPrimeFactory(int number)
        {
            var response = new FactoryPrimeNumbersResponse
            {
                Number = number
            };

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    response.Divisibles.Add(i);

                    if (IsPrimeNumber(i)) response.PrimeNumbers.Add(i);
                }
            }

            return response;
        }

        public bool IsPrimeNumber(int number)
        {
            for (int i = 2; i < number; i++)
                if (number % i == 0) return false;

            return true;
        }
    }
}
