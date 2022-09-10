using System.Collections.Generic;
using MediatR;
using TuiMusement.CitiesWeather.Domain.Entities;

namespace TuiMusement.CitiesWeather.Application.Requests
{
    public class GetCitiesRequest: IRequest<Response<IEnumerable<City>>>
    {
        
    }
}