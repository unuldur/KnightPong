namespace DefaultNamespace
{
    public interface IController
    {
        void AddPlayable(IPlayable playable);
        void RemovePlayable(IPlayable playable);
    }
}