using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitorConsole
{
    public class FileSystemVisitor
    {
        private string filePath;
        private string fileName;
        private bool shouldBeSorted;

        public FileSystemVisitor(string path) => filePath = path;

        public FileSystemVisitor(string path, string file)
        {
            filePath = path;
            fileName = file;
        }

        public FileSystemVisitor(string path, string file, bool sorted)
        {
            filePath = path;
            fileName = file;
            shouldBeSorted = sorted; 
        }
        public void ShowFilesInPredefinedFolder()
        {
            DirectoryInfo fileList = new DirectoryInfo(filePath);
            try
            {
                FileInfo[] files = fileList.GetFiles();
                DirectoryInfo[] dirs = fileList.GetDirectories();


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

        public void ShowFileInPredifinedFolder()
        {
            DirectoryInfo fileList = new DirectoryInfo(filePath);
            FileInfo[] files = fileList.GetFiles();
            try
            {
                foreach (FileInfo file in files)
                {
                    if (file.Name == fileName)
                    {
                        Console.WriteLine(fileName + " was found in the current folder.");
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void FindFile()
        {
            DirectoryInfo fileList = new DirectoryInfo(filePath);
            try
            {
                FileInfo[] files = fileList.GetFiles();
                DirectoryInfo[] dirs = fileList.GetDirectories();

                for (int i = 0; i < files.Length; i++)
                {
                    if (files != null && files[i].Name == fileName)
                    {
                        Console.WriteLine(string.Concat(fileName, "was found in folder: ", files[i].DirectoryName));
                    }
                    else
                    {
                        for (int k = 0; k < dirs.Length; k++)
                        {
                            FileInfo[] foundFiles = dirs[k].GetFiles();
                            DirectoryInfo[] foundDirs = dirs[k].GetDirectories();

                            if (foundFiles != null && foundFiles[k].Name == fileName)
                            {
                                Console.WriteLine(string.Concat(fileName, "was found in folder: ", foundFiles[k].DirectoryName));
                            }
                            else
                            {

                            }
                        }
                    }
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
