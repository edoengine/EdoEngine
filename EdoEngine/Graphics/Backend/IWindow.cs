namespace EdoEngine.Graphics.Backend
{
    /// <summary>
    /// Necessary parts for differing window systems
    /// </summary>
    internal interface IWindow
    {
        bool IsOpen { get; }

        void Update();
    }
}