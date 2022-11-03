using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FileSystemVisitorTests
{
    [TestClass]
    public class FileSystemVisitorTests
    {
        readonly string pathToFolder = "C:\\";

        [TestMethod()]
        public void TestMethod1()
        {
            var fileSystemVisitor = new FileSystemVisitor(pathToFolder);

        }
    }
}
