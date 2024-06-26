﻿using KeyNerd.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace KeyNerd.DataTransfer.Requests
{
    public class UpdateKeycapDetailRequest
    {
        public long Id { get; set; }
        public KeycapProfile Profile { get; set; }
        public float Size { get; set; }
        public IFormFile? File { get; set; }
    }
}
