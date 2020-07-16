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
            var decoded = Convert.FromBase64String(data);

            using (var ms = new MemoryStream(decoded))
            {
                var deserialize = Serializer.Deserialize<TType>(ms);

                return deserialize;
            }
        }

        /// <inheritdoc />
        public object DeserializeFromString(string data, Type type)
        {
            var decoded = Convert.FromBase64String(data);

            using (var ms = new MemoryStream(decoded))
            {
                var deserialize = Serializer.Deserialize(type, ms);

                return deserialize;
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
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, content);
                ms.Position = 0;

                var array = ms.ToArray();
                string rtn;

                rtn = Convert.ToBase64String(array, 0, array.Length);

                return rtn;
            }
        }

        /// <inheritdoc />
        public string SerializeToString(object content, Type type)
        {
            string rtn = null;

            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, content);
                ms.Position = 0;

                var tryGetBuffer = ms.TryGetBuffer(out var buff);

                if (tryGetBuffer)
                {
                    var bufferArray = buff.Array;

                    var s = tryGetBuffer
                            ? Convert.ToBase64String(bufferArray, 0, (int)ms.Length)
                            : string.Empty;
                    rtn = s;
                }

                return rtn ?? string.Empty;
            }
        }
    }
}