namespace ExecutablesLibrary
{
    public interface IControlable : IExecutable
    {
        void Pause();
        void Stop();
    }
}