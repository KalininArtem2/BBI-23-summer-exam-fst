using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public class Task2
{
    private Figure[] _figures;

    public Figure[] Figures => _figures;

    public Task2(Figure[] figures)
    {
        _figures = new Figure[figures.Length];
        Array.Copy(figures, _figures, figures.Length);
    }

    public void AddFigure(Figure figure)
    {
        Figure[] newFigures = new Figure[_figures.Length + 1];
        Array.Copy(_figures, newFigures, _figures.Length);
        newFigures[_figures.Length] = figure;
        _figures = newFigures;
    }

    public void Sorting()
    {
        for (int i = 0; i < _figures.Length - 1; i++)
        {
            for (int j = i + 1; j < _figures.Length; j++)
            {
                if (j < _figures.Length && i < _figures.Length && _figures[i] != null && _figures[j] != null)
                {
                    if (_figures[i].Area() > _figures[j].Area())
                    {
                        Figure temp = _figures[i];
                        _figures[i] = _figures[j];
                        _figures[j] = temp;
                    }
                }
            }
        }
    }

    public override string ToString()
    {
        var result = "";
        for (int i = 0; i < _figures.Length; i++)
        {
            result += _figures[i].ToString() + Environment.NewLine;
        }
        return result;
    }

    public abstract class Figure
    {
        public abstract double Area();
        public abstract string Distinct();
    }

    public class Circle : Figure
    {
        private double _radiusA;
        private double _radiusB;

        public Circle(double radiusA, double radiusB)
        {
            _radiusA = radiusA;
            _radiusB = radiusB;
        }

        public override double Area()
        {
            return Math.PI * Math.Max(_radiusA, _radiusB) * Math.Min(_radiusA, _radiusB);
        }

        public override string Distinct()
        {
            if (_radiusA == _radiusB) return "круг";
            else return "эллипс";
        }

        public double A => _radiusA;
        public double B => _radiusB;

        public override string ToString()
        {
            return $"Type = Circle, subtype = {Distinct()}, radiusA = {A}, radiusB = {B}, with S = {Area():F2}";
        }
    }

    public class Fourangle : Figure
    {
        private double _sideA;
        private double _sideB;

        public Fourangle(double sideA, double sideB)
        {
            _sideA = sideA;
            _sideB = sideB;
        }

        public override double Area()
        {
            return _sideA * _sideB;
        }

        public override string Distinct()
        {
            if (_sideA == _sideB) return "квадрат";
            else return "прямоугольник";
        }

        public double A => _sideA;
        public double B => _sideB;

        public override string ToString()
        {
            return $"Type = Fourangle, subtype = {Distinct()}, sideA = {A}, sideB = {B}, with S = {Area():F2}";
        }
    }

    public class Triangle : Figure
    {
        private int[] _sides;

        public int A => _sides[0];
        public int B => _sides[1];
        public int C => _sides[2];

        public Triangle(int[] sides)
        {
            if (sides.Length != 3)
            {
                throw new ArgumentException("Array must contain exactly 3 elements");
            }

            if (!IsValidTriangle(sides))
            {
                throw new ArgumentException("Invalid triangle");
            }

            _sides = sides;
        }

        public override double Area()
        {
            var p = (_sides[0] + _sides[1] + _sides[2]) / 2.0;
            return Math.Round(Math.Sqrt(p * (p - _sides[0]) * (p - _sides[1]) * (p - _sides[2])), 2);
        }

        public override string Distinct()
        {
            if (A == B && B == C) return "равносторонний";
            if (A == B || B == C || A == C) return "равнобедренный";
            return "разносторонний";
        }

        public override string ToString()
        {
            var type = Distinct();
            return $"Type = Triangle, subtype = {type}, a = {A}, b = {B}, c = {C}, with S = {Area():F2}";
        }

        private bool IsValidTriangle(int[] sides)
        {
            return sides[0] + sides[1] > sides[2] &&
                               sides[0] + sides[2] > sides[1] &&
                               sides[1] + sides[2] > sides[0];
        }
    }
}