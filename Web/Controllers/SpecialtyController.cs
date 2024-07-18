using Application.Queries.SpecialtyQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
public class SpecialtyController(IMediator mediator, IMapper mapper) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var specialties = await _mediator.Send(new GetSpecialtyListQuery());

        return View(specialties);
    }
}
