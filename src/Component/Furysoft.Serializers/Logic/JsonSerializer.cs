// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializer.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Logic
{
    using System;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// The JSON Serializer
    /// </summary>
    public sealed class JsonSerializer : ISerializer
    {
        /// <summary>
        /// The encode as base64
        /// </summary>
        private readonly bool encodeAsBase64;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializer"/> class.
        /// </summary>
        /// <param name="encodeAsBase64">if set to <c>true</c> [encode as base64].</param>
        internal JsonSerializer(bool encodeAsBase64)
        {
            this.encodeAsBase64 = encodeAsBase64;
        }

        /// <inheritdoc />
        public TType DeserializeFromByteArray<TType>(byte[] data)
        {
            var decodedString = Encoding.UTF8.GetString(data);

            if (this.encodeAsBase64)
            {
                decodedString = decodedString.DecodeBase64ToString();
            }

            return JsonConvert.DeserializeObject<TType>(decodedString);
        }

        /// <inheritdoc />
        public object DeserializeFromByteArray(byte[] data, Type type)
        {
            var decodedString = Encoding.UTF8.GetString(data);

            if (this.encodeAsBase64)
            {
                decodedString = decodedString.DecodeBase64ToString();
            }

            return JsonConvert.DeserializeObject(decodedString, type);
        }

        /// <inheritdoc />
        public TType DeserializeFromStream<TType>(Stream data)
        {
            using (var sr = new StreamReader(data))
            {
                var stringData = sr.ReadToEnd();

                if (this.encodeAsBase64)
                {
                    stringData = stringData.DecodeBase64ToString();
                }

                return JsonConvert.DeserializeObject<TType>(stringData);
            }
        }

        /// <inheritdoc />
        public object DeserializeFromStream(Stream data, Type type)
        {
            using (var sr = new StreamReader(data))
            {
                var stringData = sr.ReadToEnd();

                if (this.encodeAsBase64)
                {
                    stringData = stringData.DecodeBase64ToString();
                }

                return JsonConvert.DeserializeObject(stringData, type);
            }
        }

        /// <inheritdoc />
        public TType DeserializeFromString<TType>(string data)
        {
            var serialized = this.encodeAsBase64 ? data.DecodeBase64ToString() : data;

            return JsonConvert.DeserializeObject<TType>(serialized);
        }

        /// <inheritdoc />
        public object DeserializeFromString(string data, Type type)
        {
            var serialized = this.encodeAsBase64 ? data.DecodeBase64ToString() : data;

            return JsonConvert.DeserializeObject(serialized, type);
        }

        /// <inheritdoc />
        public byte[] SerializeToByteArray<TType>(TType content)
        {
            var serializeObject = JsonConvert.SerializeObject(content);
            var base64 = this.encodeAsBase64 ? serializeObject.ToBase64String() : serializeObject;

            var bytes = Encoding.UTF8.GetBytes(base64);
            return bytes;
        }

        /// <inheritdoc />
        public byte[] SerializeToByteArray(object content, Type type)
        {
            var serializeObject = JsonConvert.SerializeObject(content);
            var base64 = this.encodeAsBase64 ? serializeObject.ToBase64String() : serializeObject;

            var bytes = Encoding.UTF8.GetBytes(base64);
            return bytes;
        }

        /// <inheritdoc />
        public Stream SerializeToStream<TType>(TType content)
        {
            var serializeObject = JsonConvert.SerializeObject(content);
            var base64 = this.encodeAsBase64 ? serializeObject.ToBase64String() : serializeObject;
            var ms = new MemoryStream();
            using (var sw = new StreamWriter(ms, Encoding.UTF8, 4096, true))
            {
                sw.Write(base64);
            }

            ms.Position = 0;
            return ms;
        }

        /// <inheritdoc />
        public Stream SerializeToStream(object content, Type type)
        {
            var serializeObject = JsonConvert.SerializeObject(content);
            var base64 = this.encodeAsBase64 ? serializeObject.ToBase64String() : serializeObject;
            var ms = new MemoryStream();
            using (var sw = new StreamWriter(ms, Encoding.UTF8, 4096, true))
            {
                sw.Write(base64);
            }

            ms.Position = 0;
            return ms;
        }

        /// <inheritdoc />
        public string SerializeToString<TType>(TType content)
        {
            var serialized = JsonConvert.SerializeObject(content);
            return this.encodeAsBase64 ? serialized.ToBase64String() : serialized;
        }

        /// <inheritdoc />
        public string SerializeToString(object content, Type type)
        {
            var serialized = JsonConvert.SerializeObject(content);
            return this.encodeAsBase64 ? serialized.ToBase64String() : serialized;
        }
    }
}