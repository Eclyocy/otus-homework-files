using System.Diagnostics;
using FileSpaces.Helpers;
using FileSpaces.Models;

namespace FileSpaces;

public static class Program
{
    #region private fields

    /// <summary>
    /// Directory in the repository root.
    /// </summary>
    private static readonly string directoryPath = Path.GetFullPath(
        Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "..",
            "..",
            "..",
            "test"));

    #endregion

    #region public methods

    /// <summary>
    /// Main method: count the spaces for every file in the directory.
    /// </summary>
    public static async Task Main()
    {
        Stopwatch stopwatch = new();

        stopwatch.Start();
        FileSpacesInfo[] fileInfos = await FileSpacesHelper.CountDirectoryFilesSpacesAsync(directoryPath);
        stopwatch.Stop();

        Console.WriteLine($"Counted in {stopwatch.ElapsedMilliseconds} milliseconds.");

        foreach (FileSpacesInfo fileInfo in fileInfos)
        {
            Console.WriteLine($"{fileInfo.FilePath} has {fileInfo.SpacesCount} spaces.");
        }
    }

    #endregion
}
