using System;
using AutoMapper;
using TuiMusement.CitiesWeather.CitiesServiceClient.Models;
using TuiMusement.CitiesWeather.Domain.Entities;
using TuiMusement.CitiesWeather.Domain.ValueObjects;

namespace TuiMusement.CitiesWeather.Application.Profiles
{
    public class CityProfile: Profile
    {
        public CityProfile()
        {
            CreateMap<CityDto, City>()
                .ConstructUsing(cityDto => new City(CityId.From(cityDto.Id)))
                .ForMember(
                    city => city.Name,
                    options => options.MapFrom(cityDto => CityName.From(cityDto.Name)))
                .ForMember(
                    city => city.Latitude,
                    options => options.MapFrom(cityDto => Latitude.From(cityDto.Latitude)))
                .ForMember(
                    city => city.Longitude,
                    options => options.MapFrom(cityDto => Longitude.From(cityDto.Longitude)))
                .ForMember(
                    city => city.WeatherForecasts,
                    options => options.Ignore());
        }
    }
}