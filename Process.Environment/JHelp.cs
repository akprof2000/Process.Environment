using Newtonsoft.Json;
using System;
using System.IO;

namespace Process.Environment
{
    /// <summary>
    /// extension methods for JSON
    /// </summary>
    public static class JHelp
    {

        /// <summary>
        /// From json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="tp">The type.</param>
        /// <returns>Object after convert from string </returns>
        public static object FromJson(this string value, Type tp)
        {
            try
            {
                return JsonConvert.DeserializeObject(value, tp);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// From json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Chose type value after convert from string</returns>
        public static T FromJson<T>(this string value)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch
            {
                return default;
            }
        }


        /// <summary>
        /// Froms the json automatic.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="tp">The tp.</param>
        /// <returns>Object after convert from string</returns>
        public static object FromJsonAuto(this string value, Type tp)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            try
            {
                return JsonConvert.DeserializeObject(value, tp, settings);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Froms the json automatic.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Chose type value after convert from string</returns>
        public static T FromJsonAuto<T>(this string value)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            try
            {
                return JsonConvert.DeserializeObject<T>(value, settings);
            }
            catch
            {
                return default;
            }
        }


        /// <summary>
        /// Froms the json all.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="tp">The tp.</param>
        /// <returns>Object after convert from string</returns>
        public static object FromJsonAll(this string value, Type tp)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            try
            {
                return JsonConvert.DeserializeObject(value, tp, settings);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Froms the json all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Chose type value after convert from string</returns>
        public static T FromJsonAll<T>(this string value)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            try
            {
                return JsonConvert.DeserializeObject<T>(value, settings);
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// Converts to json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string from object</returns>
        public static string ToJson(this object value)
        {
            return ToJson(value, false);
        }


        /// <summary>
        /// Converts to json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="formating">if set to <c>true</c> [formating].</param>
        /// <returns>string from object</returns>
        public static string ToJson(this object value, bool formating)
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(value, formating ? Formatting.Indented : Formatting.None, settings);
        }

        /// <summary>
        /// Converts to json auto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string from object</returns>
        public static string ToJsonAuto(this object value)
        {
            return ToJsonAuto(value, false);
        }


        /// <summary>
        /// Converts to json auto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="formating">if set to <c>true</c> [formating].</param>
        /// <returns>string from object</returns>
        public static string ToJsonAuto(this object value, bool formating)
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(value, formating ? Formatting.Indented : Formatting.None, settings);
        }

        /// <summary>
        /// Converts to json all.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string from object</returns>
        public static string ToJsonAll(this object value)
        {
            return ToJsonAll(value, false);
        }


        /// <summary>
        /// Converts to json all.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="formating">if set to <c>true</c> [formating].</param>
        /// <returns>string from object</returns>
        public static string ToJsonAll(this object value, bool formating)
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(value, formating ? Formatting.Indented : Formatting.None, settings);
        }

        /// <summary>
        /// Memories the stream to json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string from object</returns>
        public static string MemoryStreamToJson(this MemoryStream value)
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            var bytes = value.ToArray();
            return JsonConvert.SerializeObject(bytes, Formatting.Indented, settings);


        }

        /// <summary>
        /// Memories the stream from json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string from object</returns>
        public static object MemoryStreamFromJson(this string value)
        {
            try
            {
                return JsonConvert.DeserializeObject<byte[]>(value);
            }
            catch
            {
                return null;
            }
        }



    }

}
