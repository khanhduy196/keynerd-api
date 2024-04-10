namespace KeyNerd.DataTransfer.Responses
{
    public class GetKeycapByIdResponse
    {
        public long Id { get; set; }

        public List<string> Photos { get; set; }

        public string Name { get; set; }

        public IList<GetKeycapDetailByIdResponse> Details { get; set; }
    }
}
