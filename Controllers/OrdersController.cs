using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIA2.Models;
using WebAPIA2.Data;
using WebAPIA2.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPIA2.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrdersAPIRepo _repository;

        public OrdersController(IOrdersAPIRepo repository)
        {
            _repository = repository;
        }

        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpPost("PurchaseItem")]
        public async Task<ActionResult<OrderOutDto>> PurchaseItemAsync(OrderInputDto order)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("userName");
            string userName = c.Value;
            Order o = new Order
            {
                UserName = userName,
                ProductID = order.ProductID,
                Quantity = order.Quantity
            };
            await _repository.AddOrderAsync(o);
            IEnumerable<Order> os = await _repository.GetAllOrdersAsync();
            o = os.LastOrDefault(e => e.UserName == o.UserName && e.ProductID == o.ProductID && e.Quantity == o.Quantity);
            return Created("ok", o);
        }
    }
}
