﻿namespace GuessTheNumber.Kafka
{
    using System;
    using System.Text;
    using Confluent.Kafka;
    using Newtonsoft.Json;

    public sealed class KafkaSerializer<T> : ISerializer<T>, IDeserializer<T>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
            {
                if (data.Length > 0)
                    throw new ArgumentException("The data is null not null.");
                return default;
            }

            if (typeof(T) == typeof(Ignore))
                return default;

            var dataJson = Encoding.UTF8.GetString(data);

            return JsonConvert.DeserializeObject<T>(dataJson);
        }

        public byte[] Serialize(T data, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
            {
                return null;
            }

            if (typeof(T) == typeof(Ignore))
            {
                throw new NotSupportedException("Not Supported.");
            }

            var json = JsonConvert.SerializeObject(data);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}