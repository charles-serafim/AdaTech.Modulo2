using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Functions;

public static class Utils
{
    private static int number;
    private static double doubleNumber;
    private static decimal decimalNumber;
    private static bool option;
    private static string? input;

    public static int ReadOption(int min, int max, string? question = null)
    {
        bool valid = false;

        while (!valid)
        {
            Console.WriteLine();
            Console.WriteLine(question == null ? "Digite uma opção: " : $"{question}: ");
            input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                if (number >= min && number <= max) valid = true;
                else
                {
                    Console.WriteLine($"Digite um número entre {min} e {max}");
                }
            }
            else Console.WriteLine("Digite um número válido");
        }

        return number;
    }

    public static T ReadValue<T>(int? min, int? max, string? question = null) where T : struct
    {
        bool valid = false;
        T result = default;

        while (!valid)
        {
            Console.WriteLine(question == null ? $"Digite um valor {typeof(T).Name.ToLower()}: " : $"{question}: ");
            input = Console.ReadLine();

            if (typeof(T) == typeof(int) && int.TryParse(input, out int intValue))
            {
                result = (T)(object)intValue;
            }
            else if (typeof(T) == typeof(double) && double.TryParse(input, out double doubleValue))
            {
                result = (T)(object)doubleValue;
            }
            else if (typeof(T) == typeof(decimal) && decimal.TryParse(input, out decimal decimalValue))
            {
                result = (T)(object)decimalValue;
            }
            else
            {
                Console.WriteLine($"Digite um {typeof(T).Name.ToLower()} válido");
                continue;
            }

            if (min != null && max != null && result is IComparable comparableResult)
            {
                if (comparableResult.CompareTo(min) < 0 || comparableResult.CompareTo(max) > 0)
                {
                    Console.WriteLine($"Digite um valor entre {min} e {max}.");
                    continue;
                }
            }

            valid = true;
        }

        return result;
    }
    public static string LerSenha()
    {
        string senha = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // verifica se a tecla pressionada é uma tecla de caractere
            if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar))
            {
                senha += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
            {
                senha = senha.Substring(0, senha.Length - 1);
                Console.Write("\b \b"); // apaga o último caractere digitado
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();

        return Utils.Hash(senha);
    }

    public static string Hash(string input)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

    public static int ReadInt(string? question)
    {
        bool valid = false;

        while (!valid)
        {
            Console.WriteLine(question == null ? "Digite um número inteiro: " : $"{question}: ");
            input = Console.ReadLine();

            if (int.TryParse(input, out number)) valid = true;
            else Console.WriteLine("Digite um número válido");
        }

        return number;
    }

    public static double ReadDouble(string? question)
    {
        bool valid = false;

        while (!valid)
        {
            Console.WriteLine(question == null ? "Digite um número: " : $"{question}: ");
            input = Console.ReadLine();

            if (double.TryParse(input, out doubleNumber)) valid = true;
            else Console.WriteLine("Digite um número válido");
        }

        return doubleNumber;
    }

    public static decimal ReadDecimal(string? question)
    {
        bool valid = false;

        while (!valid)
        {
            Console.WriteLine(question == null ? "Digite um número: " : $"{question}: ");
            input = Console.ReadLine();

            if (decimal.TryParse(input, out decimalNumber)) valid = true;
            else Console.WriteLine("Digite um número válido");
        }

        return decimalNumber;
    }

    public static bool ReadYesOrNo(string question)
    {
        Console.WriteLine();
        Console.WriteLine($"{question}? (s/n)");

        while (true)
        {
            string input = Console.ReadLine()?.ToLower();

            if (Regex.IsMatch(input, "^(s(im)?|n(ao|ão)|n(ao)?o?)$")) return input.StartsWith("s");

            Console.WriteLine("Entrada inválida.");
            Console.WriteLine($"{question} ? (s / n)");
            Console.WriteLine();
        }
    }

    public static void GoOn()
    {
        Console.WriteLine("Aperte qualquer tecla para continuar...");
        Console.ReadLine();
    }

    public static void PrintArray(int[] array)
    {
        foreach (int numero in array) Console.Write($"{numero}{new string(' ', 5 - numero.ToString().Length)}");
        Console.WriteLine();
    }
}
