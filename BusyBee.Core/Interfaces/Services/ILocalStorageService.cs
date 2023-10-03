namespace BusyBee.Core.Interfaces.Services;

public interface ILocalStorageService
{
    public Task<bool> UploadFileAsync(string fileName, string folderPath, Stream sourceStream, CancellationToken token = default);
    public Task DeleteFileAsync(string fileName, string folderPath, CancellationToken token = default);
}