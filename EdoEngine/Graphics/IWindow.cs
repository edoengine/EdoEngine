namespace Edo.Graphics
{
    internal interface IWindow
    {
        void Initialize(string title, int width, int height);
        bool HandleEvents();
        void Swap();
        bool Closing { get; }
    }
}