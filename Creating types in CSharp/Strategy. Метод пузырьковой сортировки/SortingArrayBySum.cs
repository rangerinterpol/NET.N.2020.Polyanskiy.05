namespace Strategy.Метод_пузырьковой_сортировки
{
    using System;
    using System.Linq;

    internal class SortingArrayBySum : IStrategy
    {
        /// <summary>
        /// Создает копию двумерного ступенчатого массива.
        /// </summary>
        /// <param name="array">Двумерный ступенчатый массив.</param>
        /// <param name="lengthArray">Длина массива.</param>
        /// <returns>Копия двумерного ступенчатого массива.</returns>
        private static int[][] CopyTwodimensionalJaggedArray(int[][] array, int lengthArray)
        {
            int[][] copyArray = new int[lengthArray][];

            int i = 0;

            foreach (int[] subarray in array)
            {
                // Во избежание зависимости нового массива от старого по адресу памяти добавлен метод ToArray();
                copyArray[i] = array[i].ToArray();

                i++;
            }

            return copyArray;
        }

        /// <summary>
        /// Создает копию одномерного массива.
        /// </summary>
        /// <param name="array">Одномерный массив.</param>
        /// <param name="lengthArray">Длина массива.</param>
        /// <returns>Копия одномерного массива.</returns>
        private static int[] CopyOnedimensinalArray(int[] array, int lengthArray)
        {
            int[] copyArray = new int[lengthArray];

            int i = 0;

            foreach (int value in array)
            {
                copyArray[i] = array[i];

                i++;
            }

            return copyArray;
        }

        /// <summary>
        /// Сортирует переданный массив по суммам элементов строк.
        /// </summary>
        /// <param name="array">Исследуемый массив.</param>
        /// <param name="length">Длина исследуемого массива.</param>
        /// <param name="arrayOfSums">Массив сумм строк исследуемого массива.</param>
        /// <param name="toUp">Сортировать по возрастанию.</param>
        /// <returns>Двумерный отсортированный массив.</returns>
        public int[][] SortArray(int[][] array, int length, int[] arrayOfSums, bool toUp)
        {
            int[][] copyArray = CopyTwodimensionalJaggedArray(array, length);
            int[] copyArrayOfSums = CopyOnedimensinalArray(arrayOfSums, length);

            int q;

            foreach (int shuffle in copyArrayOfSums)
            {
                try
                {
                    q = 0;

                    if (toUp == true)
                    {
                        foreach (int reshuffle in copyArrayOfSums)
                        {
                            if (copyArrayOfSums[q] > copyArrayOfSums[q + 1])
                            {
                                int tempNumber = copyArrayOfSums[q];
                                int[] tempSubArray = copyArray[q];

                                copyArrayOfSums[q] = copyArrayOfSums[q + 1];
                                copyArray[q] = copyArray[q + 1];

                                copyArrayOfSums[q + 1] = tempNumber;
                                copyArray[q + 1] = tempSubArray;
                            }

                            q++;
                        }
                    }
                    else
                    {
                        foreach (int reshuffle in copyArrayOfSums)
                        {
                            if (copyArrayOfSums[q] < copyArrayOfSums[q + 1])
                            {
                                int tempNumber = copyArrayOfSums[q];
                                int[] tempSubArray = copyArray[q];

                                copyArrayOfSums[q] = copyArrayOfSums[q + 1];
                                copyArray[q] = copyArray[q + 1];

                                copyArrayOfSums[q + 1] = tempNumber;
                                copyArray[q + 1] = tempSubArray;
                            }

                            q++;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }

            return copyArray;
        }
    }
}
