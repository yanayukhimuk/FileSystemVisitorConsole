using System;
using System.Collections.Immutable;
using System.Linq;

namespace FileSystemVisitorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to  see the files in the folder or find a specific file? (folder / file): ");
            string answer = Console.ReadLine();
            FileSystemVisitor fileSystemVisitor;
            string enteredPath;

            switch (answer)
            {
                case "folder":
                    Console.WriteLine("Enter the path to the folder: ");
                    enteredPath = Console.ReadLine();

                    fileSystemVisitor = new FileSystemVisitor(enteredPath);
                    fileSystemVisitor.ShowFilesInPredefinedFolder();
                    break;
                case "file":
                    Console.WriteLine("Enter the path to the folder: ");
                    enteredPath = Console.ReadLine();

                    fileSystemVisitor = new FileSystemVisitor(enteredPath, FilterFiles);
                    fileSystemVisitor.ShowFilesInPredefinedFolder();
                    break;
                default:
                    Console.WriteLine("Sorry, your answer can't be processed. Please, try again.");
                    break;
            }
        }

        private static VisitorSystemInfoList FilterFiles(VisitorSystemInfoList list)
        {
            Console.WriteLine("Please, enter search pattern: ");
            string pattern = Console.ReadLine();

            return list.Where(x => x.Name.Contains(pattern)).ToVisitorSystemInfoList();
        }

    }
}
