// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestHelper.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using TestEntities;

    /// <summary>
    /// The Test Helper
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// Gets the default test entity.
        /// </summary>
        /// <returns>The <see cref="TestEntity"/></returns>
        public static TestEntity GetDefaultTestEntity => new TestEntity
        {
            SomeDictionary = new Dictionary<string, int>
            {
                { "Dictionary1", 1 },
                { "Dictionary2", 2 },
                { "Dictionary3", 3 },
            },
            SomeList = new List<string> { "List1", "List2" },
            SomeEntity = new TestEntity { SomeString = "SubString", SomeInt = 2 },
            SomeInt = 1,
            SomeString = "String",
            SomeDateTime = new DateTime(2018, 1, 1, 5, 23, 59)
        };

        /// <summary>
        /// Asserts the equal.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void AssertEqualsDefault(this TestEntity source)
        {
            Assert.NotNull(source);

            Assert.That(source.SomeInt, Is.EqualTo(1));
            Assert.That(source.SomeString, Is.EqualTo("String"));

            var list = source.SomeList.ToList();
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list[0], Is.EqualTo("List1"));
            Assert.That(list[1], Is.EqualTo("List2"));

            var dictionary = source.SomeDictionary;
            Assert.That(dictionary.Count, Is.EqualTo(3));
            Assert.That(dictionary["Dictionary1"], Is.EqualTo(1));
            Assert.That(dictionary["Dictionary2"], Is.EqualTo(2));
            Assert.That(dictionary["Dictionary3"], Is.EqualTo(3));

            var subEntity = source.SomeEntity;
            Assert.That(subEntity.SomeString, Is.EqualTo("SubString"));
            Assert.That(subEntity.SomeInt, Is.EqualTo(2));

            Assert.That(source.SomeDateTime, Is.EqualTo(new DateTime(2018, 1, 1, 5, 23, 59)));
        }

        /// <summary>
        /// Asserts the equals default.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void AssertEqualsDefault(this object source)
        {
            var cast = (TestEntity)source;
            cast.AssertEqualsDefault();
        }
    }
}