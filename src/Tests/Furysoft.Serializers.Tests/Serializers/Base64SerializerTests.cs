// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Base64SerializerTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Tests.Serializers
{
    using System;
    using System.Diagnostics;
    using Furysoft.Serializers.Logic;
    using Furysoft.Serializers.Tests.Helpers;
    using Furysoft.Serializers.Tests.TestEntities;
    using NUnit.Framework;

    /// <summary>
    /// The Base 64 Serializer Tests.
    /// </summary>
    /// <seealso cref="TestBase" />
    [TestFixture]
    public sealed class Base64SerializerTests : TestBase
    {
        /// <summary>
        /// To the base64 string when using byte array expect deserialize correct.
        /// </summary>
        [Test]
        public void ToBase64String_WhenUsingByteArray_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serialized = protocolBufferSerializer.SerializeToByteArray(testEntity);
            var base64String = serialized.ToBase64String();

            Console.WriteLine("\r\nBase 64 String:");
            Console.WriteLine(base64String);

            var protobufBytes = base64String.DecodeBase64ToBytes();
            var deserialized = protocolBufferSerializer.DeserializeFromByteArray<TestEntity>(protobufBytes);

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserialized.AssertEqualsDefault();
        }

        /// <summary>
        /// To the base64 string when using stream expect deserialize correct.
        /// </summary>
        [Test]
        public void ToBase64String_WhenUsingStream_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serialized = protocolBufferSerializer.SerializeToStream(testEntity);
            var base64String = serialized.ToBase64String();

            Console.WriteLine("\r\nBase 64 String:");
            Console.WriteLine(base64String);

            var protobufStream = base64String.DecodeBase64ToStream();
            var deserialized = protocolBufferSerializer.DeserializeFromStream<TestEntity>(protobufStream);

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserialized.AssertEqualsDefault();
        }

        /// <summary>
        /// Serializes to byte array when using byte array expect deserialize correct.
        /// </summary>
        [Test]
        public void ToBase64String_WhenUsingString_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(true);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serialized = protocolBufferSerializer.SerializeToString(testEntity);
            var base64String = serialized.ToBase64String();

            Console.WriteLine("Protobuf String:");
            Console.WriteLine(serialized);
            Console.WriteLine("\r\nBase 64 String:");
            Console.WriteLine(base64String);

            var protobufString = base64String.DecodeBase64ToString();
            var deserialized = protocolBufferSerializer.DeserializeFromString<TestEntity>(protobufString);

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserialized.AssertEqualsDefault();
        }
    }
}