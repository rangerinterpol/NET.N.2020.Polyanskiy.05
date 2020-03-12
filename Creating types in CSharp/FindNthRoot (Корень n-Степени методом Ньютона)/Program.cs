namespace FindNthRoot__Корень_n_Степени_методом_Ньютона_
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            double n = 9, a = 0.004241979, accuracy = 0.00000001, result;

            int accuracyCount = GetAccuracyQuantity(accuracy);

            result = Round(GetSqrt(n, a, accuracy), accuracyCount);

            Console.WriteLine($"n = {n}, a = {a}, accuracy = {accuracy}");

            Console.WriteLine($"корень {n}-степени числа {a} с точностью {accuracy}: {result}");
            Console.ReadKey();
        }

        /// <summary>
        /// Вычисляет точность десятичной дроби.
        /// </summary>
        /// <param name="accuracy">Ожидаемое число типа Double.</param>
        /// <returns>Значение типа Int32.</returns>
        private static int GetAccuracyQuantity(double accuracy)
        {
            int accuracyCount = 0;

            string accuracyString = accuracy.ToString();

            int i = 0, dot = 1;

            foreach (char ch in accuracyString)
            {
                // Проверка символа '.'.
                if (ch == 44)
                {
                    dot = i;
                }

                if (i > dot && i < accuracyString.Length)
                {
                    accuracyCount++;
                }

                i++;
            }

            return accuracyCount - dot + 1;
        }

        /// <summary>
        /// Округляет десятичную дробь до указанной точности.
        /// </summary>
        /// <param name="number">Ожидаемое число типа Double.</param>
        /// <param name="accuracyQuantity">Ожидаемое число типа Int32.</param>
        /// <returns>Значение типа Double.</returns>
        private static double Round(double number, int accuracyQuantity)
        {
            double accuracyRound;

            accuracyRound = Math.Round(number, accuracyQuantity);

            return accuracyRound;
        }

        /// <summary>
        /// Получает корень числа из n-степени методом Ньютона.
        /// </summary>
        /// <param name="n">Ожидаемое число типа Double, степень числа.</param>
        /// <param name="a">Исходное число типа Double.</param>
        /// <param name="accuracy">Ожидаемое число типа Double, указывающее точность.</param>
        /// <returns>Значение типа Double.</returns>
        private static double GetSqrt(double n, double a, double accuracy)
        {
            double x0 = a / n;
            double x1 = (1 / n) * (((n - 1) * x0) + (a / Math.Pow(x0, n - 1)));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1 / n) * (((n - 1) * x0) + (a / Math.Pow(x0, n - 1)));
            }

            return x1;
        }
    }
}
