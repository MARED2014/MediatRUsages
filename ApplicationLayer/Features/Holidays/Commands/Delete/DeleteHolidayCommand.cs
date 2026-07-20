using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Holidays.Commands.Delete;

public record DeleteHolidayCommand(Guid Id) : IRequest<bool>;
