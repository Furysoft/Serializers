// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEntity.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Tests.TestEntities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using ProtoBuf;

    /// <summary>
    /// The Test Entity
    /// </summary>
    [DataContract]
    [Serializable]
    [ProtoContract]
    public sealed class TestEntity
    {
        /// <summary>
        /// Gets or sets some date time.
        /// </summary>
        [DataMember]
        [ProtoMember(6)]
        public DateTime SomeDateTime { get; set; }

        /// <summary>
        /// Gets or sets some dictionary.
        /// </summary>
        [DataMember]
        [ProtoMember(1)]
        public Dictionary<string, int> SomeDictionary { get; set; }

        /// <summary>
        /// Gets or sets some entity.
        /// </summary>
        [DataMember]
        [ProtoMember(2)]
        public TestEntity SomeEntity { get; set; }

        /// <summary>
        /// Gets or sets the sone int.
        /// </summary>
        [DataMember]
        [ProtoMember(3)]
        public int SomeInt { get; set; }

        /// <summary>
        /// Gets or sets some list.
        /// </summary>
        [DataMember]
        [ProtoMember(4)]
        public IEnumerable<string> SomeList { get; set; }

        /// <summary>
        /// Gets or sets some string.
        /// </summary>
        [DataMember]
        [ProtoMember(5)]
        public string SomeString { get; set; }
    }
}