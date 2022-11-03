using System;
using System.Collections.Immutable;
using System.Linq;
using System.Xml.Schema;

namespace FileSystemVisitorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chose the option: 1. Show folder content. 2. Find file. (folder / file) : ");
            string answer = Console.ReadLine();
            FileSystemVisitor fileSystemVisitor;
            string enteredPath;

            switch (answer)
            {
                case "folder":
                    Console.WriteLine("Enter the path to the folder: ");
                    enteredPath = Console.ReadLine();

                    fileSystemVisitor = new FileSystemVisitor(enteredPath);
                    fileSystemVisitor.StageNotificationEvent += (s, args) =>
                    {
                        Console.WriteLine("Showing folder content is initialized...");
                    };
                    var content = fileSystemVisitor.ReturnFolderContent();
                    fileSystemVisitor.DisplayContent(content);
                    break;
                case "file":
                    Console.WriteLine("Enter the path to the folder: ");
                    enteredPath = Console.ReadLine();

                    fileSystemVisitor = new FileSystemVisitor(enteredPath, FilterFiles);
                    fileSystemVisitor.StageNotificationEvent += (s, args) =>
                    {
                        Console.WriteLine("Searching for file is initialized...");
                    };
                    fileSystemVisitor.FoundFileEvent += (s, args) =>
                    {
                        Console.WriteLine("The file was found.");
                    };
                    fileSystemVisitor.FailedFindEvent += (s, args) =>
                    {
                        Console.WriteLine("The file wasn't found.");
                    };
                    var content2 = fileSystemVisitor.SearchFileInFolderTree();
                    fileSystemVisitor.DisplayContent(content2);
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
