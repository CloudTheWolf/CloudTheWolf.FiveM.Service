using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTheWolf.FiveM.Service
{
    public class Options
    {
        /// <summary>
        /// Path to FXServer Executable
        /// </summary>
        public static string ExePath { get; set; }
        /// <summary>
        /// Name of FXServer.exe file
        /// </summary>
        public static string ExeName { get; set; }
        /// <summary>
        /// +set Arguments
        /// </summary>
        public static Dictionary<string,object>? ArgList { get; set; }
    }
}
