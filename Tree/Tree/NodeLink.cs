namespace Tree
{
    public sealed class NodeLink
    {
        public long Id { get; set; }
        public long? Parent { get; set; }
        public long? Next { get; set; }
        public long? Child { get; set; }
        public int Depth { get; set; }
    }
}
