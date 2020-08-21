// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProtocolBufferSerializerTests.cs" company="Simon Paramore">
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
    using Newtonsoft.Json;
    using NUnit.Framework;

    /// <summary>
    /// The Protocol Buffer Serializer Tests.
    /// </summary>
    [TestFixture]
    public sealed class ProtocolBufferSerializerTests : TestBase
    {
        /// <summary>
        /// Serializes to byte array when using byte array expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToByteArray_WhenUsingByteArray_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(true);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToByteArray = protocolBufferSerializer.SerializeToByteArray(testEntity);

            Console.WriteLine(JsonConvert.SerializeObject(serializeToByteArray));

            var deserializeFromByteArray = protocolBufferSerializer.DeserializeFromByteArray<TestEntity>(serializeToByteArray);

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }

        /// <summary>
        /// Serializes to byte array when using byte array with type expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToByteArray_WhenUsingByteArrayWithType_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(true);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToByteArray = protocolBufferSerializer.SerializeToByteArray(testEntity, typeof(TestEntity));

            Console.WriteLine(JsonConvert.SerializeObject(serializeToByteArray));

            var deserializeFromByteArray = protocolBufferSerializer.DeserializeFromByteArray(serializeToByteArray, typeof(TestEntity));

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }

        /// <summary>
        /// Serializes to byte array when using stream expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToStream_WhenUsingStream_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(true);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToStream = protocolBufferSerializer.SerializeToStream(testEntity);

            Console.WriteLine($"Length: {serializeToStream.Length}");

            var deserializeFromByteArray = protocolBufferSerializer.DeserializeFromStream<TestEntity>(serializeToStream);

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }

        /// <summary>
        /// Serializes to stream when using stream with type expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToStream_WhenUsingStreamWithType_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(true);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToStream = protocolBufferSerializer.SerializeToStream(testEntity, typeof(TestEntity));

            Console.WriteLine($"Length: {serializeToStream.Length}");

            var deserializeFromByteArray = protocolBufferSerializer.DeserializeFromStream(serializeToStream, typeof(TestEntity));

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }

        /// <summary>
        /// Serializes to string when date time expect serialize and deserialize.
        /// </summary>
        [Test]
        public void SerializeToString_WhenDateTime_ExpectSerializeAndDeserialize()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(true);

            var testEntity = new TestEntity2
            {
                Value1 = new DateTime(2018, 1, 1),
                Value2 = 2.53m,
            };

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToString = protocolBufferSerializer.SerializeToString(testEntity, typeof(TestEntity2));

            var deserializeFromByteArray = protocolBufferSerializer.DeserializeFromString<TestEntity2>(serializeToString);

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(deserializeFromByteArray.Value1, Is.EqualTo(new DateTime(2018, 1, 1)));
            Assert.That(deserializeFromByteArray.Value2, Is.EqualTo(2.53m));
        }

        /// <summary>
        /// Serializes to string when using string expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToString_WhenUsingString_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(true);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToString = protocolBufferSerializer.SerializeToString(testEntity);

            Console.WriteLine(JsonConvert.SerializeObject(serializeToString));

            var deserializeFromByteArray = protocolBufferSerializer.DeserializeFromString<TestEntity>(serializeToString);

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }

        /// <summary>
        /// Serializes to string when using string with type expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToString_WhenUsingStringWithType_ExpectDeserializeCorrect()
        {
            // Arrange
            var protocolBufferSerializer = new ProtocolBufferSerializer(true);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToString = protocolBufferSerializer.SerializeToString(testEntity, typeof(TestEntity));

            Console.WriteLine(JsonConvert.SerializeObject(serializeToString));

            var deserializeFromByteArray = protocolBufferSerializer.DeserializeFromString(serializeToString, typeof(TestEntity));

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }
    }
}