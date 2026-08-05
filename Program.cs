namespace Cryo;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        System.Console.WriteLine(new PreProcessor().GetMethod(args[0]));
    }
}