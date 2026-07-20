using DomainLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Entities;

public class Holiday : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
