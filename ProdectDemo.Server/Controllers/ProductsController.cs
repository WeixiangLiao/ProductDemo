using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductDemo.Server.Application.Commands.Products;
using ProductDemo.Server.Application.Queries.Products;
using ProductDemo.Server.Contracts.Products;
using ProductDemo.Server.Controllers.Common;

namespace ProductDemo.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;



    public ProductsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetProductQuery(id));

        return result.Match(
            product => Ok(_mapper.Map<ProductResponse>(product)),
            Problem
        );
    }



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllProductsQuery();

        var result = await _mediator.Send(query);

        return result.Match(
            products => Ok(_mapper.Map<List<ProductResponse>>(products)),
            Problem
        );
    }


    [HttpPost]
    public async Task<IActionResult> Insert(InsertProductRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<InsertProductCommand>(request));

        return result.Match(
             id => Ok(new { id }),
             Problem
             );

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductRequest product)
    {
        if (product.Id != id) return BadRequest("productId not match");

        var command = _mapper.Map<UpdateProductCommand>(product);
        var result = await _mediator.Send(command);
        return result.Match(
            _ => Ok(),
            Problem
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));

        return result.Match(
            _ => NoContent(),
            Problem
            );
    }


}
