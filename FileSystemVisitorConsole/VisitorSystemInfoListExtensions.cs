using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace FileSystemVisitorConsole
{
    internal static class VisitorSystemInfoListExtensions
    {
        internal static VisitorSystemInfoList ToVisitorSystemInfoList(this IEnumerable<FileSystemInfo> inputList)
        {
            return new VisitorSystemInfoList(inputList.ToArray());    
        }
    }
}
