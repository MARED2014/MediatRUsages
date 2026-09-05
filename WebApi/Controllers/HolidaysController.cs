using ApplicationLayer.Features.Holidays.Commands.Create;
using ApplicationLayer.Features.Holidays.Commands.Delete;
using ApplicationLayer.Features.Holidays.Commands.Update;
using ApplicationLayer.Features.Holidays.Queries.GetHoliday;
using ApplicationLayer.Features.Holidays.Queries.GetHolidayById;
using DomainLayer.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HolidaysController : ControllerBase
{
    private readonly ISender _sender;

    public HolidaysController(ISender sender)
    {
        _sender = sender;
    }

    // GET: api/<HolidaysController>
    [HttpGet]
    public async Task<IEnumerable<HolidayListDto>> Get()
    {
        var holiday = await _sender.Send(new GetHolidayQuery());
        return holiday;
    }

    // GET api/<HolidaysController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var holiday = await _sender.Send(new GetHolidayByIdQuery(id));
        return holiday is null ? NotFound() : Ok(holiday);
    }

    // POST api/<HolidaysController>
    [HttpPost]
    public async Task<IActionResult> Create(CreateHolidayCommand command)
    {
        var response = await _sender.Send(command);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    // PUT api/<HolidaysController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateHolidayCommand command)
    {
        await _sender.Send(command);
        return NoContent();
    }

    // DELETE api/<HolidaysController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteHolidayCommand (id);
        await _sender.Send(command);
        return NoContent();
    }
}
