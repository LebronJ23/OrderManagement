using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using OM.Application.OrderItems.Queries.GetOrderItemsListForOrder;
using OM.Application.Orders.Commands.Create;
using OM.Application.Orders.Commands.Delete;
using OM.Application.Orders.Commands.Update;
using OM.Application.Orders.Queries.GetAllOrders;
using OM.Application.Orders.Queries.GetOrderDetails;
using OM.Application.Orders.Queries.GetOrdersList;
using OM.Application.Providers.Queries;
using OM.Domain;
using OrderManagement.Models.Orders;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    public class HomeController : BaseViewController
    {
        [HttpGet]
        //public async Task<IActionResult> Index(int? providerId, string number, DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        public async Task<IActionResult> Index(FiltrationModel filtrationModel, CancellationToken cancellationToken)
        {
            var providersQuery = new GetProviderListQuery();
            var providersList = await Mediator.Send(providersQuery, cancellationToken);

            var ordersQuery = new GetAllOrdersQuery();
            var ordersQueryResult = await Mediator.Send(ordersQuery, cancellationToken);

            //var filtrationModel = new FiltrationModel
            //{
            //    Number = number,
            //    ProviderId = providerId ?? 0,
            //    Providers = providersList,
            //};
            //if(startDate != DateTime.MinValue)
            //{
            //    filtrationModel.StartDate = startDate;
            //}
            //if (endDate != DateTime.MinValue)
            //{
            //    filtrationModel.EndDate = endDate;
            //}
            //if (!FiltrationModel.Providers.Providers.Any())
            //{
            //    var providersQuery = new GetProviderListQuery();
            //    var providersList = await Mediator.Send(providersQuery, cancellationToken);
            //    FiltrationModel.Providers = providersList;
            //}
            var query = new GetOrderListQuery
            {
                FiltrationModel = filtrationModel,
                Providers = new ProviderListVm
                {
                    Providers = ordersQueryResult
                        .Orders
                        .Select(order => order.Provider)
                        .GroupBy(p => p.Id)
                        .Select(g => g.First())
                        .ToList()
                },
                Numbers = ordersQueryResult.Orders.ToList(),
                OrderItems = new OrderItemListVm 
                { 
                    OrderItems = ordersQueryResult
                        .Orders
                        .SelectMany(order => order.OrderItems)
                        .GroupBy(oI => oI.Id)
                        .Select(oIg => oIg.First())
                        .ToList()
                }
            };
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
        public async Task<IActionResult> Create([FromForm] OrderDetailsVm orderDetails, CancellationToken cancellationToken)
        {

            if (ModelState.IsValid)
            {
                var command = Mapper.Map<CreateOrderCommand>(orderDetails);
                var orderId = await Mediator.Send(command, cancellationToken);

                return RedirectToAction("Index");
            }

            orderDetails = new OrderDetailsVm();
            var providersQuery = new GetProviderListQuery();
            var providersList = await Mediator.Send(providersQuery, cancellationToken);

            return View("OrderEditor", OrderViewModelFactory.Create(orderDetails, providersList));
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailsQuery
            {
                Id = id
            };
            var orderDetails = await Mediator.Send(query, cancellationToken);

            return View("OrderEditor", OrderViewModelFactory.Delete(orderDetails));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] OrderDetailsVm orderDetails, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<DeleteOrderCommand>(orderDetails);
                await Mediator.Send(command, cancellationToken);

                return RedirectToAction("Index");
            }


            return View("OrderEditor", OrderViewModelFactory.Delete(orderDetails));
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailsQuery
            {
                Id = id
            };
            var orderDetails = await Mediator.Send(query, cancellationToken);
            var providersQuery = new GetProviderListQuery();
            var providersList = await Mediator.Send(providersQuery, cancellationToken);

            return View("OrderEditor", OrderViewModelFactory.Edit(orderDetails, providersList));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] OrderDetailsVm orderDetails, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<UpdateOrderCommand>(orderDetails);
                await Mediator.Send(command, cancellationToken);

                return RedirectToAction("Index");
            }

            var providersQuery = new GetProviderListQuery();
            var providersList = await Mediator.Send(providersQuery, cancellationToken);

            return View("OrderEditor", OrderViewModelFactory.Edit(orderDetails, providersList));
        }
    }
}
