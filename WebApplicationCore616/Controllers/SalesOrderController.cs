using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationCore616.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SalesOrderController:ControllerBase
    {
        private readonly TestContext _testContext;
        public SalesOrderController(TestContext testContext)
        {
            _testContext = testContext;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SalesOrder salesOrder)
        {
            if (salesOrder == null) return BadRequest("订单不能为空");
            salesOrder.OrderId = default;
            salesOrder.CreateTime = DateTime.Now;
            await _testContext.SalesOrder.AddAsync(salesOrder);
            await _testContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = salesOrder.OrderId }, salesOrder);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _testContext.SalesOrder.FindAsync(id);
            if (order == null) return NotFound($"订单{id}不存在");
            _testContext.SalesOrder.Remove(order);
            await _testContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SalesOrder salesOrder)
        {
            var order = await _testContext.SalesOrder.FindAsync(id);
            if (order == null) return NotFound($"订单{id}不存在");
            order.CreateTime = salesOrder.CreateTime;
            order.OrderNo = salesOrder.OrderNo;
            order.FinishTime = salesOrder.FinishTime;
            order.CustomerName = salesOrder.CustomerName;
            order.Quantity = salesOrder.Quantity;
            order.Amount = salesOrder.Amount;
            order.Remark = salesOrder.Remark;
            order.OrderStatus = salesOrder.OrderStatus;
            order.ProductCode = salesOrder.ProductCode;
            await _testContext.SaveChangesAsync();
            return Ok(order);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _testContext.SalesOrder.FindAsync(id);
            if (order == null) return NotFound($"订单{id}不存在");
            return Ok(order);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _testContext.SalesOrder.Take(100).ToListAsync();
            return Ok(orders);
        }
    }
}
