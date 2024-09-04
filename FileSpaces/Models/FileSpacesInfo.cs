namespace FileSpaces.Models
{
    /// <summary>
    /// Represents file information (file path and the number of spaces in the file text).
    /// </summary>
    internal class FileSpacesInfo
    {
        #region constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public FileSpacesInfo(string filePath, int spacesCount)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"{nameof(FilePath)} must be present");
            }

            if (spacesCount < 0)
            {
                throw new ArgumentException($"{nameof(SpacesCount)} must be non-negative");
            }

            FilePath = filePath;
            SpacesCount = spacesCount;
        }

        #endregion

        #region public properties

        /// <summary>
        /// File path.
        /// </summary>
        public string FilePath { get; protected set; }

        /// <summary>
        /// Number of spaces in the file text.
        /// </summary>
        public int SpacesCount { get; protected set; }

        #endregion
    }
}
