namespace BatteryIcon.Models
{
    public class MatrixModel<T> where T : struct
    {
        private T[,] _array;

        /// <summary>
        /// 2D array
        /// </summary>
        public T[,] Array
        {
            get
            {
                return _array;
            }
            set
            {
                _array = value;
                Width = (byte)_array.GetLength(1); // number of columns
                Height = (byte)_array.GetLength(0); // number of rows
            }
        }
        /// <summary>
        /// Number of columns in an array
        /// </summary>
        public byte Width { get; private set; }

        /// <summary>
        /// Number of raws in an array
        /// </summary>
        public byte Height { get; private set; }
    }
}
