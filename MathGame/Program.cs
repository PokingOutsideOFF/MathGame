// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;

class MathGame
{
    private List<string> log = new List<string>();
    private int num1, num2;
    private int choice;
    private int answer;
    private string? readResult;
    private int gamesPlayed = 1;
    private Stopwatch stopwatch = new Stopwatch();

    public void Run()
    {
        int i = 0;
        do
        {
            Menu();
            int calculatedResult;
            stopwatch.Start();
            switch (choice)
            {

                case 1:
                    log.Add($"\nGame {gamesPlayed}");
                    gamesPlayed++;
                    Operation('+');
                    calculatedResult = num1 + num2;
                    break;
                case 2:
                    log.Add($"\nGame {gamesPlayed}");
                    gamesPlayed++;
                    Operation('-');
                    calculatedResult = num1 - num2;
                    break;
                case 3:
                    log.Add($"\nGame {gamesPlayed}");
                    gamesPlayed++;
                    Operation('*');
                    calculatedResult = num1 * num2;
                    break;
                case 4:
                    log.Add($"\nGame {gamesPlayed}");
                    gamesPlayed++;
                    Operation('/');
                    calculatedResult = num1 / num2;
                    break;
                case 5:
                    LogHistory();
                    continue;
                case 6:
                    Console.WriteLine("\nExiting....\n");
                    continue;
                default:
                    Console.WriteLine("\nInvalid Choice\n");
                    continue;
            }
            Input();
            Compare(calculatedResult);
            stopwatch.Reset();


        } while (choice != 6 && i < 100);

    }

    int SetDifficulty()
    {
        do
        {
            Console.WriteLine($"\nEnter difficulty level (1-3)");
            readResult = Console.ReadLine();
            if (int.TryParse(readResult, out int difficultyLevel))
            {
                if (difficultyLevel <= 0 || difficultyLevel > 3)
                {
                    Console.WriteLine("Invalid level");
                }
                else
                {
                    return difficultyLevel;
                }
            }
            else
            {
                Console.WriteLine("Enter integers");
            }
        } while (true);
    }

    void Menu()
    {
        do
        {
            Console.WriteLine("\nOperation Menu: ");
            Console.WriteLine("1. Addition ");
            Console.WriteLine("2. Subtraction ");
            Console.WriteLine("3. Multiplication ");
            Console.WriteLine("4. Division ");
            Console.WriteLine("5. Log History ");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter choice ");
            readResult = Console.ReadLine();
            if (int.TryParse(readResult, out choice))
            {
                break;
            }
            else
                Console.WriteLine("\nEnter valid integer!!!");
        } while (true);
        if (choice < 5)
            GenerateNumbers(SetDifficulty());
    }

    void GenerateNumbers(int difficultyLevel)
    {
        Random numGenerator = new Random();
        if(difficultyLevel == 1){
            num1 = numGenerator.Next(1, 10);
            num2 = numGenerator.Next(1, 10);
        }
        else if(difficultyLevel == 2){
            num1 = numGenerator.Next(10, 101);
            num2 = numGenerator.Next(1, 10);
        }
        else{
            num1 = numGenerator.Next(10, 101);
            num2 = numGenerator.Next(10, num1);  
        }
        
        if (choice == 4)
        {
            while (true)
            {
                if (num1 % num2 == 0)
                    break;
                num2 = numGenerator.Next(1, num1);
            }
        }
    }

    void Input()
    {
        bool incorrectInput = true;
        do
        {
            Console.Write("Enter you ans: ");
            readResult = Console.ReadLine();

            if (int.TryParse(readResult, out answer))
                incorrectInput = false;
            else
                Console.WriteLine("Enter valid Integer");
        } while (incorrectInput);
    }


    void Operation(char operation)
    {
        string question = $"What is {num1} {operation} {num2}?";
        Console.WriteLine(question);
        log.Add(question);
    }

    void LogHistory()
    {
        if (log.Count == 0)
        {
            Console.WriteLine("\nNo games played yet!!");
            return;
        }
        foreach (string str in log)
        {
            Console.WriteLine(str);
        }
        Console.WriteLine();
    }

    void Compare(int calculatedResult)
    {
        log.Add($"Your answer: {answer}");
        if (calculatedResult == answer)
        {
            log.Add("Congrats! Your answer is correct");
            Console.WriteLine("Congrats! Your answer is correct");
        }
        else
        {
            log.Add("Sorry your answer is wrong");
            Console.WriteLine("Sorry your answer is wrong");
        }
        stopwatch.Stop();
        TimeSpan timeTaken = stopwatch.Elapsed;
        log.Add($"Time taken: {timeTaken.Seconds} seconds and {timeTaken.Milliseconds} milliseconds.");
        Console.WriteLine($"Time taken: {timeTaken.Seconds} seconds and {timeTaken.Milliseconds} milliseconds.");
    }

    public static void Main(string[] args)
    {
        MathGame ob = new MathGame();
        ob.Run();
    }

}
