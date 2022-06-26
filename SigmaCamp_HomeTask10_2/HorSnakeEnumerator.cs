using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask10_2
{
    internal class HorSnakeEnumerator : IEnumerable<int>
    {
        private int[,] _matrix; 
        public HorSnakeEnumerator(int[,] matrix)
        {
            _matrix = matrix;
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < _matrix.GetLength(1); j++)
                    {
                        yield return _matrix[i, j];
                    }
                }
                else
                {
                    for (int j = _matrix.GetLength(1)-1; j >= 0; j--)
                    {
                        yield return _matrix[i, j];
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
