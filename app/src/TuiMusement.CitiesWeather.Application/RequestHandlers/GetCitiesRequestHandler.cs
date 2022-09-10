using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TuiMusement.CitiesWeather.Application.Requests;
using TuiMusement.CitiesWeather.CitiesServiceClient;
using TuiMusement.CitiesWeather.Domain.Entities;

namespace TuiMusement.CitiesWeather.Application.RequestHandlers
{
    public class GetCitiesRequestHandler: IRequestHandler<GetCitiesRequest, Response<IEnumerable<City>>>
    {
        private readonly ICitiesServiceClient _citiesServiceClient;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetCitiesRequestHandler(ICitiesServiceClient citiesServiceClient, IMapper mapper, IMediator mediator)
        {
            _citiesServiceClient = citiesServiceClient;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Response<IEnumerable<City>>> Handle(GetCitiesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var citiesResponse = await _citiesServiceClient
                    .GetCitiesAsync();
                var cities = citiesResponse.GetContent()
                    .Select(city => _mapper.Map<City>(city))
                    .ToList();
                return await SetCitiesWeatherForecasts(cities);
            }
            catch (Exception e)
            {
                return Response<IEnumerable<City>>.NewFailedResponse(e);
            }
        }

        private async Task<Response<IEnumerable<City>>> SetCitiesWeatherForecasts(IList<City> cities)
        {
            foreach (var city in cities)
            {
                var weatherResponse = await SetCityWeatherForecasts(city);
                if (!weatherResponse.IsSuccessful)
                {
                    return Response<IEnumerable<City>>.NewFailedResponse(weatherResponse.Exception!);
                }
            }
            return Response<IEnumerable<City>>.NewSuccessfulResponse(cities);
        }
        
        private async Task<Response<IEnumerable<WeatherForecast>>> SetCityWeatherForecasts(City city)
        {
                var getCityWeatherRequest = new GetWeatherForecastsRequest(city.Id, city.Latitude, city.Longitude);
                var getCityWeatherResponse = await _mediator.Send(getCityWeatherRequest);
                if (getCityWeatherResponse.IsSuccessful)
                {
                    city.WeatherForecasts = getCityWeatherResponse.Value!;
                }
                return getCityWeatherResponse;
        }
    }
}