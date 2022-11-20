// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using log;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:42000",
    GroupId = "group",
    AutoOffsetReset = AutoOffsetReset.Latest,
    SecurityProtocol = SecurityProtocol.Plaintext
};

var schemaRegistryConfig = new SchemaRegistryConfig
{
    Url = "http://localhost:42200"
};

using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

using (var consumer = new ConsumerBuilder<string, KafkaMessage>(config)
        .SetValueDeserializer(new AvroDeserializer<KafkaMessage>(schemaRegistry).AsSyncOverAsync())
        .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
        .Build())
{
    consumer.Subscribe(new string[] { "test" });

    var cancelled = false;
    while (!cancelled)
    {
        var consumeResult = consumer.Consume();

        Console.WriteLine(consumeResult.Offset);
        Console.WriteLine(JsonConvert.SerializeObject(consumeResult.Message.Value));

        consumer.Commit(consumeResult);
    }

    consumer.Close();
}