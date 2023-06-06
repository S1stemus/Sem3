namespace Lab5;

/// <summary>
/// Сортировки слиянием
/// </summary>
public class CombiningSorts
{
    public static void MergeSort(int[] a) => MergeSort(a, 0, a.Length - 1);
    static void MergeSort(int[] a, int l, int r)
    {
        int q;

        if (l < r)
        {
            q = (l + r) / 2;
            MergeSort(a, l, q);
            MergeSort(a, q + 1, r);
            Merge(a, l, q, r);
        }
    }

    static void Merge(int[] a, int l, int m, int r)
    {
        int i, j, k;

        int n1 = m - l + 1;
        int n2 = r - m;

        int[] left = new int[n1 + 1];
        int[] right = new int[n2 + 1];

        for (i = 0; i < n1; i++)
        {
            left[i] = a[l + i];
        }

        for (j = 1; j <= n2; j++)
        {
            right[j - 1] = a[m + j];
        }

        left[n1] = int.MaxValue;
        right[n2] = int.MaxValue;

        i = 0;
        j = 0;

        for (k = l; k <= r; k++)
        {
            if (left[i] < right[j])
            {
                a[k] = left[i];
                i = i + 1;
            }
            else
            {
                a[k] = right[j];
                j += 1;
            }
        }
    }

    public static void BoseNelson(int[] data)
    {
        var m = 1;
        while (m < data.Length)
        {
            int j = 0;
            while (j + m < data.Length)
            {
                BoseNelsonMerge(data, j, m, m);
                j = j + m + m;
            }

            m += m;
        }
    }

    static void BoseNelsonMerge(int[] data, int j, int r, int m)
    {
        if (j + r < data.Length)
        {
            if (m == 1)
            {
                if (data[j] > data[j + r])
                    (data[j], data[j + r]) = (data[j + r], data[j]);
            }
            else
            {
                m /= 2;
                BoseNelsonMerge(data, j, r, m);
                if (j + r + m < data.Length)
                    BoseNelsonMerge(data, j + m, r, m);
                BoseNelsonMerge(data, j + m, r - m, m);
            }
        }
    }
}