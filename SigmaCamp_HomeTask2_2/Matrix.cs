using System;

namespace SigmaCamp_HomeTask2_2
{
    public enum Direction
    {
        Down,
        Right
    }
    internal class Matrix
    {
        private int[,] matrix;
        private int _rows;
        private int _cols;
        public int Length { get => matrix.Length; }
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Cols = columns;
            matrix = new int[rows, columns];
        }
        public Matrix(int size):this(size, size) { }
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect indexes to get matrix element");
                }
                return matrix[i, j];
            }
            set
            {
                if (i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect indexes to assign value");
                }
                matrix[i, j] = value;
            }
        }
        public int Rows
        {
            get => _rows;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentNullException("Incorrect value for rows");
                }
                else
                {
                    _rows = value;
                }
            }
        }
        public int Cols
        {
            get => _cols;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Incorrect value for columns");
                }
                else
                {
                    _cols = value;
                }
            }
        }
        public override string ToString()
        {
            string stringMatrix = "";
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    stringMatrix += matrix[i, j] + "\t";
                }
                stringMatrix += "\n";
            }
            return stringMatrix;
        }
        public void FillVertSnake()
        {
            int filler = 1;
            for (int j = 0; j < _cols; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < _rows; i++)
                    {
                        matrix[i, j] = filler;
                        filler++;
                    }
                }
                else
                {
                    for (int i = _rows - 1; i >= 0; i--)
                    {
                        matrix[i, j] = filler;
                        filler++;
                    }
                }
            }
        }
        public void FillDiagSnake(string direction)
        {
            Direction _direction;
            if (!Enum.TryParse(direction, true, out _direction))
            {
                throw new ArgumentNullException("You can't choose such direction");
            }
            if (_rows!=_cols)
            {
                throw new Exception("Matrix should have a square form");
            }
            int filler = 1;
            //заповнення до побічної діагоналі включно
            for (int i = 0; i < _rows; i++)
            {
                var startAndEndTuple = GetEndAndStart(i, true,_direction);
                for (int j = 0; j < i + 1; j++)
                {
                    matrix[startAndEndTuple.start, startAndEndTuple.end] = filler++;
                    if ((i % 2 == 1 && _direction.ToString() == "Right") || (i % 2 == 0 && _direction.ToString() == "Down"))
                    {
                        startAndEndTuple.start++;
                        startAndEndTuple.end--;
                    }
                    else if((i % 2 == 0 && _direction.ToString() == "Right") || (i % 2 == 1 && _direction.ToString() == "Down"))
                    {
                        startAndEndTuple.start--;
                        startAndEndTuple.end++;
                    }
                }
            }

            //заповнення після побічної діагоналі
            int count = 0;
            for (int i = 0; i < _cols - 1; i++)
            {
                var startAndEndTuple = GetEndAndStart(i, false, _direction);
                for (int j = 0; j < i + 1; j++)
                {
                    matrix[startAndEndTuple.end, startAndEndTuple.start] = matrix.Length - count;
                    if ((i % 2 == 1 && _direction.ToString() == "Right") || (i % 2 == 0 && _direction.ToString() == "Down"))
                    {
                        startAndEndTuple.start++;
                        startAndEndTuple.end--;
                    }
                    else if ((i % 2 == 0 && _direction.ToString() == "Right") || (i % 2 == 1 && _direction.ToString() == "Down"))
                    {
                        startAndEndTuple.start--;
                        startAndEndTuple.end++;
                    }
                    count++;
                }
            }
            (int start, int end) GetEndAndStart(int row, bool beforeDiag, Direction direction)
            {
                int temp = row;
                if (_direction.ToString() == "Down")
                {
                    row++;
                }
                if (beforeDiag)
                {
                    if (row % 2 == 0)
                        return (temp, 0);
                    else
                        return (0, temp);
                }
                else
                {
                    if (row % 2 == 0)
                        return (_rows - 1, _rows - 1 - temp);
                    else
                        return (_rows - 1 - temp, _rows - 1);
                }
            }
        }
        public void FillSpirally()
        {
            int filler = 1;
            int c1 = 0, c2 = _rows - 1;
            int c3 = _cols - 1;
            while (filler <= _rows * _cols)
            {
                //Заповнення вниз
                for (int j = c1; j <= c2; j++)
                    matrix[j, c1] = filler++;
                //Заповнення вправо
                for (int i = c1 + 1; i <= c3; i++)
                    matrix[c2, i] = filler++;
                //Заповнення вгору
                for (int j = c2 - 1; j >= c1; j--)
                    matrix[j, c3] = filler++;
                //Заповнення вліво
                if (filler<= _rows*_cols)
                {
                    for (int i = c3 - 1; i >= c1 + 1; i--)
                        matrix[c1, i] = filler++;
                }
                c1++;
                c2--;
                c3--;
            }
        }
    }
}
