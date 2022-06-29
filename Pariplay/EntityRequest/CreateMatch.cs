namespace Pariplay.API.EntityRequest
{
    public class CreateMatch
    {
        public int VisitorId { get; set; }

        public int HostId { get; set; }

        public int VisitorResult { get; set; }

        public int HostResult { get; set; }
    }
}
