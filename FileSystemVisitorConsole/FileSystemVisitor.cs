using System;
using System.IO;
using System.Linq;

namespace FileSystemVisitorConsole
{ 
    internal class FileSystemVisitor
    {
        private readonly Func<VisitorSystemInfoList, VisitorSystemInfoList> _filterAction;
        private readonly string _filePath;
        public EventHandler StageNotificationEvent;
        public EventHandler FoundFileEvent;
        public EventHandler FailedFindEvent;

        public FileSystemVisitor(string path) => _filePath = path;

        public FileSystemVisitor(string path, Func<VisitorSystemInfoList, VisitorSystemInfoList> filterAction = null)
        {
            _filePath = path;
            _filterAction = filterAction;
        }
        public void ShowFilesInPredefinedFolder()
        {
            StageNotificationEvent.Invoke(this, EventArgs.Empty);
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(_filePath);
                VisitorSystemInfoList files = new VisitorSystemInfoList(fileList.GetFiles());

                if (_filterAction != null)
                {
                    Console.WriteLine("Let's search for a specific file in the specified folder. ");
                    files = _filterAction(files);
                    if (files.Count() > 0)
                    {
                        foreach (FileInfo file in files)
                        {
                            Console.WriteLine(string.Concat("File: ", file.Name));
                        }
                    }
                    else
                        Console.WriteLine("No file is found.");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ShowFoldersInPredefinedFolder()
        {
            StageNotificationEvent.Invoke(this, EventArgs.Empty);
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(_filePath);
                VisitorSystemInfoList dirs = new VisitorSystemInfoList(fileList.GetDirectories());

                if (_filterAction != null)
                {

                    Console.WriteLine("Let's search for a specific folder in the specified folder: ");
                    dirs = _filterAction(dirs);
                    if (dirs.Count() > 0)
                    {
                        foreach (DirectoryInfo dir in dirs)
                        {
                            Console.WriteLine(string.Concat("Directory: ", dir.Name));
                        }
                    }
                    else
                        Console.WriteLine("No folder is found.");
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ShowFolderContent()
        {
            StageNotificationEvent.Invoke(this, EventArgs.Empty);
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

        public void SearchFileInFolderTree()
        {
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
                            Console.WriteLine(string.Concat("File found: ", file.FullName));
                        }
                        // event done
                    }
                    else
                    {
                        //event not found
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
