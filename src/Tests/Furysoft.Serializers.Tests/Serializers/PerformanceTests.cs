// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Tests.Serializers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using Helpers;
    using Logic;
    using NUnit.Framework;
    using TestEntities;
    using XmlSerializer = Logic.XmlSerializer;

    /// <summary>
    /// The Performance Tests
    /// </summary>
    [TestFixture]
#if !DEBUG
[Ignore("Perf Test")]
#endif
    public sealed class PerformanceTests : TestBase
    {
        /// <summary>
        /// Jsons the serializer performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void JsonSerializer_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;

            var serializeToStream = new List<Stream>();
            var serializeToByteArray = default(byte[]);
            var serializeToString = default(string);

            Console.WriteLine("JSON Tests\r\n******");

            var jsonSerializer = new JsonSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream.Add(jsonSerializer.SerializeToStream(testEntity));
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = jsonSerializer.SerializeToByteArray(testEntity);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = jsonSerializer.SerializeToString(testEntity);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream[0].Length}");
            sw.Restart();
            foreach (var stream in serializeToStream)
            {
                jsonSerializer.DeserializeFromStream<TestEntity>(stream);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                jsonSerializer.DeserializeFromByteArray<TestEntity>(serializeToByteArray);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                jsonSerializer.DeserializeFromString<TestEntity>(serializeToString);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// Jsons the serializer to base64 performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void JsonSerializer_ToBase64_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;

            var serializeToStream = new List<string>();
            var serializeToByteArray = default(string);
            var serializeToString = default(string);

            Console.WriteLine("JSON Tests\r\n******");

            var jsonSerializer = new JsonSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream.Add(jsonSerializer.SerializeToStream(testEntity).ToBase64String());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = jsonSerializer.SerializeToByteArray(testEntity).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = jsonSerializer.SerializeToString(testEntity).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream[0].Length}");
            sw.Restart();
            foreach (var stream in serializeToStream)
            {
                jsonSerializer.DeserializeFromStream<TestEntity>(stream.DecodeBase64ToStream());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                jsonSerializer.DeserializeFromByteArray<TestEntity>(serializeToByteArray.DecodeBase64ToBytes());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                jsonSerializer.DeserializeFromString<TestEntity>(serializeToString.DecodeBase64ToString());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// Jsons the serializer with type performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void JsonSerializerWithType_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;
            var type = typeof(TestEntity);

            var serializeToStream = new List<Stream>();
            var serializeToByteArray = default(byte[]);
            var serializeToString = default(string);

            Console.WriteLine("JSON Tests\r\n******");

            var jsonSerializer = new JsonSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream.Add(jsonSerializer.SerializeToStream(testEntity, type));
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = jsonSerializer.SerializeToByteArray(testEntity, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = jsonSerializer.SerializeToString(testEntity, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream[0].Length}");
            sw.Restart();
            foreach (var stream in serializeToStream)
            {
                jsonSerializer.DeserializeFromStream(stream, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                jsonSerializer.DeserializeFromByteArray(serializeToByteArray, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                jsonSerializer.DeserializeFromString(serializeToString, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// Jsons the serializer with type to base64 performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void JsonSerializerWithType_ToBase64_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;
            var type = typeof(TestEntity);

            var serializeToStream = new List<string>();
            var serializeToByteArray = default(string);
            var serializeToString = default(string);

            Console.WriteLine("JSON Tests\r\n******");

            var jsonSerializer = new JsonSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream.Add(jsonSerializer.SerializeToStream(testEntity, type).ToBase64String());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = jsonSerializer.SerializeToByteArray(testEntity, type).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = jsonSerializer.SerializeToString(testEntity, type).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream[0].Length}");
            sw.Restart();
            foreach (var stream in serializeToStream)
            {
                jsonSerializer.DeserializeFromStream(stream.DecodeBase64ToStream(), type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                jsonSerializer.DeserializeFromByteArray(serializeToByteArray.DecodeBase64ToBytes(), type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                jsonSerializer.DeserializeFromString(serializeToString.DecodeBase64ToString(), type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// Protocols the buffers serializer performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void ProtocolBuffersSerializer_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;

            var serializeToStream = new List<Stream>();
            var serializeToByteArray = default(byte[]);
            var serializeToString = default(string);

            Console.WriteLine("Protocol Buffers Tests\r\n******");

            var protocolBufferSerializer = new ProtocolBufferSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream.Add(protocolBufferSerializer.SerializeToStream(testEntity));
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = protocolBufferSerializer.SerializeToByteArray(testEntity);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = protocolBufferSerializer.SerializeToString(testEntity);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream[0].Length}");
            sw.Restart();
            foreach (var stream in serializeToStream)
            {
                protocolBufferSerializer.DeserializeFromStream<TestEntity>(stream);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                protocolBufferSerializer.DeserializeFromByteArray<TestEntity>(serializeToByteArray);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                protocolBufferSerializer.DeserializeFromString<TestEntity>(serializeToString);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// Protocols the buffers serializer to base64 performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void ProtocolBuffersSerializer_ToBase64_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;

            var serializeToStream = new List<string>();
            var serializeToByteArray = default(string);
            var serializeToString = default(string);

            Console.WriteLine("Protocol Buffers Tests\r\n******");

            var protocolBufferSerializer = new ProtocolBufferSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream.Add(protocolBufferSerializer.SerializeToStream(testEntity).ToBase64String());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = protocolBufferSerializer.SerializeToByteArray(testEntity).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = protocolBufferSerializer.SerializeToString(testEntity).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream[0].Length}");
            sw.Restart();
            foreach (var stream in serializeToStream)
            {
                protocolBufferSerializer.DeserializeFromStream<TestEntity>(stream.DecodeBase64ToStream());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                protocolBufferSerializer.DeserializeFromByteArray<TestEntity>(serializeToByteArray.DecodeBase64ToBytes());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                protocolBufferSerializer.DeserializeFromString<TestEntity>(serializeToString.DecodeBase64ToString());
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// Protocols the buffers serializer with type performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void ProtocolBuffersSerializerWithType_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;
            var type = typeof(TestEntity);

            var serializeToStream = new List<Stream>();
            var serializeToByteArray = default(byte[]);
            var serializeToString = default(string);

            Console.WriteLine("Protocol Buffers Tests\r\n******");

            var protocolBufferSerializer = new ProtocolBufferSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream.Add(protocolBufferSerializer.SerializeToStream(testEntity, type));
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = protocolBufferSerializer.SerializeToByteArray(testEntity, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = protocolBufferSerializer.SerializeToString(testEntity, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream[0].Length}");
            sw.Restart();
            foreach (var stream in serializeToStream)
            {
                protocolBufferSerializer.DeserializeFromStream(stream, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                protocolBufferSerializer.DeserializeFromByteArray(serializeToByteArray, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                protocolBufferSerializer.DeserializeFromString(serializeToString, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// Performances the test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void XmlSerializer_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;

            var serializeToStream = default(Stream);
            var serializeToByteArray = default(byte[]);
            var serializeToString = default(string);

            Console.WriteLine("XML Tests\r\n******");

            var xmlSerializer = new XmlSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream = xmlSerializer.SerializeToStream(testEntity);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = xmlSerializer.SerializeToByteArray(testEntity);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = xmlSerializer.SerializeToString(testEntity);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                xmlSerializer.DeserializeFromStream<TestEntity>(serializeToStream);
                serializeToStream.Position = 0;
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                xmlSerializer.DeserializeFromByteArray<TestEntity>(serializeToByteArray);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                xmlSerializer.DeserializeFromString<TestEntity>(serializeToString);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// XMLs the serializer with type performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void XmlSerializerWithType_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;
            var type = typeof(TestEntity);

            var serializeToStream = default(Stream);
            var serializeToByteArray = default(byte[]);
            var serializeToString = default(string);

            Console.WriteLine("XML Tests\r\n******");

            var xmlSerializer = new XmlSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream = xmlSerializer.SerializeToStream(testEntity, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = xmlSerializer.SerializeToByteArray(testEntity, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = xmlSerializer.SerializeToString(testEntity, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                xmlSerializer.DeserializeFromStream(serializeToStream, type);
                serializeToStream.Position = 0;
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                xmlSerializer.DeserializeFromByteArray(serializeToByteArray, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                xmlSerializer.DeserializeFromString(serializeToString, type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }

        /// <summary>
        /// XMLs the serializer with type to base64 performance test.
        /// </summary>
        [Test]
        [Repeat(2)]
        public void XmlSerializerWithType_ToBase64_PerformanceTest()
        {
            const int Iterations = 100000;
            var testEntity = TestHelper.GetDefaultTestEntity;
            var type = typeof(TestEntity);

            var serializeToStream = default(string);
            var serializeToByteArray = default(string);
            var serializeToString = default(string);

            Console.WriteLine("XML Tests\r\n******");

            var xmlSerializer = new XmlSerializer(false);

            /* Serialize Tests */
            Console.WriteLine("SerializeToStream");
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToStream = xmlSerializer.SerializeToStream(testEntity, type).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToByteArray");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToByteArray = xmlSerializer.SerializeToByteArray(testEntity, type).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("SerializeToString");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                serializeToString = xmlSerializer.SerializeToString(testEntity, type).ToBase64String();
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            /* De-serialize Tests */
            Console.WriteLine("DeserializeFromStream");
            Console.WriteLine($"Length: {serializeToStream.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                var stream = serializeToStream.DecodeBase64ToStream();
                xmlSerializer.DeserializeFromStream(stream, type);
                stream.Position = 0;
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromByteArray");
            Console.WriteLine($"Length: {serializeToByteArray.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                xmlSerializer.DeserializeFromByteArray(serializeToByteArray.DecodeBase64ToBytes(), type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine("DeserializeFromString");
            Console.WriteLine($"Length: {serializeToString.Length}");
            sw.Restart();
            for (var i = 0; i < Iterations; i++)
            {
                xmlSerializer.DeserializeFromString(serializeToString.DecodeBase64ToString(), type);
            }

            sw.Stop();
            Console.WriteLine($"Test time: {sw.ElapsedMilliseconds}ms\r\n-----");

            Console.WriteLine($"\r\n***---TestEnded---***\r\n");
        }
    }
}