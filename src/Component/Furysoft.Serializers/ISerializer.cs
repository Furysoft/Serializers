// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISerializer.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers
{
    using System;
    using System.IO;

    /// <summary>
    /// The Serializer Interface.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Deserializes the specified data.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>The TType.</returns>
        TType DeserializeFromByteArray<TType>(byte[] data);

        /// <summary>
        /// Deserializes from byte array.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <returns>The Deserialized Object.</returns>
        object DeserializeFromByteArray(byte[] data, Type type);

        /// <summary>
        /// Deserializes from stream.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>The TType.</returns>
        TType DeserializeFromStream<TType>(Stream data);

        /// <summary>
        /// Deserializes from stream.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <returns>The Deserialized Object.</returns>
        object DeserializeFromStream(Stream data, Type type);

        /// <summary>
        /// Deserializes the specified data.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>The TType.</returns>
        TType DeserializeFromString<TType>(string data);

        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <returns>The Deserialized Object.</returns>
        object DeserializeFromString(string data, Type type);

        /// <summary>
        /// Serializes the asynchronous.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="content">The content.</param>
        /// <returns>
        /// The Serialized Data.
        /// </returns>
        byte[] SerializeToByteArray<TType>(TType content);

        /// <summary>
        /// Serializes to byte array.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The Serialized Data.
        /// </returns>
        byte[] SerializeToByteArray(object content, Type type);

        /// <summary>
        /// Serializes to stream.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="content">The content.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        Stream SerializeToStream<TType>(TType content);

        /// <summary>
        /// Serializes to stream.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The Serialized Data.
        /// </returns>
        Stream SerializeToStream(object content, Type type);

        /// <summary>
        /// Serializes to string.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        /// <param name="content">The content.</param>
        /// <returns>
        /// The Serialized Data.
        /// </returns>
        string SerializeToString<TType>(TType content);

        /// <summary>
        /// Serializes to string.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        /// The Serialized Data.
        /// </returns>
        string SerializeToString(object content, Type type);
    }
}