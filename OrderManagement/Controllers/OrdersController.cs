using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OM.Application.Orders.Commands.Create;
using OM.Application.Orders.Commands.Delete;
using OM.Application.Orders.Commands.Update;
using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Orders.Queries.GetOrdersList;
using OM.Application.Orders.Queries.GetOrdersListDetail;
using OrderManagement.Models.Orders;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    //[Route("api/[controller]")]
    //public class OrdersController : BaseController
    //{
    //    private readonly IMapper _mapper;

    //    public OrdersController(IMapper mapper)
    //    {
    //        _mapper = mapper;
    //    }

    //    [HttpGet]
    //    public async Task<ActionResult<OrderDetailsListVm>> GetAll(CancellationToken cancellationToken)
    //    {
    //        var query = new GetOrdersListDetailQuery();
    //        var model = await Mediator.Send(query, cancellationToken);

    //        return Ok(model);
    //        //return View(model);
    //    }

    //    //[HttpGet]
    //    //public async Task<ActionResult<OrderTableListVm>> GetAllTable(CancellationToken cancellationToken)
    //    //{
    //    //    var query = new GetOrderListQuery();
    //    //    var model = await Mediator.Send(query, cancellationToken);

    //    //    return Ok(model);
    //    //    //return View(model);
    //    //}

    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<OrderDetailsVm>> Get(int id, CancellationToken cancellationToken)
    //    {
    //        var query = new GetOrderDetailsQuery
    //        {
    //            Id = id
    //        };
    //        var model = await Mediator.Send(query, cancellationToken);

    //        return Ok(model);
    //        //return View(model);
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<int>> Create([FromBody]CreateOrderDto createOrderDto, CancellationToken cancellationToken)
    //    {
    //        var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
    //        var orderId = await Mediator.Send(command, cancellationToken);

    //        return Ok(orderId);
    //        //return View(orderId);
    //    }

    //    [HttpPut]
    //    public async Task<IActionResult> Update([FromBody] UpdateOrderDto updateOrderDto, CancellationToken cancellationToken)
    //    {
    //        var command = _mapper.Map<UpdateOrderCommand>(updateOrderDto);
    //        await Mediator.Send(command, cancellationToken);
    //        return NoContent();
    //    }


    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<OrderDetailsVm>> Delete(int id, CancellationToken cancellationToken)
    //    {
    //        var command = new DeleteOrderCommand
    //        {
    //            Id = id
    //        };
    //        await Mediator.Send(command, cancellationToken);

    //        return NoContent();
    //        //return RedirectToAction;
    //    }
    //}
}
