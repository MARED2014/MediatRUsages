using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Holidays.Rules;

public interface ICheckHolidayNameWithId : ICheckHolidayName
{
    Guid Id { get; } 
}
