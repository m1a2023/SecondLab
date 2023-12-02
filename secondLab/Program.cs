using System.Linq.Expressions;

namespace SecondLab;

class Output
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<string> listInput = new List<string>();
        listInput = Methods.GetList(input);


        foreach(string j in listInput) { Console.Write(j, " "); }
        Console.WriteLine();

        double result = Methods.GetResult(listInput);
        Console.WriteLine(result);
    }
}