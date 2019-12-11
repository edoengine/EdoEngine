// 2019/10/15

namespace Edo.Mathematics
{
    // TODO: should this be JSON serializable? If so, in what way?
    public struct Matrix4
    {
        private float[] _data;

        public Matrix4(float a)
        {
            _data = new float[16];
        }

        #region Accessors

        public float this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }

        public float this[int row, int column]
        {
            get => this[row + column * 4];
            set => this[row + column * 4] = value;
        }

        #endregion
    }
}