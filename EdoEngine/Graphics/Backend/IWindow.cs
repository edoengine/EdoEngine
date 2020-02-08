namespace EdoEngine.Graphics.Backend
{
    /// <summary>
    /// Necessary parts for differing window systems
    /// </summary>
    internal interface IWindow
    {
        bool IsOpen { get; }
        
        /// <summary>
        /// Check for, and run, window and system events
        /// </summary>
        void PollEvents();

        void Update();
    }
}