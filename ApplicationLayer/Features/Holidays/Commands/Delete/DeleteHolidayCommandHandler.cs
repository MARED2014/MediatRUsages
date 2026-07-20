using MediatR;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Context;

namespace ApplicationLayer.Features.Holidays.Commands.Delete;

public class DeleteHolidayCommandHandler : IRequestHandler<DeleteHolidayCommand, bool>
{
    private readonly AppDbContext _context;

    public DeleteHolidayCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteHolidayCommand request, CancellationToken cancellationToken)
    {
        var holiday = await _context.Holidays.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (holiday == null)
        {
            throw new KeyNotFoundException("Silinmek istenen tatil bulunamadı.");
        }

        _context.Holidays.Remove(holiday);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
