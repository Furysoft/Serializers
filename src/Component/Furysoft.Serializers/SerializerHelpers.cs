// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelpers.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers
{
    using System;
    using System.IO;
    using Furysoft.Serializers.Entities;

    /// <summary>
    /// The Serializer Helpers.
    /// </summary>
    public static class SerializerHelpers
    {
        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>
        /// The TEntity.
        /// </returns>
        public static TEntity Deserialize<TEntity>(
            this Stream serializedData,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
            where TEntity : class
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.DeserializeFromStream<TEntity>(serializedData);
        }

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="type">The type.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>The Deserialized Object.</returns>
        public static object Deserialize(
            this Stream serializedData,
            Type type,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.DeserializeFromStream(serializedData, type);
        }

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>
        /// The TEntity.
        /// </returns>
        public static TEntity Deserialize<TEntity>(
            this string serializedData,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
            where TEntity : class
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.DeserializeFromString<TEntity>(serializedData);
        }

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="type">The type.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>The Deserialized Object.</returns>
        public static object Deserialize(
            this string serializedData,
            Type type,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.DeserializeFromString(serializedData, type);
        }

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>
        /// The TEntity.
        /// </returns>
        public static TEntity Deserialize<TEntity>(
            this byte[] serializedData,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
            where TEntity : class
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.DeserializeFromByteArray<TEntity>(serializedData);
        }

        /// <summary>
        /// Deserializes the specified type.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <param name="type">The type.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>The Deserialized Object.</returns>
        public static object Deserialize(
            this byte[] serializedData,
            Type type,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.DeserializeFromByteArray(serializedData, type);
        }

        /// <summary>
        /// Serializes to byte array.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>
        /// The <see cref="byte" />.
        /// </returns>
        public static byte[] SerializeToByteArray<TEntity>(
            this TEntity data,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
            where TEntity : class
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.SerializeToByteArray(data);
        }

        /// <summary>
        /// Serializes to byte array.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>
        /// The <see cref="byte" />.
        /// </returns>
        public static byte[] SerializeToByteArray(
            this object data,
            Type type,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.SerializeToByteArray(data, type);
        }

        /// <summary>
        /// Serializes to stream.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>
        /// The <see cref="Stream" />.
        /// </returns>
        public static Stream SerializeToStream<TEntity>(
            this TEntity data,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
            where TEntity : class
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.SerializeToStream(data);
        }

        /// <summary>
        /// Serializes to stream.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        public static Stream SerializeToStream(
            this object data,
            Type type,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.SerializeToStream(data, type);
        }

        /// <summary>
        /// Serializes to string.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>
        /// The serialized string.
        /// </returns>
        public static string SerializeToString<TEntity>(
            this TEntity data,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
            where TEntity : class
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.SerializeToString(data);
        }

        /// <summary>
        /// Serializes to string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        /// <returns>
        /// The serialized string.
        /// </returns>
        public static string SerializeToString(
            this object data,
            Type type,
            SerializerType serializerType = SerializerType.ProtocolBuffers)
        {
            var serializer = SerializerFactory.Create(serializerType);

            return serializer.SerializeToString(data, type);
        }
    }
}