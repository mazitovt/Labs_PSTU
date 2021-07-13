namespace ExecutablesLibrary
{
    public interface IExecutable
    {
        public string Status { get; set; }
        void Run();
        void ShowStatus();
    }
}