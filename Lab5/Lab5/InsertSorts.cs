namespace Lab5;

/// <summary>
/// Сортировка включения
/// </summary>
public class InsertSorts
{
    public static void GnomeSort(int[] list)
    {
        int i = 1;
        int j = 2;
        while (i < list.Length)
        {
            if (list[i - 1] > list[i])
            {
                i = j;
                j = j + 1;
            }
            else
            {
                (list[i - 1], list[i]) = (list[i], list[i - 1]);
                i = i - 1;
                if (i == 0)
                {
                    i = j;
                    j = j + 1;
                }
            }
        }
    }

    public static void InsertionSort(int[] list)
    {
        int inner, temp;

        for (int outer = 1; outer < list.Length; outer++)
        {

            temp = list[outer];
            inner = outer;
            while (inner > 0 && list[inner - 1] >= temp)
            {
                list[inner] = list[inner - 1];
                inner -= 1;
            }

            list[inner] = temp;
        }
    }

}