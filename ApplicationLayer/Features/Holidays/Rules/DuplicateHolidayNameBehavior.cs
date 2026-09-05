using ApplicationLayer.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Context;

namespace ApplicationLayer.Features.Holidays.Rules;

public class DuplicateHolidayNameBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICheckHolidayName
{
    private readonly AppDbContext _context;

    public DuplicateHolidayNameBehavior(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        bool nameExists;
        if (request is ICheckHolidayNameWithId updateRequest)
        {
            nameExists = await _context.Holidays.AnyAsync(p => p.Name == updateRequest.Name && p.Id != updateRequest.Id, cancellationToken);
        }
        else
        {
            nameExists = await _context.Holidays.AnyAsync(p => p.Name == request.Name, cancellationToken);
        }

        if (nameExists)
        {
            throw new DuplicateHolidayNameException("Bu isim başka bir tatil tarafından kullanılıyor.");
        }

        return await next();
    }
}
