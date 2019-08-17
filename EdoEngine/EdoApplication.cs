//=============================================================================
// EdoApplication.cs
//
// Created by Victor on 2019/08/17
//=============================================================================

namespace Edo
{
    /// <summary>
    /// Class defining an external application using Edo Engine
    /// DO NOT inherit from this yourself. Only the class defining the main entry point should inherit from this.
    /// </summary>
    public abstract class EdoApplication
    {
        private static bool _running;
        
        protected void Initialize()
        {
            if (_running)
            {
                // TODO: Error
                Debug.Log("Attempted to initialize on already running application. Ensure no classes derive from EdoApplication");
                return;
            }
            
            Debug.Initialize();
        }

        protected void Run()
        {
            if (_running)
            {
                // TODO: Error
                Debug.Log("Attempted to run an already running application. Ensure no classes derive from EdoApplication");
                return;
            }
            
            //
        }
    }
}