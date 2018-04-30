// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Base64Helpers.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers
{
    using System.IO;
    using System.Text;
    using JetBrains.Annotations;

    /// <summary>
    /// The Base 64 Helpers
    /// </summary>
    public static class Base64Helpers
    {
        /// <summary>
        /// Decodes the base64 to bytes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The Original <see cref="!:byte[]"/></returns>
        public static byte[] DecodeBase64ToBytes([NotNull] this string source)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(source);
            return base64EncodedBytes;
        }

        /// <summary>
        /// Decodes the base64 to stream.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The <see cref="Stream"/></returns>
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
        /// <returns>The Original String</returns>
        public static string DecodeBase64ToString([NotNull] this string source)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(source);
            return Encoding.GetEncoding("iso-8859-1").GetString(base64EncodedBytes);
        }

        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The base 64 encoded string</returns>
        public static string ToBase64String([NotNull] this string source)
        {
            var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(source);
            return System.Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The base 64 encoded string</returns>
        public static string ToBase64String([NotNull] this byte[] source)
        {
            return System.Convert.ToBase64String(source);
        }

        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The base 64 encoded string</returns>
        public static string ToBase64String([NotNull] this Stream source)
        {
            var readFully = ReadFully(source);

            return System.Convert.ToBase64String(readFully);
        }

        /// <summary>
        /// Reads the fully.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The <see cref="!:byte[]"/></returns>
        private static byte[] ReadFully(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }
    }
}