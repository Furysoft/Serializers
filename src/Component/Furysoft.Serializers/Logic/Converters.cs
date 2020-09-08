// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Converters.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Serializers.Logic
{
    using System.Linq;

    /// <summary>
    /// The Converters.
    /// </summary>
    public static class Converters
    {
        /// <summary>
        /// Converts the byte array to a string.
        /// </summary>
        /// <param name="source">The <see cref="source"/>.</param>
        /// <returns>The string.</returns>
        public static string ConvertToString(this byte[] source)
        {
            var chars = source.Select(b => (char)b).ToArray();
            return new string(chars);
        }

        /// <summary>
        /// Converts the byte array to binary.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The array of <see cref="byte"/>.</returns>
        public static byte[] ConvertToBinary(this string source)
        {
            return source.Select(c => (byte)c).ToArray();
        }
    }
}