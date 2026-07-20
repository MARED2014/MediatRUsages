using MediatR;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Context;

namespace ApplicationLayer.Features.Holidays.Commands.Update;

public class UpdateHolidayCommandHandler: IRequestHandler<UpdateHolidayCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateHolidayCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateHolidayCommand request, CancellationToken cancellationToken)
    {
        var holiday = await _context.Holidays.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (holiday == null)
        {
            throw new KeyNotFoundException("Güncellenmek istenen tatil bulunamadı.");
        }

        holiday.Name = request.Name;
        holiday.StartDate = request.StartDate;
        holiday.EndDate = request.EndDate;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
