namespace Strategy.Метод_пузырьковой_сортировки
{
    internal class Context
    {
        private IStrategy strategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        /// <param name="strategy">Объект класса стратегии.</param>
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// Устанавливает стратегию, по которой будет выполняться следующий алгоритм.
        /// </summary>
        /// <param name="strategy">Объект класса стратегии.</param>
        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// Запускает процедуру сортировки массива в соответствующей стратегии.
        /// </summary>
        /// <param name="array">Исследуемый массив.</param>
        /// <param name="length">Длина исследуемого массива.</param>
        /// <param name="onedimensinalArray">Одномерный массив, определяющий выбор стратегии.</param>
        /// <param name="toUp">Сортировать по возрастанию.</param>
        /// <returns>Отсортированный думерный ступенчатый массив.</returns>
        public int[][] DoSort(int[][] array, int length, int[] onedimensinalArray, bool toUp)
        {
            int[][] copyArray = this.strategy.SortArray(array, length, onedimensinalArray, toUp);

            return copyArray;
        }
    }
}
