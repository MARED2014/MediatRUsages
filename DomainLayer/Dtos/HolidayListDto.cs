using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Dtos;

public class HolidayListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
