using Application.Commands;
using Infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiTechnicalChallenge.Controllers
{
    public class NumberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NumberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Api retorna os divisores do número informado.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("dividers")]
        public async Task<IActionResult> GetDividers([FromQuery] GetDividersCommand.Contract request)
        {
            return RestResult.CreateHttpResponse(await _mediator.Send(request));
        }

        /// <summary>
        /// Api retorna os números primos entre os divisores do número informado.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("dividers/prime")]
        public async Task<IActionResult> GetPrimeDividers([FromQuery] GetPrimeDividersCommand.Contract request)
        {
            return RestResult.CreateHttpResponse(await _mediator.Send(request));
        }

        /// <summary>
        /// Api retorna os divisores do número e os números primos entre os divisores do número informado.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("dividersAndPrimeDividers")]
        public async Task<IActionResult> GetDividersPrimeDividers([FromQuery] GetDividersAndPrimeDividersCommand.Contract request)
        {
            return RestResult.CreateHttpResponse(await _mediator.Send(request));
        }
    }
}
