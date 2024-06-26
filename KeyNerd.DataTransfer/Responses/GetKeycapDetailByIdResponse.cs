﻿using KeyNerd.Domain.Enums;

namespace KeyNerd.DataTransfer.Responses
{
    public class GetKeycapDetailByIdResponse
    {
        public long Id { get; set; }
        public string Profile { get; set; }
        public float Size { get; set; }
        public string FileUrl { get; set; }
    }
}
