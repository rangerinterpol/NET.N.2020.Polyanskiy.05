namespace Strategy.Метод_пузырьковой_сортировки
{
    using System.Linq;

    internal class SortingArrayByMin : IStrategy
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
        /// Сортирует переданный массив по минимальным элементам строк.
        /// </summary>
        /// <param name="array">Исследуемый массив.</param>
        /// <param name="length">Длина исследуемого массива.</param>
        /// <param name="arrayOfMinElements">Массив минимальных элементов строк исследуемого массива.</param>
        /// <param name="toUp">Сортировать по возрастанию.</param>
        /// <returns>Двумерный отсортированный массив.</returns>
        public int[][] SortArray(int[][] array, int length, int[] arrayOfMinElements, bool toUp)
        {
            int[][] copyArray = CopyTwodimensionalJaggedArray(array, length);
            int[] copyMinElementsOfArray = CopyOnedimensinalArray(arrayOfMinElements, length);

            foreach (int[] subarray in copyArray)
            {
                int iterator = 0;

                if (toUp == true)
                {
                    foreach (int value in copyMinElementsOfArray)
                    {
                        try
                        {
                            if (copyMinElementsOfArray[iterator] > copyMinElementsOfArray[iterator + 1])
                            {
                                int tempNumber = copyMinElementsOfArray[iterator];
                                int[] tempSubArray = copyArray[iterator];

                                copyMinElementsOfArray[iterator] = copyMinElementsOfArray[iterator + 1];
                                copyArray[iterator] = copyArray[iterator + 1];

                                copyMinElementsOfArray[iterator + 1] = tempNumber;
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
                else
                {
                    foreach (int value in copyMinElementsOfArray)
                    {
                        try
                        {
                            if (copyMinElementsOfArray[iterator] < copyMinElementsOfArray[iterator + 1])
                            {
                                int tempNumber = copyMinElementsOfArray[iterator];
                                int[] tempSubArray = copyArray[iterator];

                                copyMinElementsOfArray[iterator] = copyMinElementsOfArray[iterator + 1];
                                copyArray[iterator] = copyArray[iterator + 1];

                                copyMinElementsOfArray[iterator + 1] = tempNumber;
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
