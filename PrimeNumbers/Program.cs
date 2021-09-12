using System;
using PrimeNumbers.WebApi.Services.Responses;
using System.Net.Http;
using System.Net.Http.Headers;
using PrimeNumbers.WebApi.ViewModel;

namespace PrimeNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool shutDown = false;

            Console.WriteLine("Divisores e Fatores Primos\r");
            Console.WriteLine("---------------------------");

            while (!shutDown)
            {
                ExecuteProgram();

                Console.WriteLine("------------------------\n");

                Console.Write("Aperte 's' e em seguida Enter para encerrar o app, ou aperte qualquer outra tecla para continuar: ");

                if (Console.ReadLine() == "s") shutDown = true;

                Console.WriteLine("\n");
            }

            return;
        }

        public static void ExecuteProgram()
        {
            Console.WriteLine("Digite um número e em seguida Enter: ");

            int number = Convert.ToInt32(Console.ReadLine());

            var numbersViewModel = new NumbersViewModel
            {
                Number = number
            };

            var validate = numbersViewModel.Validate();

            if (!validate.IsValid)
            { 
                Console.WriteLine(string.Join(",", validate.Errors));
                return;
            }

            var response = CallPrimeFactoryAPI(number);

            if (response is null)
                Console.WriteLine("Ocorreu um erro na comunicação com a API.");
            else
            {
                Console.WriteLine("Número de Entrada: " + number);
                Console.WriteLine("Números Divisores: " + string.Join(',', response.Divisibles));
                Console.WriteLine("Números Primos: " + string.Join(',', response.PrimeNumbers));
            }
        }

        private static FactoryPrimeNumbersResponse CallPrimeFactoryAPI(int number)
        {
            using var client = new HttpClient();
            
            client.BaseAddress = new Uri(@"https://localhost:44390/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("/api/Calculate/prime-number?Number=" + number).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<FactoryPrimeNumbersResponse>().GetAwaiter().GetResult();

            return null;
        }
    }
}
