namespace Strategy.Метод_пузырьковой_сортировки
{
    using System.Linq;

    internal class SortingArrayByMax : IStrategy
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
        /// Сортирует переданный массив по максимальным элементам строк.
        /// </summary>
        /// <param name="array">Исследуемый массив.</param>
        /// <param name="length">Длина исследуемого массива.</param>
        /// <param name="arrayOfMaxElements">Массив максимальных элементов строк исследуемого массива.</param>
        /// <param name="toUp">Сортировать по возрастанию.</param>
        /// <returns>Двумерный отсортированный массив.</returns>
        public int[][] SortArray(int[][] array, int length, int[] arrayOfMaxElements, bool toUp)
        {
            int[][] copyArray = CopyTwodimensionalJaggedArray(array, length);
            int[] copyMaxElementsOfArray = CopyOnedimensinalArray(arrayOfMaxElements, length);

            foreach (int[] subarray in copyArray)
            {
                int iterator = 0;

                if (toUp == true)
                {
                    foreach (int value in copyMaxElementsOfArray)
                    {
                        try
                        {
                            if (copyMaxElementsOfArray[iterator] > copyMaxElementsOfArray[iterator + 1])
                            {
                                int tempNumber = copyMaxElementsOfArray[iterator];
                                int[] tempSubArray = copyArray[iterator];

                                copyMaxElementsOfArray[iterator] = copyMaxElementsOfArray[iterator + 1];
                                copyArray[iterator] = copyArray[iterator + 1];

                                copyMaxElementsOfArray[iterator + 1] = tempNumber;
                                copyArray[iterator + 1] = tempSubArray;
                            }
                        }
                        catch
                        {
                            continue;
                        }

                        iterator++;
                    }
                }
                else
                {
                    foreach (int value in copyMaxElementsOfArray)
                    {
                        try
                        {
                            if (copyMaxElementsOfArray[iterator] < copyMaxElementsOfArray[iterator + 1])
                            {
                                int tempNumber = copyMaxElementsOfArray[iterator];
                                int[] tempSubArray = copyArray[iterator];

                                copyMaxElementsOfArray[iterator] = copyMaxElementsOfArray[iterator + 1];
                                copyArray[iterator] = copyArray[iterator + 1];

                                copyMaxElementsOfArray[iterator + 1] = tempNumber;
                                copyArray[iterator + 1] = tempSubArray;
                            }
                        }
                        catch
                        {
                            break;
                        }

                        iterator++;
                    }
                }
            }

            return copyArray;
        }
    }
}
