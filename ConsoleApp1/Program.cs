// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using log;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var config = new ProducerConfig
{
    BootstrapServers = "localhost:42000",
    SecurityProtocol = SecurityProtocol.Plaintext,
};

var message = () => new KafkaMessage(new Dictionary<string, object>()
{
    { "CommonFields", new CommonFields(new Dictionary<string, object>() { { "firstCommonField", Guid.NewGuid().ToString() } }) },
    { "CustomFields", new CustomFields(new Dictionary<string, object>() { { "posLoggingKey", Guid.NewGuid().ToString() }, { "monitoringFields", new Dictionary<string, object>() { { "fieldstring", Guid.NewGuid().ToString()} } } }) },
});

var secondMessage = () => new Test2(new Dictionary<string, object>() { { "first", "1" }, { "second", "2" } });

var schemaRegistryConfig = new SchemaRegistryConfig
{
    Url = "http://localhost:42200"
};

using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

using (var producer = new ProducerBuilder<string, KafkaMessage>(config)
                    .SetValueSerializer(new AvroSerializer<KafkaMessage>(schemaRegistry))
                    .Build())
{
    while (true)
    {
        var m = message();

        var id = Guid.NewGuid().ToString();
        Console.WriteLine(id);
        var result = await producer.ProduceAsync("test", new Message<string, KafkaMessage> { Key = "1", Value = m });
        producer.Flush();
        Console.WriteLine(JsonConvert.SerializeObject(result));
        await Task.Delay(1000);
    }
}
