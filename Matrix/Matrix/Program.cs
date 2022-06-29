

while (true)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Welcome to Matrix :)");
        Console.WriteLine();
        Console.ResetColor();

        Console.WriteLine("Please enter the number of rows:");
        int numberOfRows = Convert.ToInt32(Console.ReadLine());
        if (numberOfRows <= 1)
            throw new Exception();

        Console.WriteLine("Please enter the number of columns:");
        int numberOfColumns = Convert.ToInt32(Console.ReadLine());
        if (numberOfColumns <= 1)
            throw new Exception();

        Console.WriteLine("Please enter the length of the side of square:");
        int sideLength = Convert.ToInt32(Console.ReadLine());
        if (sideLength <= 1)
            throw new Exception();

        Console.WriteLine();


        var matrix = new Matrix.Matrix(numberOfRows, numberOfColumns);
        matrix.FindSquare(sideLength);

    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("  One of the following errors occurred:");
        Console.WriteLine("* You must enter number!");
        Console.WriteLine("* Number of rows must be greater than one!");
        Console.WriteLine("* Number of columns must be greater than one!");
        Console.WriteLine("* The Length of the side must be greater than one!");
        Console.ResetColor();
    }



    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("Press 'Enter' to try again, or any another keys to exit...");
    Console.ResetColor();

    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        Console.Clear();
        continue;
    }
    else
        Environment.Exit(0);
}