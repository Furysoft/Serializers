// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializerTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Tests.Serializers
{
    using System;
    using System.Diagnostics;
    using Furysoft.Serializers.Tests.Helpers;
    using Furysoft.Serializers.Tests.TestEntities;
    using Newtonsoft.Json;
    using NUnit.Framework;

    /// <summary>
    /// The JSON Serializer Tests.
    /// </summary>
    /// <seealso cref="TestBase" />
    [TestFixture]
    public sealed class JsonSerializerTests : TestBase
    {
        /// <summary>
        /// Serializes to byte array when using byte array expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToByteArray_WhenUsingByteArray_ExpectDeserializeCorrect()
        {
            // Arrange
            var jsonSerializer = new Logic.JsonSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToByteArray = jsonSerializer.SerializeToByteArray(testEntity);

            Console.WriteLine(JsonConvert.SerializeObject(serializeToByteArray));

            var deserializeFromByteArray = jsonSerializer.DeserializeFromByteArray<TestEntity>(serializeToByteArray);

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
            var jsonSerializer = new Logic.JsonSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToByteArray = jsonSerializer.SerializeToByteArray(testEntity, typeof(TestEntity));

            Console.WriteLine(JsonConvert.SerializeObject(serializeToByteArray));

            var deserializeFromByteArray = jsonSerializer.DeserializeFromByteArray(serializeToByteArray, typeof(TestEntity));

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
            var jsonSerializer = new Logic.JsonSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToStream = jsonSerializer.SerializeToStream(testEntity);

            Console.WriteLine($"Length: {serializeToStream.Length}");

            var deserializeFromByteArray = jsonSerializer.DeserializeFromStream<TestEntity>(serializeToStream);

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
            var jsonSerializer = new Logic.JsonSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToStream = jsonSerializer.SerializeToStream(testEntity, typeof(TestEntity));

            Console.WriteLine($"Length: {serializeToStream.Length}");

            var deserializeFromByteArray = jsonSerializer.DeserializeFromStream(serializeToStream, typeof(TestEntity));

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }

        /// <summary>
        /// Serializes to string when using string expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToString_WhenUsingString_ExpectDeserializeCorrect()
        {
            // Arrange
            var jsonSerializer = new Logic.JsonSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToString = jsonSerializer.SerializeToString(testEntity);

            Console.WriteLine(JsonConvert.SerializeObject(serializeToString));

            var deserializeFromByteArray = jsonSerializer.DeserializeFromString<TestEntity>(serializeToString);

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
            var jsonSerializer = new Logic.JsonSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToString = jsonSerializer.SerializeToString(testEntity, typeof(TestEntity));

            Console.WriteLine(JsonConvert.SerializeObject(serializeToString));

            var deserializeFromByteArray = jsonSerializer.DeserializeFromString(serializeToString, typeof(TestEntity));

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }
    }
}