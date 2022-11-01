using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitorConsole
{
    internal class FileSystemVisitor
    {
        private readonly Func<VisitorSystemInfoList, VisitorSystemInfoList> _filterAction;
        private readonly string _filePath;

        public FileSystemVisitor(string path) => _filePath = path;

        public FileSystemVisitor(string path, Func<VisitorSystemInfoList, VisitorSystemInfoList> filterAction = null)
        {
            _filePath = path;
            _filterAction = filterAction; 
        }
        public void ShowFilesInPredefinedFolder()
        {
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(_filePath);
                VisitorSystemInfoList files = new VisitorSystemInfoList(fileList.GetFiles());
                VisitorSystemInfoList dirs = new VisitorSystemInfoList(fileList.GetDirectories());

                if (_filterAction != null)
                {
                    Console.WriteLine("Let's search for a specific file in the specified folder: ");
                    files = _filterAction(files);
                    Console.WriteLine("Let's search for a specific folder in the specified folder: ");
                    dirs = _filterAction(dirs);
                }

                foreach (FileInfo file in files)
                {
                    Console.WriteLine(string.Concat("File: ", file.Name));
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

        public void ShowFolderContent()
        {
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(_filePath);
                VisitorSystemInfoList files = new VisitorSystemInfoList(fileList.GetFiles());
                VisitorSystemInfoList dirs = new VisitorSystemInfoList(fileList.GetDirectories());

                foreach (FileInfo file in files)
                {
                    Console.WriteLine(string.Concat("File: ", file.Name));
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
