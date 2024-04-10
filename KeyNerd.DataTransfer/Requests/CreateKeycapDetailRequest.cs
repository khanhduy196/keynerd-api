using KeyNerd.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace KeyNerd.DataTransfer.Requests
{
    public class CreateKeycapDetailRequest
    {
        public KeycapProfile Profile { get; set; }
        public float Size { get; set; }
        public IFormFile? File { get; set; }
    }
}
