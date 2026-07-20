using DomainLayer.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Context;

namespace ApplicationLayer.Features.Holidays.Queries.GetHoliday;

public class GetHolidayQueryHandler : IRequestHandler<GetHolidayQuery, IEnumerable<HolidayListDto>>
{
    private readonly AppDbContext _context;

    public GetHolidayQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HolidayListDto>> Handle(GetHolidayQuery request, CancellationToken cancellationToken)
    {
        return await _context.Holidays
                .Select(x => new HolidayListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                })
                .ToListAsync(cancellationToken);
    }
}
