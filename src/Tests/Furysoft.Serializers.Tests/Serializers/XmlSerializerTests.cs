// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlSerializerTests.cs" company="Simon Paramore">
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
    /// The XML Serializer Tests.
    /// </summary>
    /// <seealso cref="TestBase" />
    [TestFixture]
    public sealed class XmlSerializerTests : TestBase
    {
        /// <summary>
        /// Serializes to byte array when using byte array expect deserialize correct.
        /// </summary>
        [Test]
        public void SerializeToByteArray_WhenUsingByteArray_ExpectDeserializeCorrect()
        {
            // Arrange
            var xmlSerializer = new XmlSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToByteArray = xmlSerializer.SerializeToByteArray(testEntity);

            Console.WriteLine(JsonConvert.SerializeObject(serializeToByteArray));

            var deserializeFromByteArray = xmlSerializer.DeserializeFromByteArray<TestEntity>(serializeToByteArray);

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
            var xmlSerializer = new XmlSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToByteArray = xmlSerializer.SerializeToByteArray(testEntity, typeof(TestEntity));

            Console.WriteLine(JsonConvert.SerializeObject(serializeToByteArray));

            var deserializeFromByteArray = xmlSerializer.DeserializeFromByteArray(serializeToByteArray, typeof(TestEntity));

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
            var xmlSerializer = new XmlSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToStream = xmlSerializer.SerializeToStream(testEntity);

            Console.WriteLine($"Length: {serializeToStream.Length}");

            var deserializeFromByteArray = xmlSerializer.DeserializeFromStream<TestEntity>(serializeToStream);

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
            var xmlSerializer = new XmlSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToStream = xmlSerializer.SerializeToStream(testEntity, typeof(TestEntity));

            Console.WriteLine($"Length: {serializeToStream.Length}");

            var deserializeFromByteArray = xmlSerializer.DeserializeFromStream(serializeToStream, typeof(TestEntity));

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
            var xmlSerializer = new XmlSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToString = xmlSerializer.SerializeToString(testEntity);

            Console.WriteLine(JsonConvert.SerializeObject(serializeToString));

            var deserializeFromByteArray = xmlSerializer.DeserializeFromString<TestEntity>(serializeToString);

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
            var xmlSerializer = new XmlSerializer(false);

            var testEntity = TestHelper.GetDefaultTestEntity;

            // Act
            var stopwatch = Stopwatch.StartNew();
            var serializeToString = xmlSerializer.SerializeToString(testEntity, typeof(TestEntity));

            Console.WriteLine(JsonConvert.SerializeObject(serializeToString));

            var deserializeFromByteArray = xmlSerializer.DeserializeFromString(serializeToString, typeof(TestEntity));

            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            deserializeFromByteArray.AssertEqualsDefault();
        }
    }
}