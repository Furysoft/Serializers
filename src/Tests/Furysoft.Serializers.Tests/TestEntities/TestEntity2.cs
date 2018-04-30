// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEntity2.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Tests.TestEntities
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Test Entity 2
    /// </summary>
    [DataContract]
    public sealed class TestEntity2
    {
        /// <summary>
        /// Gets or sets the value1.
        /// </summary>
        [DataMember(Order = 1)]
        public DateTime Value1 { get; set; }

        /// <summary>
        /// Gets or sets the value2.
        /// </summary>
        [DataMember(Order = 2)]
        public decimal Value2 { get; set; }
    }
}