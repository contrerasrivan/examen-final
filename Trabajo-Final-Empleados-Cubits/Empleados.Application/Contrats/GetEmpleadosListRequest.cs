using MediatR;


namespace Empleados.Application.Contrats
{
    //Datos que entran al handler
    public class GetEmpleadosListRequest : IRequest<GetEmpleadosListResponse>
    {
        public string? Query { get; set; }
        //public DateTime? From { get; set; }

        //public DateTime? To { get; set; }
    }
}
