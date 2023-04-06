using Microsoft.AspNetCore.Mvc;
using OM.Application.OrderItems.Commands.Create;
using OrderManagement.Models.OrderItems;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    public class OrderItemController : BaseViewController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create([FromForm]CreateOrderItemDto orderItemDto, CancellationToken cancellationToken)
        {
            var command = Mapper.Map<CreateOrderItemCommand>(orderItemDto);
            var orderItemId = await Mediator.Send(command, cancellationToken);

           return RedirectToAction("Details", "Home", new { Id = orderItemDto.OrderId });
        }
    }
}
