using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OM.Application.Orders.Commands.Create;
using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Orders.Queries.GetOrdersList;
using OM.Application.Providers.Queries;
using OrderManagement.Models.Orders;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    public class HomeController : BaseViewController
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var query = new GetOrderListQuery();
            var model = await Mediator.Send(query, cancellationToken);

            return View(model);
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailsQuery
            {
                Id = id
            };
            var orderDetails = await Mediator.Send(query, cancellationToken);

            return View("OrderEditor", OrderViewModelFactory.Details(orderDetails));
        }

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var orderDetails = new OrderDetailsVm();

            var providersQuery = new GetProviderListQuery();
            var providersList = await Mediator.Send(providersQuery, cancellationToken);

            return View("OrderEditor", OrderViewModelFactory.Create(orderDetails, providersList));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderDetailsVm orderDetailsVm, CancellationToken token)
        {

            if (ModelState.IsValid)
            {
                var command = Mapper.Map<CreateOrderCommand>(orderDetailsVm);
                var orderId = Mediator.Send(command, token);

                return RedirectToAction("Index");
            }

            var orderDetails = new OrderDetailsVm();
            var providersQuery = new GetProviderListQuery();
            var providersList = await Mediator.Send(providersQuery, token);

            return View("EmployeeEditor", OrderViewModelFactory.Create(orderDetails, providersList));
        }
    }
}
