using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask10_2
{
    internal class DiagSnakeEnumerator : IEnumerable<int>
    {
        int[,] _matrix;
        public DiagSnakeEnumerator(int[,] matrix)
        {
            _matrix = matrix;
        }
        public IEnumerator<int> GetEnumerator()
        {
            int start;
            int end;

            //заповнення до побічної діагоналі включно
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    end = 0;
                    start = i;
                }
                else
                {
                    start = 0;
                    end = i;
                }
                for (int j = 0; j < i + 1; j++)
                {
                    yield return _matrix[start, end];
                    if (i % 2 == 1)
                    {
                        start++;
                        end--;
                    }
                    else
                    {
                        start--;
                        end++;
                    }
                }
            }

            //заповнення після побічної діагоналі
            int count = 0;
            bool isEvenRows = _matrix.GetLength(0) % 2 == 0;
            (int row, int column) place;
            if (isEvenRows)
            {
                place = (_matrix.GetLength(0) - 1, 1);
                for (int i = 0; i < _matrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < _matrix.GetLength(0) - 1 - i; j++)
                    {
                        yield return _matrix[place.row, place.column];
                        if (i % 2 == 1)
                        {
                            place.row++;
                            place.column--;
                        }
                        else
                        {
                            place.row--;
                            place.column++;
                        }
                    }
                    if (i % 2 == 0)
                    {
                        place.row += 2;
                        place.column--;
                    }
                    else
                    {
                        place.column += 2;
                        place.row--;
                    }
                }
            }
            else
            {
                place = (1, _matrix.GetLength(0) - 1);
                for (int i = 0; i < _matrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < _matrix.GetLength(0) - 1 - i; j++)
                    {
                        yield return _matrix[place.row, place.column];
                        if (i % 2 == 0)
                        {
                            place.row++;
                            place.column--;
                        }
                        else
                        {
                            place.row--;
                            place.column++;
                        }
                    }
                    if (i % 2 == 1)
                    {
                        place.row += 2;
                        place.column--;
                    }
                    else
                    {
                        place.column += 2;
                        place.row--;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
