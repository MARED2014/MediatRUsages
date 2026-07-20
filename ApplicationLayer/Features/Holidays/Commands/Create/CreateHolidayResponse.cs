using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Holidays.Commands.Create;

public class CreateHolidayResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
