/*
Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

int rows = 0, columns = 0;
Random random = new Random();

if (!InputControl("Задайте размерность двумерного массива (m n)", ref rows, ref columns))
    return;

int[,] array = InitArray(rows, columns);

int[] sumArray = DoWorkArray(array);

PrintArrayWithResult(array, sumArray);

Console.WriteLine($"Результат: {Array.IndexOf(sumArray, sumArray.Min())+1} строка.");


# region methods

bool InputControl(string caption, ref int m, ref int n)
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\n{caption} (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputStringArray = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck =
            inputStringArray.Length == 2 &&
            int.TryParse(inputStringArray[0], out m) &&
            m > 0 &&
            int.TryParse(inputStringArray[1], out n) &&
            n > 0;

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int[,] InitArray(int m, int n)
{
    int[,] array = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i, j] = random.Next(0, 20);
        }
    }

    return array;
}

int[] DoWorkArray(int[,] array)
{
    int[] resultArray = new int[array.GetLength(0)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i,j];
        }
        resultArray[i] = sum;
    }

    return resultArray;
}

void PrintArrayWithResult(int[,] array, int[] sumArray)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t {(j == array.GetLength(1)-1 ? string.Concat("[", sumArray[i], "]"): "")}");
        }

        Console.WriteLine();
    }
}

# endregion




