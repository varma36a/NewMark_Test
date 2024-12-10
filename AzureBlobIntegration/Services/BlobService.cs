using Azure.Storage.Blobs;

namespace AzureBlobIntegration.Services
{
    public class BlobService
    {
        private readonly string _blobUrl = "https://nmrkpidev.blob.core.windows.net/dev-test/dev-test.json";
        private readonly string _sasToken = "?sp=r&st=2024-10-28T10:35:48Z&se=2025-10-28T18:35:48Z&spr=https&sv=2022-11-02&sr=b&sig=bdeoPWtefikVgUGFCUs4ihsl22ZhQGu4%2B4cAfoMwd4k%3D";

        public async Task<string> GetJsonDataAsync()
        {
            var blobUri = new Uri($"{_blobUrl}{_sasToken}");
            var blobClient = new BlobClient(blobUri);

            var response = await blobClient.DownloadContentAsync();
            return response.Value.Content.ToString();
        }
    }
}
