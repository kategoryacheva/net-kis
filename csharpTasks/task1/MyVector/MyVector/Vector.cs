using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVector
{
    public struct Vector
    {
        /* Нужно реализовать струкруру двумерный вектор (double X, double Y):
         - Добавить коструктор
         - Реализовать методы-заглушки:
            - Длина, сложение векторов, умножение на число
            - Скалярное и векторное произведение
            - Приведение к строке: выводить (X; Y)
         - Реализовать Операторы
         - В Main протестировать все методы, пока без использования фреймворков: просто зовем метод, сравниваем результат и пишем в консоль
         - К каждому полю структуры создать документацию: шаблон создается по "///" над тем, что документируем:
        /// <summary>
        /// Привмер использования Xml documentation comments
        /// </summary>
        private void Foo()
        {
        }        
        */


        public double X { get; set; }
        public double Y { get; set; }

        /// <summary>
        /// Vector class constructor
        /// </summary>
        /// <param name="x">x coordinate of the vector</param>
        /// <param name="y">y coordinate of the vector</param>
        public Vector(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns the length of the vector
        /// </summary>
        /// <returns>Length count: sqrt(x*x + y*y)</returns>
        public double Length()
        {
            return Math.Sqrt(X*X + Y*Y);
        }

        /// <summary>
        /// Adds a vector to this vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns>This vector</returns>
        public Vector Add(Vector v)
        {
            X += v.X;
            Y += v.Y;

            return this;
        }

        /// <summary>
        /// Multiplies this vector with a number
        /// </summary>
        /// <param name="k">Double coeff</param>
        /// <returns>This vector</returns>
        public Vector Scale(double k)
        {
            X *= k;
            Y *= k;

            return this;
        }

        /// <summary>
        /// Counts dot product of this vector and another vector
        /// </summary>
        /// <param name="v">Another vector</param>
        /// <returns>Dot product in double</returns>
        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y;
        }

        /// <summary>
        /// Counts cross product of this vector and another vector
        /// </summary>
        /// <param name="v">Another vector</param>
        /// <returns>Cross product in double</returns>
        public double CrossProduct(Vector v)
        {
            return X * v.Y - Y * v.X;
        }

        override public string ToString()
        {
            return $"Vector: x = {X}, y = {Y}";
        }

        #region Operators        
        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#
        public static Vector operator +(Vector v, Vector u)
        {
            return new Vector(v.X + u.X, v.Y + u.Y);
        }

        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(v.X - u.X, v.Y - u.Y);
        }

        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v.X * k, v.Y * k);
        }

        public static Vector operator *(double k, Vector v)
        {
            return new Vector(v.X * k, v.Y * k);
        }

        public static Vector operator /(Vector v, double k)
        {
            return new Vector(v.X / k, v.Y / k);
        }

        public static Vector operator +(Vector v)
        {
            return new Vector(+v.X, +v.Y);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }

        #endregion
    }
}
