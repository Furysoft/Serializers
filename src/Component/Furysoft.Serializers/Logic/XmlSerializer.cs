// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlSerializer.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Logic
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>
    /// The XML Serializer
    /// </summary>
    /// <seealso cref="Furysoft.Serializers.ISerializer" />
    public sealed class XmlSerializer : ISerializer
    {
        /// <summary>
        /// The encode as base64
        /// </summary>
        private readonly bool encodeAsBase64;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerializer"/> class.
        /// </summary>
        /// <param name="encodeAsBase64">if set to <c>true</c> [encode as base64].</param>
        internal XmlSerializer(bool encodeAsBase64)
        {
            this.encodeAsBase64 = encodeAsBase64;
        }

        /// <summary>
        /// Deserializes the specified data.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>
        /// The TType
        /// </returns>
        public TType DeserializeFromByteArray<TType>(byte[] data)
        {
            using (var stream = GetAsStream(data))
            {
                return this.DeserializeFromStream<TType>(stream);
            }
        }

        /// <inheritdoc />
        public object DeserializeFromByteArray(byte[] data, Type type)
        {
            using (var stream = GetAsStream(data))
            {
                return this.DeserializeFromStream(stream, type);
            }
        }

        /// <inheritdoc />
        public TType DeserializeFromStream<TType>(Stream data)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(TType));
            var readObject = dataContractSerializer.ReadObject(data);

            return (TType)readObject;
        }

        /// <inheritdoc />
        public object DeserializeFromStream(Stream data, Type type)
        {
            var dataContractSerializer = new DataContractSerializer(type);
            var readObject = dataContractSerializer.ReadObject(data);

            return readObject;
        }

        /// <inheritdoc />
        public TType DeserializeFromString<TType>(string data)
        {
            var serialized = this.encodeAsBase64 ? data.DecodeBase64ToString() : data;
            using (var stream = GetAsStream(serialized))
            {
                return this.DeserializeFromStream<TType>(stream);
            }
        }

        /// <inheritdoc />
        public object DeserializeFromString(string data, Type type)
        {
            var serialized = this.encodeAsBase64 ? data.DecodeBase64ToString() : data;
            using (var stream = GetAsStream(serialized))
            {
                return this.DeserializeFromStream(stream, type);
            }
        }

        /// <inheritdoc />
        public byte[] SerializeToByteArray<TType>(TType content)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(TType));

            using (var ms = new MemoryStream())
            {
                dataContractSerializer.WriteObject(ms, content);
                ms.Flush();

                return ms.ToArray();
            }
        }

        /// <inheritdoc />
        public byte[] SerializeToByteArray(object content, Type type)
        {
            var dataContractSerializer = new DataContractSerializer(type);

            using (var ms = new MemoryStream())
            {
                dataContractSerializer.WriteObject(ms, content);
                ms.Flush();

                return ms.ToArray();
            }
        }

        /// <inheritdoc />
        public Stream SerializeToStream<TType>(TType content)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(TType));

            var ms = new MemoryStream();
            dataContractSerializer.WriteObject(ms, content);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        /// <inheritdoc />
        public Stream SerializeToStream(object content, Type type)
        {
            var dataContractSerializer = new DataContractSerializer(type);

            var ms = new MemoryStream();
            dataContractSerializer.WriteObject(ms, content);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        /// <inheritdoc />
        public string SerializeToString<TType>(TType content)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(TType));

            string rtn;
            using (var ms = new MemoryStream())
            using (var sr = new StreamReader(ms))
            {
                dataContractSerializer.WriteObject(ms, content);
                ms.Flush();
                ms.Position = 0;

                rtn = sr.ReadToEnd();
            }

            return this.encodeAsBase64 ? rtn.ToBase64String() : rtn;
        }

        /// <inheritdoc />
        public string SerializeToString(object content, Type type)
        {
            var dataContractSerializer = new DataContractSerializer(type);

            string rtn;
            using (var ms = new MemoryStream())
            using (var sr = new StreamReader(ms))
            {
                dataContractSerializer.WriteObject(ms, content);
                ms.Flush();
                ms.Position = 0;

                rtn = sr.ReadToEnd();
            }

            return this.encodeAsBase64 ? rtn.ToBase64String() : rtn;
        }

        /// <summary>
        /// Gets as stream.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The <see cref="Stream"/></returns>
        private static Stream GetAsStream(string data)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(data);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Gets as stream.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The <see cref="Stream"/></returns>
        private static Stream GetAsStream(byte[] data)
        {
            var ms = new MemoryStream();

            ms.Write(data, 0, data.Length);
            ms.Flush();
            ms.Position = 0;

            return ms;
        }
    }
}