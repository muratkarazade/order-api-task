using AutoMapper;
using ECO.Application.Dto.CarrierConfiguration;
using ECO.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using ECO.Application.Features.Commands.CarrierConfiguration.DeleteCarrierConfiguration;
using ECO.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using ECO.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration;
using ECO.Application.Features.Queries.CarrierConfiguration.GetCarrierConfigurationById;
using ECO.Application.Utilities.Result.Common;
using ECO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.MappingProfiles.CarrierConfigurationMap
{
    internal class CarrierConfigurationProfile : Profile
    {
        public CarrierConfigurationProfile()
        {
            CreateMap<CreateCarrierConfigurationCommandRequest, CarrierConfiguration>().ReverseMap();
            CreateMap<IResult, CreateCarrierConfigurationCommandResponse>().ReverseMap();

            CreateMap<DeleteCarrierConfigurationCommandRequest, CarrierConfiguration>().ReverseMap();
            CreateMap<IResult, DeleteCarrierConfigurationCommandResponse>().ReverseMap();

            CreateMap<UpdateCarrierConfigurationCommandRequest, CarrierConfiguration>().ReverseMap();
            CreateMap<IResult, UpdateCarrierConfigurationCommandResponse>().ReverseMap();

            CreateMap<GetAllCarrierConfigurationQueryRequest, CarrierConfiguration>().ReverseMap();
            CreateMap<IDataResult<List<CarrierConfiguration>>, GetAllCarrierConfigurationQueryResponse>().ReverseMap();

            CreateMap<GetCarrierConfigurationByIdQueryRequest, CarrierConfiguration>().ReverseMap();
            CreateMap<CarrierConfiguration, GetCarrierConfigurationByIdQueryResponse>().ReverseMap();

            CreateMap<CreateCarrierConfigurationDto, CarrierConfiguration>().ReverseMap();
            CreateMap<UpdateCarrierConfigurationDto, CarrierConfiguration>().ReverseMap();
        }
    }
}
