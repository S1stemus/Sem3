namespace Lab5;

/// <summary>
/// Стортировки распределения
/// </summary>
public class ResortSorts
{
    public static void BucketSort (int[] array)
    {
        if (array.Length <= 1)
            return;
        
        int maxValue = array[0]; 
        int minValue = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
            {
                maxValue = array[i];
            }
            if (array[i] < minValue)
            {
                minValue = array[i];
            }
        }
        LinkedList<int>?[] bucket = new LinkedList<int>[maxValue - minValue + 1];
        for (int i = 0; i < array.Length; i++)
        {
            if (bucket[array[i] - minValue] == null)
            {
                bucket[array[i] - minValue] = new LinkedList<int>();
            }
            bucket[array[i] - minValue]!.AddLast(array[i]);
        }
        var index = 0;
    
        for (int i = 0; i < bucket.Length; i++)
        {
            if (bucket[i] != null)
            {
                LinkedListNode<int>? node = bucket[i]?.First;
                while (node != null)
                {
                    array[index] = node.Value;
                    node = node.Next; 
                    index++;
                }
            }
        }
    }
    
    public static void CountSort(int[] array)
    {
        var min = array[0];
        var max = array[0];
        foreach (int element in array)
        {
            if (element > max)
            {
                max = element;
            }
            else if (element < min)
            {
                min = element;
            }
        }

        var correctionFactor = min != 0 ? -min : 0;
        max += correctionFactor;

        var count = new int[max + 1];
        for (var i = 0; i < array.Length; i++)
        {
            count[array[i] + correctionFactor]++;
        }

        var index = 0;
        for (var i = 0; i < count.Length; i++)
        {
            for (var j = 0; j < count[i]; j++)
            {
                array[index] = i - correctionFactor;
                index++;
            }
        }
    }
}