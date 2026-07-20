using DomainLayer.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Holidays.Queries.GetHolidayById;

public record GetHolidayByIdQuery(Guid Id) : IRequest<HolidayListDto?>;