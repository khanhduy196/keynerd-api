using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using KeyNerd.DataTransfer.Settings;
using KeyNerd.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace KeyNerd.Service
{
    public class S3StorageService : IStorageService
    {
        private readonly AWSSettings _awsSettings;
        public S3StorageService(IOptions<AWSSettings> awsSettingsOptions)
        {
            _awsSettings = awsSettingsOptions.Value;
        }

        public async Task<string> UploadFile(string bucketName, IFormFile file)
        {
            using (var client = new AmazonS3Client(_awsSettings.AccessKey, _awsSettings.SecretAccessKey, RegionEndpoint.APSoutheast1))
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);
                    var key = $"{Guid.NewGuid()}.{file.FileName.Split(".").Last()}";
                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = key,
                        BucketName = bucketName,
                        CannedACL = S3CannedACL.PublicRead
                    };

                    var fileTransferUtility = new TransferUtility(client);
                    await fileTransferUtility.UploadAsync(uploadRequest);

                    return key;
                }
            }
        }

        public async Task<IEnumerable<string>> UploadFiles(string bucketName, IEnumerable<IFormFile> files)
        {
            var tasks = new List<Task<string>>();
            foreach (var file in files)
            {
                tasks.Add(UploadFile(bucketName, file));
            }

            await Task.WhenAll(tasks);

            var urls = new List<string>();

            return tasks.Select(task => task.Result);
        }
    }
}
