// See https://aka.ms/new-console-template for more information
string[] log = new string[100];
int num1, num2;
int choice = 0;

void input()
{

    Console.WriteLine("Enter the numbers: ");
    string? s1 = Console.ReadLine();
    string? s2 = Console.ReadLine();
    num1 = int.Parse(s1);
    num2 = int.Parse(s2);
    Console.WriteLine("Operation Menu: ");
    Console.WriteLine("1. Addition ");
    Console.WriteLine("2. Subtraction ");
    Console.WriteLine("3. Multiplication ");
    Console.WriteLine("4.Division ");
    choice = int.Parse(Console.ReadLine());
}

input();

