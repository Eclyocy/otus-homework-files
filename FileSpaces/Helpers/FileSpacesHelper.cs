using FileSpaces.Models;

namespace FileSpaces.Helpers
{
    internal static class FileSpacesHelper
    {
        #region public methods

        /// <summary>
        /// Count the spaces in all the files under specified directory.
        /// </summary>
        public static async Task<FileSpacesInfo[]> CountDirectoryFilesSpacesAsync(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new ArgumentException($"Directory {directoryPath} does not exist.");
            }

            string[] filePaths = Directory.GetFiles(directoryPath);

            List<Task<FileSpacesInfo>> tasks = filePaths
                .Select(filePath => Task.Run(() => CountFileSpacesAsync(filePath)))
                .ToList();

            return await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Count the spaces in the specified file.
        /// </summary>
        public static async Task<FileSpacesInfo> CountFileSpacesAsync(string filePath)
        {
            // Console.WriteLine($"thread: {Thread.CurrentThread.ManagedThreadId}");
            // Console.WriteLine($"task: {Task.CurrentId}");

            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"File {filePath} does not exist.");
            }

            string fileText = await File.ReadAllTextAsync(filePath);

            int spacesCount = fileText.Count(x => x == ' ');

            return new FileSpacesInfo(
                filePath: filePath,
                spacesCount: spacesCount);
        }

        #endregion
    }
}
