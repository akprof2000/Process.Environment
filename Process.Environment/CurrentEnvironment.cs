using System;

namespace Process.Environment
{
    /// <summary>
    /// Current Environment for using in project
    /// </summary>
    public static class CurrentEnvironment
    {

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static string Container { get; } = System.Environment.GetEnvironmentVariable("CONTAINER_NAME")??System.Environment.MachineName;

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public static string UniqueID { get; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// Gets the unique identifier now.
        /// </summary>
        /// <value>
        /// The unique identifier now.
        /// </value>
        public static string UniqueIDNow => Guid.NewGuid().ToString("N");


    }
}
