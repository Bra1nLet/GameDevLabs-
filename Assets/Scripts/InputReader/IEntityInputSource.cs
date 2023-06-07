namespace InputReader
{
    public interface IEntityInputSource
    {
        float HorizontalDirection { get; }
        float VerticalDirection { get; }
        bool Attack { get; }
        public void ResetOneTimeActions();
    }
}