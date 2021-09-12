using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PrimeNumbers.WebApi.Services.Interfaces;
using PrimeNumbers.WebApi.Services.Responses;
using PrimeNumbers.WebApi.ViewModel;

namespace PrimeNumbers.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculateService _calculateService;

        public CalculateController(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        /// <summary>
        /// Decompõe o número em seus divisores e enumera os fatores primos.
        /// </summary>
        /// <param name="numberViewModel">Número a ser calculado.</param>
        /// <response code="200">Objeto contendo o número informado, uma lista de inteiros com os divisores do núemero e o seus fatores primos.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [HttpGet("prime-number")]
        [ProducesResponseType(typeof(FactoryPrimeNumbersResponse), 200)]
        [ProducesResponseType(typeof(ValidationFailure), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public ActionResult<FactoryPrimeNumbersResponse> GetPrimeFactory([FromQuery]NumbersViewModel numberViewModel)
        {
            var validate = numberViewModel.Validate();

            if (!validate.IsValid) return BadRequest(validate.Errors);

            return Ok(_calculateService.GetPrimeFactory(numberViewModel.Number));
        }

        /// <summary>
        /// Verifica se um determinado número é primo.
        /// </summary>
        /// <param name="numberViewModel">Número a ser verificado</param>
        /// <response code="200">True se o número for Primo. False se o número não for Primo.</response>
        /// <response code="400">Erro de requisição.</response>
        /// <response code="401">Acesso negado.</response>
        /// <response code="500">Erro interno da API.</response>
        [HttpGet("prime-number/check")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(ValidationFailure), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public ActionResult<bool> IsPrimeNumber([FromQuery]NumbersViewModel numberViewModel)
        {
            var validate = numberViewModel.Validate();

            if (!validate.IsValid) return BadRequest(validate.Errors);

            return Ok(_calculateService.IsPrimeNumber(numberViewModel.Number));
        }
    }
}
