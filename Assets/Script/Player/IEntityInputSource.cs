namespace Player
{
    public interface IEntityInputSource
    {
        float HorizontalDirection { get; }
        float VerticalDirection { get; }
        bool Attack { get; }

        void ResetOneTimeActions();
    }
}