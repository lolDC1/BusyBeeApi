using BusyBee.Core.Configurations;
using BusyBee.Core.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace BusyBee.Storage;

public class LocalStorageService : ILocalStorageService
{
    private readonly IOptions<LocalStorageOptions> _options;

    public LocalStorageService(IOptions<LocalStorageOptions> options)
    {
        _options = options;
    }

    public async Task<bool> UploadFileAsync(string fileName, string folderPath, Stream sourceStream, CancellationToken token = default)
    {
        try
        {
            if (sourceStream.Length <= 0) return false;

            var path = GetFolderPath(folderPath);

            await using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            await sourceStream.CopyToAsync(fileStream, token);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }
    }

    public async Task DeleteFileAsync(string fileName, string folderPath, CancellationToken token = default)
    {
        try
        {
            var path = Path.Combine(GetFolderPath(folderPath), fileName);

            if (!new FileInfo(path).Exists) return;

            await DeleteFileThreadAsync(path, token);
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }
    }

    private static async Task DeleteFileThreadAsync(string filePath, CancellationToken token = default)
    {
        await Task.Run(() => File.Delete(filePath), token);
    }

    private string GetFolderPath(string folderPath)
    {
        var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, folderPath));
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        return path;
    }
}