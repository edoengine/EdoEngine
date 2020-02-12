using System;

namespace EdoEngine
{
    public static class Time
    {
        /// <summary>
        /// Time (in seconds) since last frame
        /// </summary>
        public static float DeltaTime => DeltaTimeUnscaled * TimeScale;

        /// <summary>
        /// Interval (in seconds) of fixed rate updates
        /// </summary>
        public static float FixedDeltaTime => FixedDeltaTimeUnscaled * TimeScale;

        /// <summary>
        /// Time (in seconds) since last frame, unaffected by current time scale
        /// </summary>
        public static float DeltaTimeUnscaled { get; private set; }
        
        /// <summary>
        /// Interval (in seconds) of fixed rate updates, unaffected by current time scale
        /// </summary>
        public static float FixedDeltaTimeUnscaled { get; private set; }

        /// <summary>
        /// The scale at which time passes
        /// </summary>
        public static float TimeScale { get; set; } = 1f;
        
        public static int FrameCount { get; private set; }

        private static DateTime _lastFrameTime = DateTime.Now;
        private static DateTime _lastFixedTime = DateTime.Now;
        
        internal static void UpdateTime()
        {
            var currentFrameTime = DateTime.Now;
            DeltaTimeUnscaled = (float) (currentFrameTime - _lastFrameTime).TotalSeconds;
            _lastFrameTime = currentFrameTime;
            FrameCount++;
        }

        internal static void UpdateFixed()
        {
            var currentFixedTime = DateTime.Now;
            FixedDeltaTimeUnscaled = (float) (currentFixedTime - _lastFixedTime).TotalSeconds;
            _lastFixedTime = currentFixedTime;
        }
    }
}