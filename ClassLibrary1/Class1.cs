using Avro.Specific;

namespace log
{
    public class Test2 : ISpecificRecord
    {
        public static Avro.Schema _SCHEMA = Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"Log\",\"namespace\":\"log\",\"fields\":[{\"name\":\"first\",\"type\":\"string\"},{\"name\":\"second\",\"type\":\"string\"}]}");
        public Avro.Schema Schema => _SCHEMA;

        private readonly List<KeyValuePair<string, object>> _data;

        public Test2(Dictionary<string, object> data)
        {
            _data = data.ToList();
        }

        public object Get(int fieldPos)
        {
            return _data[fieldPos].Value;
        }

        public void Put(int fieldPos, object fieldValue)
        {

        }
    }

    public class CommonFields : ISpecificRecord
    {
        public static Avro.Schema _SCHEMA = Avro.Schema.Parse("{\"name\":\"CommonFields\",\"type\":{\"type\":\"record\",\"name\":\"CommonField\",\"fields\":[{\"name\":\"firstCommonField\",\"type\":\"string\"}]}}");
        public Avro.Schema Schema => _SCHEMA;

        private readonly List<KeyValuePair<string, object>> _data;

        public CommonFields()
        {
            _data = new List<KeyValuePair<string, object>>();
        }

        public CommonFields(Dictionary<string, object> data)
        {
            _data = data.ToList();
        }

        public object Get(int fieldPos)
        {
            if (_data.Count <= fieldPos) return default;
            return _data[fieldPos].Value;
        }

        static int _varNum = 1;
        public void Put(int fieldPos, object fieldValue)
        {
            _data.Add(new KeyValuePair<string, object>($"field{_varNum++}", fieldValue));
        }
    }

    public class CommonField : ISpecificRecord
    {
        public static Avro.Schema _SCHEMA = Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"CommonField\",\"fields\":[{\"name\":\"firstCommonField\",\"type\":\"string\"}]}");
        public Avro.Schema Schema => _SCHEMA;

        private readonly List<KeyValuePair<string, object>> _data;

        public CommonField()
        {
            _data = new List<KeyValuePair<string, object>>();
        }

        public CommonField(Dictionary<string, object> data)
        {
            _data = data.ToList();
        }

        public object Get(int fieldPos)
        {
            if (_data.Count <= fieldPos) return default;
            return _data[fieldPos].Value;
        }

        static int _varNum = 1;
        public void Put(int fieldPos, object fieldValue)
        {
            _data.Add(new KeyValuePair<string, object>($"field{_varNum++}", fieldValue));
        }
    }

    public class CustomFields : ISpecificRecord
    {
        public static Avro.Schema _SCHEMA = Avro.Schema.Parse("{\"name\":\"CustomFields\",\"type\":{\"type\":\"record\",\"name\":\"CustomField\",\"fields\":[{\"name\":\"posLoggingKey\",\"type\":\"string\"},{\"name\":\"monitoringFields\",\"type\":{\"type\":\"map\",\"values\":[\"null\",\"string\",\"boolean\",\"int\"]}}]}}");
        public Avro.Schema Schema => _SCHEMA;

        private readonly List<KeyValuePair<string, object>> _data;

        public CustomFields()
        {
            _data = new List<KeyValuePair<string, object>>();
        }

        public CustomFields(Dictionary<string, object> data)
        {
            _data = data.ToList();
        }

        public object Get(int fieldPos)
        {
            if (_data.Count <= fieldPos) return default;
            return _data[fieldPos].Value;
        }

        static int _varNum = 1;
        public void Put(int fieldPos, object fieldValue)
        {
            _data.Add(new KeyValuePair<string, object>($"field{_varNum++}", fieldValue));
        }
    }

    public class CustomField : ISpecificRecord
    {
        public static Avro.Schema _SCHEMA = Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"CustomField\",\"fields\":[{\"name\":\"posLoggingKey\",\"type\":\"string\"},{\"name\":\"monitoringFields\",\"type\":{\"type\":\"map\",\"values\":[\"null\",\"string\",\"boolean\",\"int\"]}}]}");
        public Avro.Schema Schema => _SCHEMA;

        private readonly List<KeyValuePair<string, object>> _data;

        public CustomField()
        {
            _data = new List<KeyValuePair<string, object>>();
        }

        public CustomField(Dictionary<string, object> data)
        {
            _data = data.ToList();
        }

        public object Get(int fieldPos)
        {
            if (_data.Count <= fieldPos) return default;
            return _data[fieldPos].Value;
        }

        static int _varNum = 1;
        public void Put(int fieldPos, object fieldValue)
        {
            _data.Add(new KeyValuePair<string, object>($"field{_varNum++}", fieldValue));
        }
    }

    public class KafkaMessage : ISpecificRecord
    {
        public static Avro.Schema _SCHEMA = Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"Log\",\"namespace\":\"log\",\"fields\":[{\"name\":\"CommonFields\",\"type\":{\"type\":\"record\",\"name\":\"CommonField\",\"fields\":[{\"name\":\"firstCommonField\",\"type\":\"string\"}]}},{\"name\":\"CustomFields\",\"type\":{\"type\":\"record\",\"name\":\"CustomField\",\"fields\":[{\"name\":\"posLoggingKey\",\"type\":\"string\"},{\"name\":\"monitoringFields\",\"type\":{\"type\":\"map\",\"values\":[\"null\",\"string\",\"boolean\",\"int\"]}}]}}]}");
        public Avro.Schema Schema => _SCHEMA;

        private readonly List<KeyValuePair<string, object>> _data;

        public KafkaMessage()
        {
            _data = new List<KeyValuePair<string, object>>();
        }

        public KafkaMessage(Dictionary<string, object> data)
        {
            _data = data.ToList();
        }

        public object Get(int fieldPos)
        {
            if (_data.Count <= fieldPos) return default;
            return _data[fieldPos].Value;
        }

        static int _varNum = 1;
        public void Put(int fieldPos, object fieldValue)
        {
            _data.Add(new KeyValuePair<string, object>($"field{_varNum++}", fieldValue));
        }
    }
}