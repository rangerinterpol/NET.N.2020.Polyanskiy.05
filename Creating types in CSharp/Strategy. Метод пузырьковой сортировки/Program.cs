namespace Strategy.Метод_пузырьковой_сортировки
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            const int lengthArray = 4;

            var jaggedArray = new int[][]
            {
                new int[] { 0, 1, 3 },
                new int[] { 0, 4, 3, 4 },
                new int[] { 4, 2, 1, 6, 5 },
                new int[] { 3, 4 },
            };

            int[] sumElementsArray = FindSumElements(jaggedArray, lengthArray);

            FindMaxMinElements(jaggedArray, lengthArray, true, true);

            // Клиент

            // По умолчанию
            int[] onedimensinalArray = sumElementsArray;
            var context = new Context(new SortingArrayBySum());

            bool max = false;
            bool toUp = false;

            // По максимальному элементу
            if (max == true)
            {
                onedimensinalArray = MaxMinStruct.MaxElementsOfArray;
                context.SetStrategy(new SortingArrayByMax());
            }

            // По минимальному элементу
            else if (max == false)
            {
                onedimensinalArray = MaxMinStruct.MinElementsOfArray;
                context.SetStrategy(new SortingArrayByMin());
            }

            Console.WriteLine("До сортировки:\n");
            PrintJaggedArray(jaggedArray);

            int[][] copyArray = context.DoSort(jaggedArray, lengthArray, onedimensinalArray, toUp);

            Console.WriteLine("\n\nПосле сортировки:\n");
            PrintJaggedArray(copyArray);

            Console.ReadKey();
        }

        /// <summary>
        /// Получает одномерный массив сумм строк ступенчатого массива.
        /// </summary>
        /// <param name="array">Исследуемый массив.</param>
        /// <param name="length">Длина исследуемого массива.</param>
        /// <returns>Одномерный массив сумм строк исследуемого массива.</returns>
        private static int[] FindSumElements(int[][] array, int length)
        {
            int[] sumElementsOfArray = new int[length];
            int sumElements, i = 0;

            foreach (int[] subarray in array)
            {
                sumElements = 0;

                foreach (int value in subarray)
                {
                    sumElements += value;
                }

                sumElementsOfArray[i] = sumElements;

                i++;
            }

            return sumElementsOfArray;
        }

        private struct MaxMinStruct
        {
            internal static int[] MaxElementsOfArray;
            internal static int[] MinElementsOfArray;
        }

        /// <summary>
        /// Получает массив максимальных и минимальных элементов и помещает их в структуру MaxMinStruct.
        /// </summary>
        /// <param name="array">Исследуемый массив.</param>
        /// <param name="length">Длина исследуемого массива.</param>
        /// <param name="needMax">Найти максимальный.</param>
        /// <param name="needMin">Найти минимальный.</param>
        private static void FindMaxMinElements(int[][] array, int length, bool needMax, bool needMin)
        {
            int[] maxElementsOfArray = new int[length];
            int[] minElementsOfArray = new int[length];

            int maxElement = 0, minElement, iterator = 0;

            if (needMax == true || needMin == true)
            {
                foreach (int[] subarray in array)
                {
                    if (needMax == true)
                    {
                        maxElement = 0;

                        foreach (int value in subarray)
                        {
                            if (value > maxElement)
                            {
                                maxElement = value;
                            }
                        }

                        maxElementsOfArray[iterator] = maxElement;
                    }

                    if (needMin == true)
                    {
                        minElement = maxElement;

                        foreach (int value in subarray)
                        {
                            if (value < minElement)
                            {
                                minElement = value;
                            }
                        }

                        minElementsOfArray[iterator] = minElement;
                    }

                    iterator++;
                }
            }

            MaxMinStruct.MaxElementsOfArray = maxElementsOfArray;
            MaxMinStruct.MinElementsOfArray = minElementsOfArray;
        }

        /// <summary>
        /// Выводит ступенчатый массив в консоль.
        /// </summary>
        /// <param name="array">Исследуемый массив.</param>
        private static void PrintJaggedArray(int[][] array)
        {
            int iterator = 0;
            foreach (int[] subarray in array)
            {
                if (iterator > 0)
                {
                    Console.WriteLine("\n");
                }

                int[] tempsubarray = subarray.ToArray();

                foreach (int value in tempsubarray)
                {
                    Console.Write(value + " ");
                }

                iterator++;
            }
        }
    }
}
