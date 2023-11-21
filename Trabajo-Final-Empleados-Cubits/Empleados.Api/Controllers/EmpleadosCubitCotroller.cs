using Empleados.Application;
using Empleados.Application.Contrats;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Empleados.Api.Controllers
{
    [ApiController]
    [Route("/api/empleados")]
    [AllowAnonymous]
    public class EmpleadosCubitCotroller : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpleadosCubitCotroller(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetList([FromQuery] GetEmpleadosListRequest request)
        {
            var  response = await _mediator.Send(request);
            return Ok(response);

        }
    }
}
