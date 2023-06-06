using System.Diagnostics;
using Lab5;

var algs = new (string, Action<int[]>)[]
{
    ("Выбором", SelectionSorts.SelectionDefault),
    ("Шейкерная", SelectionSorts.Shaker),
    ("Гномья", InsertSorts.GnomeSort),
    ("Вставками", InsertSorts.InsertionSort),
    ("Блочная", ResortSorts.BucketSort),
    ("Подсчётом", ResortSorts.CountSort),
    ("Слиянием", CombiningSorts.MergeSort),
    ("БоузНельсона", CombiningSorts.BoseNelson)
};

var a = File.ReadAllBytes("/home/ansel/1.bin");
var b = new int[a.Length / 2];
for (int i = 0; i < a.Length / 2; i++)
{
    b[i] = BitConverter.ToInt16(a, i * 2);
}

a = null;

Console.WriteLine("Файл:");
foreach (var sort in algs)
{
    Console.Write($"Алгоритм: {sort.Item1}".PadRight(25));
    const int attempts = 3;
    long total = 0;
    for (int i = 0; i < attempts; i++)
    {
        var data = (int[]) b.Clone();
        Stopwatch s = new();
        s.Start();
        sort.Item2(data);
        s.Stop();
        total += s.ElapsedMilliseconds;
    }

    Console.WriteLine($"мс/оп: {total / attempts}");
}

Console.WriteLine();
Console.WriteLine("Случайный массив:");

var a3 = Enumerable.Repeat(0, 1000).Select(x => Random.Shared.Next(2000)).ToArray();
var a4 = Enumerable.Repeat(0, 10000).Select(x => Random.Shared.Next(2000)).ToArray();
var a5 = Enumerable.Repeat(0, 100000).Select(x => Random.Shared.Next(2000)).ToArray();

foreach (var sort in algs)
{
    Console.Write($"Алгоритм: {sort.Item1}".PadRight(25));
    long t3, t4, t5;

    var data = (int[]) a3.Clone();
    Stopwatch s = new();
    s.Start();
    sort.Item2(data);
    s.Stop();
    t3 = s.ElapsedMilliseconds;

    data = (int[]) a4.Clone();
    s = new();
    s.Start();
    sort.Item2(data);
    s.Stop();
    t4 = s.ElapsedMilliseconds;

    data = (int[]) a5.Clone();
    s = new();
    s.Start();
    sort.Item2(data);
    s.Stop();
    t5 = s.ElapsedMilliseconds;

    Console.WriteLine($"мс/оп: {t3.ToString(),-4} {t4.ToString(),-4} {t5.ToString(),-4}");
}