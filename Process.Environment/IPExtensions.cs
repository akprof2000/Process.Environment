using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace Process.Environment
{
    /// <summary>
    ///
    /// </summary>
    public static class IPExtensions
    {

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static string GetUserID(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(i => i.Type == "UserMail")?.Value;
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static string SID(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(i => i.Type == "SessionId")?.Value;
        }

        /// <summary>
        /// Gets the request ip.
        /// </summary>
        /// <param name="Request">The request.</param>
        /// <param name="tryUseXForwardHeader">if set to <c>true</c> [try use x forward header].</param>
        /// <returns></returns>
        /// <exception cref="Exception">Unable to determine caller's IP.</exception>
        public static string GetRequestIP(this HttpRequest Request, bool tryUseXForwardHeader = true)
        {
            if (Request == null)
            {
                return null;
            }

            string ip = null;


            if (tryUseXForwardHeader)
            {
                List<string> strs = GetHeaderValueAs<string>(Request, "X-Forwarded-For").SplitCsv();
                if (strs == null)
                {
                    return null;
                }

                if (strs.Count > 1 || (strs.Any() && !strs.Contains("127.0.0.1")))
                {
                    ip = string.Join(";", strs.Where(x => !x.Contains("127.0.0.1", StringComparison.OrdinalIgnoreCase)));
                }
            }


            if (ip.IsNullOrWhitespace() && Request?.HttpContext?.Connection?.RemoteIpAddress != null)
            {
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            }

            if (ip.IsNullOrWhitespace())
            {

                string ipt = Request?.HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
                if (!ipt.IsNullOrWhitespace() && (ip.IsNullOrWhitespace() || string.Compare(ip, ipt, true, CultureInfo.InvariantCulture) != 0))
                {
                    ip = ipt;
                }
            }

            if (ip.IsNullOrWhitespace())
            {
                string ipt = GetHeaderValueAs<string>(Request, "REMOTE_ADDR");
                if (!ipt.IsNullOrWhitespace() && (ip.IsNullOrWhitespace() || string.Compare(ip, ipt, true, CultureInfo.InvariantCulture) != 0))
                {
                    ip = ipt;
                }

            }
            return ip;
        }


        /// <summary>
        /// Gets the header value as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Request">The request.</param>
        /// <param name="headerName">Name of the header.</param>
        /// <returns></returns>
        private static T GetHeaderValueAs<T>(HttpRequest Request, string headerName)
        {
            StringValues values = "";

            if (Request?.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!rawValues.IsNullOrWhitespace())
                {
                    return (T)Convert.ChangeType(values.ToString(), typeof(T), CultureInfo.InvariantCulture);
                }
            }
            return default;
        }
    }

}
