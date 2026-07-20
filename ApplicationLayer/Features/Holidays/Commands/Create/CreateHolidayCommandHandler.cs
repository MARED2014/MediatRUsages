using DomainLayer.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Holidays.Commands.Create;

public class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, CreateHolidayResponse>
{
    private readonly AppDbContext _context;

    public CreateHolidayCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CreateHolidayResponse> Handle(CreateHolidayCommand request, CancellationToken cancellationToken)
    {
        var holiday = new Holiday
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };

        _context.Holidays.Add(holiday);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateHolidayResponse
        {
            Id = holiday.Id,
            CreatedDate = DateTime.UtcNow
        };
    }
}

public class DuplicateHolidayNameException : Exception
{
    public DuplicateHolidayNameException(string message) : base(message) { }
}
