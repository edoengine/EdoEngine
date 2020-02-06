namespace EdoEngine.Graphics.Backend
{
    internal interface IWindow
    {
        bool IsOpen { get; }

        void Update();
    }
}