using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class Reply
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order GetOrder { get; set; }
    }
}
