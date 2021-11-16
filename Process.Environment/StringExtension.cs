using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Process.Environment
{
    /// <summary>
    ///
    /// </summary>

    public static class StringExtension
    {
        /// <summary>
        /// Determines whether [is null or whitespace].
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>
        /// <c>true</c> if [is null or whitespace] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrWhitespace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Determines whether [is null or whitespace].
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>
        /// <c>true</c> if [is null or empty] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        /// <summary>
        /// Splits the CSV.
        /// </summary>
        /// <param name="csvList">The CSV list.</param>
        /// <param name="nullOrWhitespaceInputReturnsNull">if set to <c>true</c> [null or whitespace input returns null].</param>
        /// <returns></returns>
        public static List<string> SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
            {
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();
            }

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable()
                .Select(s => s.Trim())
                .ToList();
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="def">The definition.</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this string data, T def)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(data))
                {
                    return def;
                }

                return (T)Convert.ChangeType(data, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (InvalidCastException)
            {
                return def;
            }
            catch (FormatException)
            {
                return def;
            }
            catch (OverflowException)
            {
                return def;
            }
            catch (ArgumentNullException)
            {
                return def;
            }
        }
        /// <summary>
        /// Converts to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this string data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(data))
                {
                    return default;
                }
                if ((typeof(T) == typeof(bool) || typeof(T) == typeof(bool?)) &&
                    decimal.TryParse(data, out decimal numericValue))
                {
                    return (T)Convert.ChangeType(numericValue != 0, typeof(T), CultureInfo.InvariantCulture);
                }
                return (T)Convert.ChangeType(data, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (InvalidCastException)
            {
                return default;
            }
            catch (FormatException)
            {
                return default;
            }
            catch (OverflowException)
            {
                return default;
            }
            catch (ArgumentNullException)
            {
                return default;
            }
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this object data)
        {
            try
            {
                if (data == null)
                {
                    return default;
                }

                return (T)Convert.ChangeType(data, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (InvalidCastException)
            {
                return default;
            }
            catch (FormatException)
            {
                return default;
            }
            catch (OverflowException)
            {
                return default;
            }
            catch (ArgumentNullException)
            {
                return default;
            }
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="def">The definition.</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this object data, T def)
        {
            try
            {
                if (data == null)
                {
                    return def;
                }

                if ((typeof(T) == typeof(bool) || typeof(T) == typeof(bool?)) &&
                    data is string @string && decimal.TryParse(@string, out decimal numericValue))
                {
                    return (T)Convert.ChangeType(numericValue != 0, typeof(T), CultureInfo.InvariantCulture);
                }

                return (T)Convert.ChangeType(data, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (InvalidCastException)
            {
                return def;
            }
            catch (FormatException)
            {
                return def;
            }
            catch (OverflowException)
            {
                return def;
            }
            catch (ArgumentNullException)
            {
                return def;
            }
        }


        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static object ConvertTo(this object data, string typeName)
        {
            try
            {
                if (typeName.IsNullOrEmpty())
                {
                    return data;
                }

                if (data == null)
                {
                    return null;
                }

                Type tp = Type.GetType($"system.{typeName}", false, true);
                if (tp == null)
                {
                    tp = Type.GetType(typeName, false, true);
                }

                if (tp != null)
                {
                    return Convert.ChangeType(data, tp, CultureInfo.InvariantCulture);
                }

                return data;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }


        /// <summary>
        /// Creates the hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string CreateHash(this string input)
        {

            using System.Security.Cryptography.SHA256 hash = System.Security.Cryptography.SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = hash.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2", CultureInfo.InvariantCulture));
            }
            return sb.ToString();
        }

    }

}
