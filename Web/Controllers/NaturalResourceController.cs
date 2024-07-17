using Application.Queries.NaturalResourceQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
public class NaturalResourceController(IMediator mediator, IMapper mapper) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var resources = await _mediator.Send(new GetNaturalResourceListQuery());

        return View(resources);
    }
}
