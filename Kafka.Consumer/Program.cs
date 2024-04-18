using Confluent.Kafka;
using Kafka.Consumer;
using System.Text.Json;

public class Program
{
    static readonly string topic = "testtopic3";
    static readonly  string groupId = "KafkaExampleProducer";
    static readonly string bootstrapServers = "localhost:9092";

    static void Main(string[] args)
    {
        while (true)
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false,
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(topic);
            try
            {
                var result = consumer.Consume();
                var orderRequest = JsonSerializer.Deserialize<OrderRequest>(result.Message.Value);
                Console.WriteLine(orderRequest.ToString());
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }

        }
    }
}