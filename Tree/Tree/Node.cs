namespace Tree
{
    public sealed class Node<T>
    {
        public T Data { get; set; }
        public NodeLink Link { get; set; }
    }
}
