using DomainLayer.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Holidays.Queries.GetHolidayById;

public class GetHolidayByIdQueryHandler : IRequestHandler<GetHolidayByIdQuery, HolidayListDto?>
{
    private readonly AppDbContext _context;

    public GetHolidayByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HolidayListDto?> Handle(GetHolidayByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Holidays
            .Where(x => x.Id == request.Id)
            .Select(x => new HolidayListDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
