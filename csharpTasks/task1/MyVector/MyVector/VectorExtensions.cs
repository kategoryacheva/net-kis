using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVector
{
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }

    // Для создания методов расширения нужен статический класс, в котором в статических методах у первого аргумента 
    // добавляется ключевое слово this, далее можно вызывать данный метод у объектов класса такого аргумента 
    // Ниже нужно реализовать методы-расширения для нашего вектора
    // И не забыть про документацию и тесты
    public static class VectorExtensions
    {
        // Нормализовать вектор
        public static Vector Normalize(this Vector v)
        {
            if (v.Length() == 0) return v;
            else return v / v.Length();
        }

        // Получить угол между векторами в радианах
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if ((v.Length() != 0) && (u.Length() != 0))
                return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
            else return -1;
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            switch (GetAngleBetween(v, u))
            {
                case 0:
                    return VectorRelation.Parallel;
                case Math.PI / 2:
                    return VectorRelation.Orthogonal;
                default:
                    return VectorRelation.General;
            }
        }

        // Еденичный ортогональный вектор данному
        public static Vector GetOrthogonal(this Vector v)
        {
            return new Vector(-v.Y, v.X) / v.Length();
        }

        // Повернуть вектор на заданный угол
        public static Vector Rotate(this Vector v, double angle)
        {
            return new Vector(v.X * Math.Cos(angle) - v.Y * Math.Sin(angle), v.X * Math.Sin(angle) + v.Y * Math.Cos(angle));
        }
    }
}
