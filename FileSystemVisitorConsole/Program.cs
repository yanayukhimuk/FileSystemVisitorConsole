using System;

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
            string enteredFileName;

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
                    Console.WriteLine("Enter the file you would like to find in the specified folder: ");
                    enteredFileName = Console.ReadLine();

                    fileSystemVisitor = new FileSystemVisitor(enteredPath, enteredFileName);
                    fileSystemVisitor.ShowFileInPredifinedFolder();
                    break;
                default:
                    Console.WriteLine("Sorry, your answer can't be processed. Please, try again.");
                    break;
            }
        }
    }
}
