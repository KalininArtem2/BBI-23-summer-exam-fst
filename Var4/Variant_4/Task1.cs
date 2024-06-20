using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using static Variant_4.Task1;





namespace Variant_4
{
    public class Task1
    {
        private Triangle[] _triangles;

        public Triangle[] Triangles => _triangles;

        public Task1(Triangle[] vectors)
        {
            _triangles = new Triangle[0];
        }

        public void AddTriangle(int[] sides)
        {
            if (sides.Length != 3)
            {
                throw new ArgumentException("Массив должен содержать ровно 3 ");
            }

            var triangle = new Triangle(sides);
            _triangles = ResizeArray(_triangles, _triangles.Length + 1);
            _triangles[_triangles.Length - 1] = triangle;
        }

        public void Sorting()
        {
            for (int i = 0; i < _triangles.Length - 1; i++)
            {
                for (int j = i + 1; j < _triangles.Length; j++)
                {
                    if (j < _triangles.Length && i < _triangles.Length && _triangles[i] != null && _triangles[j] != null)
                    {
                        if (_triangles[i].Area() > _triangles[j].Area())
                        {
                            var temp = _triangles[i];
                            _triangles[i] = _triangles[j];
                            _triangles[j] = temp;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            var result = "";
            for (int i = 0; i < _triangles.Length; i++)
            {
                result += _triangles[i].ToString() + Environment.NewLine;
            }
            return result;
        }

        private Triangle[] ResizeArray(Triangle[] array, int newSize)
        {
            var newArray = new Triangle[newSize];
            for (int i = 0; i < Math.Min(array.Length, newSize); i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }

        public class Triangle
        {
            private int[] _sides;

            public int A => _sides[0];
            public int B => _sides[1];
            public int C => _sides[2];

            public Triangle(int[] sides)
            {
                if (sides.Length != 3)
                {
                    throw new ArgumentException("Массив должен содержать 3");
                }

                if (!IsValidTriangle(sides))
                {
                    _sides = new int[0];
                    return;
                }

                _sides = sides;
            }

            public string Distinct()
            {
                if (_sides.Length == 0) return "несуществующий треугольник";

                if (A == B && B == C) return "Равносторонний";
                if (A == B || B == C || A == C) return "Равнобедренный";
                return "Scalene";
            }

            public double Area()
            {
                if (_sides.Length == 0) return 0;

                var p = (_sides[0] + _sides[1] + _sides[2]) / 2.0;
                return Math.Round(Math.Sqrt(p * (p - _sides[0]) * (p - _sides[1]) * (p - _sides[2])), 2);
            }

            public override string ToString()
            {
                if (_sides.Length == 0) return "несуществующий треугольник";

                var type = Distinct();
                return $"Type = Triangle, subtype = {type}, a = {A}, b = {B}, c = {C}, area = {Area():F2}";
            }

            private bool IsValidTriangle(int[] sides)
            {
                return sides[0] + sides[1] > sides[2] &&
                       sides[0] + sides[2] > sides[1] &&
                       sides[1] + sides[2] > sides[0];
            }
        }
    }
}
