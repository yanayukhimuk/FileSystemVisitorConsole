using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitorConsole
{
    internal class FileSystemVisitor
    {
        private Func<VisitorSystemInfoList, VisitorSystemInfoList> _filterAction;
        private string filePath;

        public FileSystemVisitor(string path) => filePath = path;

        public FileSystemVisitor(string path, Func<VisitorSystemInfoList, VisitorSystemInfoList> filterAction = null)
        {
            filePath = path;
            _filterAction = filterAction; 
        }
        public void ShowFilesInPredefinedFolder()
        {
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(filePath);
                VisitorSystemInfoList files = new VisitorSystemInfoList(fileList.GetFiles());
                VisitorSystemInfoList dirs = new VisitorSystemInfoList(fileList.GetDirectories());

                if (_filterAction != null)
                {
                    files = _filterAction(files);   
                }

                foreach (FileInfo file in files)
                {
                    Console.WriteLine(string.Concat("File: ", file.Name));
                }

                if (_filterAction != null)
                {
                    return;
                }

                foreach (DirectoryInfo dir in dirs)
                {
                    Console.WriteLine(string.Concat("Directory: ", dir.Name));
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message); 
            }
        }
    }
}
