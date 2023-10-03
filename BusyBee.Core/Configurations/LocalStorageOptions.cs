namespace BusyBee.Core.Configurations;

public class LocalStorageOptions
{
    public string ImagesUrlPrefix { get; set; } = null!;
    public string ImagesFolderPath { get; set; } = null!;
    public string FilesUrlPrefix { get; set; } = null!;
    public string FilesFolderPath { get; set; } = null!;
    public string CategoryIconFilenamePrefix { get; set; } = null!;
    public string UserPhotoFilenamePrefix { get; set; } = null!;
    public string PortfolioFilenamePrefix { get; set; } = null!;
}