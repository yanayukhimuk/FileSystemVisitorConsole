using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitorConsole
{
    internal class VisitorSystemInfoList : IEnumerable<FileSystemInfo>
    {
        private FileSystemInfo[] _fileSystemInfos;
        public VisitorSystemInfoList(FileSystemInfo[] fileSystemInfos)
        {
            _fileSystemInfos = fileSystemInfos;
        }

        public IEnumerator<FileSystemInfo> GetEnumerator()
        {
            foreach (FileSystemInfo info in _fileSystemInfos)
            {
                yield return info;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
