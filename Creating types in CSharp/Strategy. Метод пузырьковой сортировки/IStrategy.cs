namespace Strategy.Метод_пузырьковой_сортировки
{
    internal interface IStrategy
    {
        int[][] SortArray(int[][] array, int length, int[] arrayOfMinElements, bool toUp);
    }
}
