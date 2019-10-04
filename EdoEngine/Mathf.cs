namespace Edo
{
    public class Mathf
    {
        public static float Clamp(float a, float min, float max) => a < min ? min : a > max ? max : min;

        public static float Clamp01(float a) => Clamp(a, 0f, 1f);
    }
}