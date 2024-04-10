namespace KeyNerd.DataTransfer.Requests
{
    public class UpdateKeycapRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<UpdateKeycapDetailRequest> Details { get; set; }
    }
}
