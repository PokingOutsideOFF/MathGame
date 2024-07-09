// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

string[] log = new string[100];
int num1 = 0, num2 = 0;
int choice = 0;

void input()
{

    Console.WriteLine("Operation Menu: ");
    Console.WriteLine("1. Addition ");
    Console.WriteLine("2. Subtraction ");
    Console.WriteLine("3. Multiplication ");
    Console.WriteLine("4. Division ");
    Console.WriteLine("5. Log History ");
    Console.WriteLine("6. Exit");
    Console.Write("Enter choice ");
    choice = int.Parse(Console.ReadLine());

    if (choice < 5)
    {

        Console.WriteLine("Enter the numbers: ");
        string? s1 = Console.ReadLine();
        string? s2 = Console.ReadLine();
        num1 = int.Parse(s1);
        num2 = int.Parse(s2);
    }
}

void Add(int x, int y, int i)
{
    log[i] = $"{x} + {y} = {(x + y)}";
    Console.WriteLine($"\nResult: {(x + y)}\n");
}

void Subtract(int x, int y, int i)
{
    log[i] = $"{x} - {y} = {(x - y)}";
    Console.WriteLine($"\nResult: {(x - y)}\n");
}

void Multiply(int x, int y, int i)
{
    log[i] = $"{x} * {y} = {(x * y)}";
    Console.WriteLine($"\nResult: {(x * y)}\n");
}

void Division(int x, int y, int i)
{
    if (x % y == 0 && y != 0)
    {
        Console.WriteLine($"\nResult: {(x / y)}\n");
        log[i] = $"{x} / {y} = {(x / y)}";
    }
    else
    {
        Console.WriteLine("\nInvalid Operation\n");
        log[i] = "Invalid Operation";
    }
}

void LogHistory()
{
    Console.WriteLine("");
    foreach (string str in log)
    {
        if (str == null)
        {
            break;
        }
        Console.WriteLine(str);
    }
    Console.WriteLine();
}

int i = 0;
do
{

    input();
    switch (choice)
    {
        case 1:
            Add(num1, num2, i);
            break;
        case 2:
            Subtract(num1, num2, i);
            break;
        case 3:
            Multiply(num1, num2, i);
            break;
        case 4:
            Division(num1, num2, i);
            break;
        case 5:
            LogHistory();
            break;
        case 6:
            Console.WriteLine("\nExiting....\n");
            break;
        default:
            Console.WriteLine("\nInvalid Choice\n");
            break;
    }
    i++;
} while (choice != 6 && i < 100);

