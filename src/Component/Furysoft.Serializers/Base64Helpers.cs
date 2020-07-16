// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Base64Helpers.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers
{
    using System;
    using System.IO;
    using JetBrains.Annotations;

    /// <summary>
    /// The Base 64 Helpers.
    /// </summary>
    public static class Base64Helpers
    {
        /// <summary>
        /// Decodes the base64 to bytes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The Original <see cref="!:byte[]"/>.</returns>
        public static byte[] DecodeBase64ToBytes([NotNull] this string source)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(source);
            return base64EncodedBytes;
        }

        /// <summary>
        /// Decodes the base64 to stream.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        public static Stream DecodeBase64ToStream([NotNull] this string source)
        {
            var bytes = source.DecodeBase64ToBytes();

            var memStream = new MemoryStream(bytes);
            return memStream;
        }

        /// <summary>
        /// From the base64 string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The Original String.</returns>
        public static string DecodeBase64ToString([NotNull] this string source)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(source);
            var s
                = System.Text.Encoding.UTF8.GetString(base64EncodedBytes, 0, base64EncodedBytes.Length);
            return s;
        }

        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The base 64 encoded string.</returns>
        public static string ToBase64String([NotNull] this string source)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(source);
            return System.Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The base 64 encoded string.</returns>
        public static string ToBase64String([NotNull] this byte[] source)
        {
            return System.Convert.ToBase64String(source);
        }

        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The base 64 encoded string.</returns>
        public static string ToBase64String([NotNull] this Stream source)
        {
            string rtn;

            using (var ms = new MemoryStream())
            {
                source.CopyTo(ms);
                ms.Position = 0;

                rtn = Convert.ToBase64String(ms.ToArray());
            }

            return rtn;
        }
    }
}