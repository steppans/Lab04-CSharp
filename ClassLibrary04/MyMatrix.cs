namespace ClassLibrary04
{
    public class MyMatrix
    {
        private int _m;
        private int _n;

        private double[,] _data;

        public MyMatrix(int m, int n)
        {
            _m = m;
            _n = n;
            _data = new double[m, n];
        }

        // For tests
        public int m => _m;
        public int n => _n;

        public void SetData(int LeftLimit, int RightLimit)
        {
            Random rand = new Random();
            for (int i = 0; i < _m; ++i)
            {
                for (int j = 0; j < _n; ++j)
                {
                    _data[i, j] = rand.Next(LeftLimit, RightLimit);
                }
            }
        }

        // For Debug
        public void PrintMatrix()
        {
            Console.WriteLine("/---------------/");
            for (int i = 0; i < _m; ++i)
            {
                for (int j = 0; j < _n; ++j)
                {
                    Console.Write($"{Math.Round(_data[i, j], 2)} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("/---------------/");

        }

        // Access by index
        public double this[int i, int j]
        {
            get => _data[i, j];
            set => _data[i, j] = value;
        }

        // Operators

        public static MyMatrix operator +(MyMatrix left, MyMatrix right)
        {
            if (left._m != right._m || left._n != right._n)
            {
                throw new InvalidOperationException("Operation + with such matrix is not supported");
            }

            MyMatrix result = new(left._m, left._n);
            for (int i = 0; i < result._m; ++i)
            {
                for (int j = 0; j < result._n; ++j)
                {
                    result[i, j] = left[i, j]  + right[i, j];
                }
            }
            return result;
        }

        public static MyMatrix operator -(MyMatrix left, MyMatrix right)
        {
            if (left._m != right._m || left._n != right._n)
            {
                throw new InvalidOperationException("Operation - with such matrix is not supported");
            }

            MyMatrix result = new(left._m, left._n);
            for (int i = 0; i < result._m; ++i)
            {
                for (int j = 0; j < result._n; ++j)
                {
                    result[i, j] = left[i, j] - right[i, j];
                }
            }
            return result;
        }

        public static MyMatrix operator *(MyMatrix left, MyMatrix right)
        {
            if (left._n != right._m)
            {
                throw new InvalidOperationException("Operation * with such matrix is not supported");
            }

            MyMatrix result = new(left._m, right._n);
            for (int i = 0; i < result._m; ++i)
            {
                for (int j = 0; j < result._n; ++j)
                {
                    double sum = 0;

                    for (int k = 0; k < left._n; ++k)
                    {
                        sum += left[i, k] * right[k, j];
                    }

                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static MyMatrix operator *(double a, MyMatrix right)
        {
            MyMatrix result = new(right._m, right._n);
            for (int i = 0; i < result._m; ++i)
            {
                for (int j = 0; j < result._n; ++j)
                {
                    result[i, j] = a * right[i, j];
                }
            }
            return result;
        }

        public static MyMatrix operator *(MyMatrix left, double a) => a * left;

        public static MyMatrix operator /(MyMatrix left, double a) => (1 / a) * left;
    }
}