using System.IO;

namespace NDC.Common
{
    public static class MainSettings
    {
        /// <summary>
        ///     http://stackoverflow.com/questions/1222190/what-is-the-best-way-to-get-the-executing-exes-path-in-net
        /// </summary>
        public static string CurrentDirectory
        {
            get { return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin"); }
        }
    }
}