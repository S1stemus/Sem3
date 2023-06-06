namespace Lab5;

/// <summary>
/// Сортировка выборки
/// </summary>
public class SelectionSorts
{
    public static void SelectionDefault(int[] list)
    {
        for (int i = 0; i < list.Length - 1; ++i)
        {
            int min = i;
            for (int j = i + 1; j < list.Length; ++j)
            {
                if (list[j].CompareTo(list[min]) < 0)
                {
                    min = j;
                }
            }

            (list[i], list[min]) = (list[min], list[i]);
        }
    }

    public static void Shaker(int[] list)
    {
        int left = 0, right = list.Length - 1;

        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (list[i] > list[i + 1])
                {
                    int j = i + 1;
                    (list[i], list[j]) = (list[j], list[i]);
                }
            }

            right--;

            for (int i = right; i > left; i--)
            {
                if (list[i - 1] > list[i])
                {
                    int i1 = i - 1;
                    (list[i1], list[i]) = (list[i], list[i1]);
                }
            }

            left++;
        }
    }
}