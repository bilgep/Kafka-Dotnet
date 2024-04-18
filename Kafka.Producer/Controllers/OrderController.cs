using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Kafka.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly string bootstrapServers = "localhost:9092";
        private readonly string topic = "testtopic3";

        private readonly ILogger<Order> _logger;

        public OrderController(ILogger<Order> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "AddOrder")]
        public async Task<Order> Add([FromBody]Order order)
        {

            try
            {
                ProducerConfig config = new ProducerConfig
                {
                    BootstrapServers = bootstrapServers,
                    ClientId = "KafkaExampleProducer"
                };

                using var producer = new ProducerBuilder<Null, string>(config).Build();
                var message = new Message<Null, string> { Value = JsonSerializer.Serialize<Order>(order) };
                await producer.ProduceAsync(topic, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return order;
        }
    }
}
