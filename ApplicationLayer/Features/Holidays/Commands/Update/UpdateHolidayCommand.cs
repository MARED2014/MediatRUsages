using ApplicationLayer.Features.Holidays.Rules;
using MediatR;

namespace ApplicationLayer.Features.Holidays.Commands.Update;

public record UpdateHolidayCommand(Guid Id, string Name, DateOnly StartDate, DateOnly EndDate) : IRequest<bool>, ICheckHolidayNameWithId;