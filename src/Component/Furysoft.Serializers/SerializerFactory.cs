// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerFactory.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers
{
    using System;
    using Furysoft.Serializers.Entities;
    using Furysoft.Serializers.Logic;

    /// <summary>
    /// The Serializer Factory.
    /// </summary>
    public static class SerializerFactory
    {
        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="base64Encode">if set to <c>true</c> [base64 encode].</param>
        /// <returns>
        /// The <see cref="ISerializer" />.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">type - null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">type is invalid.</exception>
        public static ISerializer Create(SerializerType type, bool base64Encode = false)
        {
            switch (type)
            {
                case SerializerType.Xml:
                    return new XmlSerializer(base64Encode);

                case SerializerType.Json:
                    return new JsonSerializer(base64Encode);

                case SerializerType.ProtocolBuffers:
                    return new ProtocolBufferSerializer(base64Encode);

                case SerializerType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}