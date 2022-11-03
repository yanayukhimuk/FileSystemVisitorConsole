using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSystemVisitorConsole
{
    public class VisitorSystemInfoList : IEnumerable<FileSystemInfo>
    {
        private List<FileSystemInfo> _fileSystemInfos;
        public VisitorSystemInfoList()
        {
            _fileSystemInfos = new List<FileSystemInfo>();
        }
        public VisitorSystemInfoList(FileSystemInfo[] fileSystemInfos)
        {
            _fileSystemInfos = fileSystemInfos.ToList();
        }

        public IEnumerator<FileSystemInfo> GetEnumerator()
        {
            foreach (FileSystemInfo info in _fileSystemInfos)
            {
                yield return info;
            }
        }

        public void AddRange(FileSystemInfo[] fileSystemInfos)
        {
            _fileSystemInfos.AddRange(fileSystemInfos);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
