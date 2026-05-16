namespace MyBubbleSortProj;

internal class MyQuickSort<T> where T : IComparable<T>
{
    public void Sort(T[] items)
    {
        if (items == null || items.Length < 2) return;
        QuickSort(items, 0, items.Length - 1);
    }

    private void QuickSort(T[] items, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(items, left, right);


            QuickSort(items, left, pivotIndex - 1);
            QuickSort(items, pivotIndex + 1, right);
        }
    }

    private int Partition(T[] items, int left, int right)
    {

        T pivot = items[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (items[j].CompareTo(pivot) < 0)
            {
                i++;
                Swap(items, i, j);
            }
        }

        Swap(items, i + 1, right);
        return i + 1;
    }

    private void Swap(T[] items, int index1, int index2)
    {
        T temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }
}