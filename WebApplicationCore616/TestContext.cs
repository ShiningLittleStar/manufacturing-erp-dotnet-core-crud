using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace WebApplicationCore616
{
    public class TestContext:DbContext
    {
        public TestContext(DbContextOptions<TestContext>options):base(options)
        {
            
        }
        public DbSet<SalesOrder> SalesOrder {  get; set; }
    }
    [Table("SalesOrder")]
    public class SalesOrder
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int OrderStatus { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Remark { get; set; }
    }
}
