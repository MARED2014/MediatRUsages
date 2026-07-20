using ApplicationLayer.Features.Holidays.Rules;
using MediatR;

namespace ApplicationLayer.Features.Holidays.Commands.Create;

public record CreateHolidayCommand(string Name, string Description, DateOnly StartDate, DateOnly EndDate) : IRequest<CreateHolidayResponse>, ICheckHolidayName;
