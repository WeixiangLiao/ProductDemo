using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductDemo.Server.Application.Queries.Buyers;
using ProductDemo.Server.Contracts.Buyers;
using ProductDemo.Server.Controllers.Common;

namespace ProductDemo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class BuyersController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;



    public BuyersController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    //[HttpGet("id")]
    //public async Task<IActionResult> Get(Guid id)
    //{
    //    var result = await _mediator.Send(new GetBuyerQuery(id));

    //    return result.Match(
    //        buyer => Ok(_mapper.Map<BuyerResponse>(buyer)),
    //        Problem
    //    );
    //}



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllBuyersQuery();

        var result = await _mediator.Send(query);

        return result.Match(
            products => Ok(_mapper.Map<List<BuyerResponse>>(products)),
            Problem
        );
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //    var query = new GetAllBuyersQuery();

    //    var result = await _mediator.Send(query);

    //    return result.Match(
    //        buyers => Ok(_mapper.Map<List<BuyerResponse>>(buyers)),
    //        Problem
    //    );
    //}

    //[HttpPost]
    //public async Task<IActionResult> Insert(InsertBuyerRequest request)
    //{
    //    var result = await _mediator.Send(_mapper.Map<InsertBuyerCommand>(request));

    //    return result.Match(
    //         id => Ok(new { id }),
    //         Problem
    //         );

    //}

    //[HttpPut("id")]
    //public async Task<IActionResult> Update(Guid id, UpdateBuyerRequest buyer)
    //{
    //    if (buyer.Id != id) return BadRequest("buyerId not match");

    //    var command = _mapper.Map<UpdateBuyerCommand>(buyer);
    //    var result = await _mediator.Send(command);
    //    return result.Match(
    //        _ => Ok(),
    //        Problem
    //    );
    //}

    //[HttpDelete("id")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    var result = await _mediator.Send(new DeleteBuyerCommand(id));

    //    return result.Match(
    //        _ => NoContent(),
    //        Problem
    //        );
    //}


}
