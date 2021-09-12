using System.Collections.Generic;

namespace PrimeNumbers.WebApi.Services.Responses
{
    public class FactoryPrimeNumbersResponse
    {
        public int Number { get; set; }
        public ICollection<int> Divisibles { get; } 
            = new List<int>();
        public ICollection<int> PrimeNumbers { get; }
            = new List<int>();
    }
}
