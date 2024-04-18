namespace Kafka.Consumer
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}\nProductId: {ProductId}\nQuantity: {Quantity}";
        }
    }
}