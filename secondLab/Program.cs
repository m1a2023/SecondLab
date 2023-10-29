class Solution
{
    static void Main()
    {
        string input = Console.ReadLine();
        Calculate(input);
    }

    public static void Calculate(string input)
    {
        List<double> Digits = new List<double>();
        List<char> Symbols = new List<char>();
        string timeBox = "", updateTime = "";
        char space = ' ';

        for (int i = 0; i < input.Length; ++i)
        {
            if (char.IsDigit(input[i]))
                timeBox += input[i];
            else
            {
                if (input[i] != space)
                {
                    Digits.Add(double.Parse(timeBox));
                    Symbols.Add(input[i]);
                    timeBox = updateTime;
                }

            }
        }
        if (!string.IsNullOrEmpty(timeBox))
            Digits.Add(double.Parse(timeBox));

        double result = 0d, timeDigitBox = 0d, emptyBox = 0d;
        List<double> newDigits = new List<double>(Digits);
        int j = 0;
        double output;
        while (j < Symbols.Count)
        {
            switch (Symbols[j])
            {
                case '+':
                    timeDigitBox += newDigits[j] + newDigits[j + 1];
                    break;
                case '-':
                    timeDigitBox += newDigits[j] - newDigits[j + 1];
                    break;
                case '*':
                    timeDigitBox += newDigits[j] * newDigits[j + 1];
                    break;
                case '/':
                    timeDigitBox += newDigits[j] / newDigits[j + 1];
                    break;
            }
            newDigits[j + 1] = timeDigitBox;
            timeDigitBox = emptyBox;
            j++;

        }
        output = newDigits[^1];


        Console.WriteLine(output);
    }
}
