// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Text;

Console.WriteLine("Hello, World!");

var schema = new Record()
{
    name = "Log",
    NameSpace = "log",
    fields = new Field[]
    {
        new RecordParent()
        {
            name = "CommonFields",
            type = new Record()
            {
                name = "CommonField",
                fields = new[]
                {
                    new Field() { name = "firstCommonField", type = "string" }
                }
            } 
        },
        new RecordParent()
        {
            name = "CustomFields",
            type = new Record()
            {
                name = "CustomField",
                fields = new[]
                {
                    new Field() { name = "posLoggingKey", type = "string" },
                    new Map() { name = "monitoringFields", type = new MapTypeUnion() { values = new[] { "null", "string", "boolean", "int" } }
                    }
                }
            } 
        }
    }
};

var second = new Record()
{
    name = "Log",
    NameSpace = "log",
    fields = new Field[]
    {
        new Field() { name = "first", type = "string" },
        new Field() { name = "second", type = "string" },
    }
};

//var schemastring = JsonConvert.SerializeObject(schema);
var schemastringsecond = JsonConvert.SerializeObject(second);

//Console.WriteLine(schemastring);
Console.WriteLine(schemastringsecond);

//var schemaobj = new Schema() { schema = schemastring };
var schemaobj = new Schema() { schema = schemastringsecond };

Console.WriteLine(JsonConvert.SerializeObject(schemaobj));

using (var client = new HttpClient())
{
    var response = await client.PostAsync(
        "http://localhost:42200/subjects/test2-value/versions",
         new StringContent(JsonConvert.SerializeObject(schemaobj), Encoding.UTF8, "application/json"));
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine(content);
}

Console.ReadLine();

class RecordParent : Field
{
    public new Record type { get; set; }
}

class Record : Field
{
    public string name { get; set; }
    public override string type { get; set; } = "record";
    [JsonProperty("namespace")]
    public string NameSpace { get; set; }
    public Field[] fields { get; set; }
}

class Map : Field
{
    public new MapType type { get; set; }
}

class MapType
{
    public string type { get; set; } = "map";
    public string[] values { get; set; } 
}

class MapTypeUnion : MapType
{
    public new string[] values { get; set; }
}

class Field
{
    public string name { get; set; }
    public virtual string type { get; set; }
}

class Schema
{
    public string schema { get; set; }
}