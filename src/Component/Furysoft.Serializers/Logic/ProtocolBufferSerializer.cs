// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProtocolBufferSerializer.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Logic
{
    using System;
    using System.IO;
    using ProtoBuf;

    /// <summary>
    /// The Protocol Buffer Serializer.
    /// </summary>
    /// <seealso cref="ISerializer" />
    public sealed class ProtocolBufferSerializer : ISerializer
    {
        /// <summary>
        /// The encode as base64.
        /// </summary>
        private readonly bool encodeAsBase64;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolBufferSerializer"/> class.
        /// </summary>
        /// <param name="encodeAsBase64">if set to <c>true</c> [encode as base64].</param>
        internal ProtocolBufferSerializer(bool encodeAsBase64)
        {
            this.encodeAsBase64 = encodeAsBase64;
        }

        /// <inheritdoc />
        public TType DeserializeFromByteArray<TType>(byte[] data)
        {
            using (var ms = new MemoryStream())
            {
                ms.Write(data, 0, data.Length);
                ms.Flush();
                ms.Position = 0;

                return Serializer.Deserialize<TType>(ms);
            }
        }

        /// <inheritdoc />
        public object DeserializeFromByteArray(byte[] data, Type type)
        {
            using (var ms = new MemoryStream())
            {
                ms.Write(data, 0, data.Length);
                ms.Flush();
                ms.Position = 0;
                return Serializer.Deserialize(type, ms);
            }
        }

        /// <inheritdoc />
        public TType DeserializeFromStream<TType>(Stream data)
        {
            return Serializer.Deserialize<TType>(data);
        }

        /// <inheritdoc />
        public object DeserializeFromStream(Stream data, Type type)
        {
            return Serializer.Deserialize(type, data);
        }

        /// <inheritdoc />
        public TType DeserializeFromString<TType>(string data)
        {
            var serializedData = this.encodeAsBase64 ? data.DecodeBase64ToBytes() : data.ConvertToBinary();

            using (var ms = new MemoryStream(serializedData))
            {
                return Serializer.Deserialize<TType>(ms);
            }
        }

        /// <inheritdoc />
        public object DeserializeFromString(string data, Type type)
        {
            var serializedData = this.encodeAsBase64 ? data.DecodeBase64ToBytes() : data.ConvertToBinary();

            using (var ms = new MemoryStream(serializedData))
            {
                return Serializer.Deserialize(type, ms);
            }
        }

        /// <inheritdoc />
        public byte[] SerializeToByteArray<TType>(TType content)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, content);
                ms.Flush();
                return ms.ToArray();
            }
        }

        /// <inheritdoc />
        public byte[] SerializeToByteArray(object content, Type type)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, content);

                ms.Flush();

                return ms.ToArray();
            }
        }

        /// <inheritdoc />
        public Stream SerializeToStream<TType>(TType content)
        {
            var ms = new MemoryStream();
            Serializer.Serialize(ms, content);

            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        /// <inheritdoc />
        public Stream SerializeToStream(object content, Type type)
        {
            var ms = new MemoryStream();
            Serializer.Serialize(ms, content);

            ms.Flush();
            ms.Position = 0;

            return ms;
        }

        /// <inheritdoc />
        public string SerializeToString<TType>(TType content)
        {
            byte[] array;
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, content);

                array = ms.ToArray();
            }

            if (this.encodeAsBase64)
            {
                return array.ToBase64String();
            }

            return array.ConvertToString();
        }

        /// <inheritdoc />
        public string SerializeToString(object content, Type type)
        {
            byte[] array;
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, content);

                array = ms.ToArray();
            }

            if (this.encodeAsBase64)
            {
                return array.ToBase64String();
            }

            return array.ConvertToString();
        }
    }
}