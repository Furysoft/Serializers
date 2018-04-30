// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerType.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Entities
{
    /// <summary>
    /// The Serializer Type
    /// </summary>
    public enum SerializerType
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The XML
        /// </summary>
        Xml = 1,

        /// <summary>
        /// The json
        /// </summary>
        Json = 2,

        /// <summary>
        /// The protocol buffers
        /// </summary>
        ProtocolBuffers = 3
    }
}