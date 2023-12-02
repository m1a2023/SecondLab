using System;
using System.Collections.Generic;

namespace SecondLab;

class Methods
{
	public static List<string> GetList(string input)
	{
		int i = 0; string box = "";
		List<string> output = new List<string>();

		while (i != input.Length)
		{
			if (char.IsDigit(input[i]))
				box += input[i];

			else
			{
				output.Add(box);

				if (input[i] == ' ') continue;
				else
					output.Add(input[i].ToString());
				box = "";
			}
			i++;
		}
		if (!string.IsNullOrEmpty(box))
			output.Add(box);
		return output;
	}

	public static double GetResult(List<string> input)
	{
		List<string> operators = GetListOperators(input);
		List<double> digits = GetListDigits(input);
		int j = 0; double result = 0d;
		while (j < operators.Count)
		{

			if (operators[j] == "*")
			{
				result = Calculate(digits[j], digits[j + 1], operators[j]);
				digits[j] = result;
				digits.RemoveAt(j + 1);
				operators.RemoveAt(j);
			}
			else if (operators[j] == "/")
			{
				if (digits[j + 1] != 0)
				{
					result = Calculate(digits[j], digits[j + 1], operators[j]);
					digits[j] = result;
					digits.RemoveAt(j + 1);
					operators.RemoveAt(j);
				}
			}
			else j++;
		}

		j = 0;
		while (j < operators.Count)
		{
			if (operators[j] == "+")
			{
				result = Calculate(digits[j], digits[j + 1], operators[j]);
				digits[j] = result;
				digits.RemoveAt(j + 1);
				operators.RemoveAt(j);
			}
			else if (operators[j] == "-")
			{
				result = Calculate(digits[j], digits[j + 1], operators[j]);
				digits[j] = result;
				digits.RemoveAt(j + 1);
				operators.RemoveAt(j);
			}
			else j++;
		}

		return digits[^1];
	}

	static double Calculate(double a, double b, string sym)
	{
		return sym switch
		{
			"*" => a * b,
			"/" => a / b,
			"+" => a + b,
			"-" => a - b
		};
	}

	static int GetHighestPriorityIndex(List<string> input)
	{

		for (int i = 0; i < input.Count; i++)
		{
			if (input[i] == "*" || input[i] == "/")
			{
				return i;
			}
			else if (input[i] == "+" || input[i] == "-")
				return i;
		}
		return -1;
	}

	static List<string> GetListOperators(List<string> input)
	{
		List<string> listSymbolOutput = new List<string>();

		foreach (string element in input)
		{
			if (element == "*" || element == "/" || element == "+" || element == "-")
			{
				listSymbolOutput.Add(element);
			}
		}

		return listSymbolOutput;
	}

	static List<double> GetListDigits(List<string> input)
	{
		List<double> output = new List<double>();

		foreach (string element in input)
		{
			if (double.TryParse(element, out double result))
				output.Add(result);
		}

		return output;
	}
}
