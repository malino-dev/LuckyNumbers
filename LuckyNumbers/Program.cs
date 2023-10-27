int lower, upper;

/*Console.Write("Lower bound: ");
if (!int.TryParse(Console.ReadLine() ?? "1", out lower)) lower = 2;*/
lower = 1;

/*Console.Write("Upper bound: ");
if (!int.TryParse(Console.ReadLine() ?? "1", out upper)) upper = 100;*/
upper = 100;

int?[] numbers = Enumerable.Range(lower, upper - lower).Select(x => (int?) x).ToArray();

for(int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] is >= -1 and <= 1) continue;
    if (numbers[i] is null) continue;

    int k = 0;
    int number = (int)numbers[i]!;

    for(int j = 0; j < numbers.Length; j++)
    {
        if (numbers[j] is null) continue;

        if (k != 0 && (k + lower) % number == 0)
        {
            numbers[j] = null;
        }

        k++;
    }
}

IEnumerable<int> result = numbers
    .Where(x => x is not null)
    .Select(x => (int)x!);

Console.WriteLine();
Console.WriteLine("Lucky numbers: {0}", string.Join("\n", result));