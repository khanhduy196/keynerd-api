namespace KeyNerd.Domain.Entities
{
    public class KeycapPhoto
    {
        public long KeycapId { get; set; }
        public string Url { get; set; }
        public Keycap Keycap { get; set; }
  
    }
}
