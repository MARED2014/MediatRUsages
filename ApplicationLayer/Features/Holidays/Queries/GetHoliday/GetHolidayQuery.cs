using DomainLayer.Dtos;
using MediatR;

namespace ApplicationLayer.Features.Holidays.Queries.GetHoliday;

public record GetHolidayQuery : IRequest<IEnumerable<HolidayListDto>>;
