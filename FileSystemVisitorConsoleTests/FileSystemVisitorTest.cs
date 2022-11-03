namespace FileSystemVisitorConsole.Tests
{
    public class FileSystemVisitorTest
    {
        string pathToFolder = "D:\\";
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void VerifyPossibilityOfGettingFolders()
        {
            var fileApp = new FileSystemVisitor(pathToFolder);
            var folderContent = fileApp.ReturnFolderContent();
            Assert.That(folderContent.Count().Equals(48));
        }
    }
}