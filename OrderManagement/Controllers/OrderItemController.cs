using Microsoft.AspNetCore.Mvc;
using OM.Application.OrderItems.Commands.Create;
using OM.Application.OrderItems.Commands.Delete;
using OM.Application.OrderItems.Commands.Update;
using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Orders.Commands.Delete;
using OrderManagement.Models.OrderItems;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    public class OrderItemController : BaseViewController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderItemTableVm orderItemTableVm, CancellationToken cancellationToken)
        {
            if(ModelState.IsValid)
            {
                var command = Mapper.Map<CreateOrderItemCommand>(orderItemTableVm);
                var orderItemId = await Mediator.Send(command, cancellationToken);
            };

            return RedirectToAction("Edit", "Home", new { Id = orderItemTableVm.OrderId });
        }

        //public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        //{
        //    var command = Mapper.Map<CreateOrderItemCommand>(orderItemTableVm);
        //    var orderItemId = await Mediator.Send(command, cancellationToken);

        //    return RedirectToAction("Edit", "Home", new { Id = orderItemTableVm.OrderId });
        //}

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] OrderItemTableVm orderItemTableVm, CancellationToken cancellationToken)
        {
            var command = Mapper.Map<UpdateOrderItemCommand>(orderItemTableVm);
            await Mediator.Send(command, cancellationToken);

            return RedirectToAction("Edit", "Home", new { Id = orderItemTableVm.OrderId });
        }

        public async Task<IActionResult> Delete(int id, int orderId, CancellationToken cancellationToken)
        {
            var command = new DeleteOrderItemCommand
            {
                Id = id
            };
            await Mediator.Send(command, cancellationToken);

            //return RedirectToAction();
            return RedirectToAction("Edit", "Home", new { Id = orderId });
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete([FromForm] OrderItemTableVm orderItemTableVm, CancellationToken cancellationToken)
        //{
        //    var command = Mapper.Map<DeleteOrderItemCommand>(orderItemTableVm);
        //    await Mediator.Send(command, cancellationToken);

        //    return RedirectToAction("Edit", "Home", new { Id = orderItemTableVm.OrderId });
        //}
    }
}
