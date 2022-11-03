using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystemVisitorConsole
{
    public class FileSystemVisitor
    {
        private readonly Func<VisitorSystemInfoList, VisitorSystemInfoList> _filterAction;
        private readonly string _filePath;
        public EventHandler StageNotificationEvent;
        public EventHandler FoundFileEvent;
        public EventHandler FailedFindEvent;

        public FileSystemVisitor(string path, Func<VisitorSystemInfoList, VisitorSystemInfoList> filterAction = null)
        {
            _filePath = path;
            _filterAction = filterAction;
        }

        public List <string> ReturnFolderContent()
        {
            List <string> content = new List<string> ();    
            //StageNotificationEvent.Invoke(this, EventArgs.Empty);
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(_filePath);
                VisitorSystemInfoList files = new VisitorSystemInfoList(fileList.GetFiles());
                VisitorSystemInfoList dirs = new VisitorSystemInfoList(fileList.GetDirectories());

                foreach (FileInfo file in files)
                {
                    content.Add(file.FullName);
                }

                foreach (DirectoryInfo dir in dirs)
                {
                    content.Add(dir.FullName);
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
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return content; 
        }

        public void DisplayContent(List<string> content)
        {
            foreach (string file in content)
            {
                Console.WriteLine(file);
            }
        }

        public List<string> SearchFileInFolderTree()
        {
            List<string> content = new List<string>();
            StageNotificationEvent.Invoke(this, EventArgs.Empty);
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(_filePath);
                VisitorSystemInfoList files = new VisitorSystemInfoList();
                GetFileFromDirectory(fileList, files);

                if (_filterAction != null)
                {
                    files = _filterAction(files);
                    if (files.Count() > 0)
                    {
                        foreach (FileInfo file in files)
                        {
                            content.Add(file.FullName);
                        }
                        FoundFileEvent.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        FailedFindEvent.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    Console.WriteLine("No filter criteria.");
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
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return content;
        }

        private void GetFileFromDirectory(DirectoryInfo directoryInfo, VisitorSystemInfoList files)
        {
            try
            {
                foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                {
                    GetFileFromDirectory(directory, files);
                }
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            files.AddRange(directoryInfo.GetFiles());
        }
    }
}
