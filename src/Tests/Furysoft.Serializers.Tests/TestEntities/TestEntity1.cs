// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEntity1.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Tests.TestEntities
{
    using System.Runtime.Serialization;
    using ProtoBuf;

    /// <summary>
    /// The Test Entity 1.
    /// </summary>
    [DataContract]
    [ProtoContract]
    public sealed class TestEntity1
    {
        /// <summary>
        /// Gets or sets the value1.
        /// </summary>
        [DataMember(Order = 1)]
        [ProtoMember(1)]
        public string Value1 { get; set; }

        /// <summary>
        /// Gets or sets the value2.
        /// </summary>
        [DataMember(Order = 2)]
        [ProtoMember(2)]
        public int Value2 { get; set; }
    }
}