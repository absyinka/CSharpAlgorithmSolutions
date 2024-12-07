using System;
using System.Security.Cryptography;
using System.Text;

namespace AlgorithmSolutions;

public class Algorithms
{
    public static List<int> GetVowelPositions(string s)
    {
        Console.WriteLine("String is " + s);
        List<int> positions = new List<int>();

        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < vowels.Length; j++)
            {
                if (s[i] == vowels[j])
                {
                    positions.Add(i);
                }
            }
        }

        return positions;
    }

    public static string ShiftLetters(string inputString)
    {
        char[] newShiftedString = new char[inputString.Length];

        for (int i = 0; i < inputString.Length; i++)
        {
            char currentCharacter = inputString[i];

            if (currentCharacter >= 'a' && currentCharacter <= 'z')
            {
                newShiftedString[i] = currentCharacter == 'z' ? 'a' : (char)(currentCharacter + 1);
            }
            else if (currentCharacter >= 'A' && currentCharacter <= 'Z')
            {
                newShiftedString[i] = currentCharacter == 'Z' ? 'A' : (char)(currentCharacter + 1);
            }
            else 
            {
                newShiftedString[i] = currentCharacter;
            }
        }

        return new string(newShiftedString);
    }

    public static string ShiftLettersLeft(string inputString)
    {
        char[] newShiftedString = new char[inputString.Length];

        for (int i = 0; i < inputString.Length; i++)
        {
            char currentCharacter = inputString[i];

            if (currentCharacter >= 'a' && currentCharacter <= 'z')
            {
                newShiftedString[i] = currentCharacter == 'a' ? 'z' : (char)(currentCharacter - 1);
            }
            else if (currentCharacter >= 'A' && currentCharacter <= 'Z')
            {
                newShiftedString[i] = currentCharacter == 'A' ? 'Z' : (char)(currentCharacter - 1);
            }
            else
            {
                newShiftedString[i] = currentCharacter;
            }
        }

        return new string(newShiftedString);
    }


    public static string TransformCase(string inputString)
    {
        StringBuilder transformedString = new StringBuilder();

        foreach (char c in inputString)
        {
            if (c >= 'a' && c <= 'z') // Check if the character is lowercase
            {
                // Convert to uppercase by subtracting 32 (ASCII difference between lower and uppercase)
                transformedString.Append((char)(c - 32));
            }
            else if (c >= 'A' && c <= 'Z') // Check if the character is uppercase
            {
                // Convert to lowercase by adding 32 (ASCII difference between upper and lowercase)
                transformedString.Append((char)(c + 32));
            }
            else
            {
                // If it's not a letter, append it as is
                transformedString.Append(c);
            }
        }

        return transformedString.ToString();
    }

    public static string ReplaceCharacter(string inputString, char c1, char c2)
    {
        char[] newString = new char[inputString.Length];

        for (int i = 0; i < inputString.Length; i++)
        {
            newString[i] = inputString[i] == c1 ? c2 : inputString[i];
        }

        return new string(newString);
    }

    /// <summary>
    /// Swap pairs of character adjacent to one another. The last character is left alone if the total length of the string is odd number.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>Returns swapped pairs of strings</returns>
    public static string SwapPairs(string s)
    {
        char[] swapped = new char[s.Length];

        for (int i = 0; i < s.Length - 1; i += 2)
        {
            swapped[i] = s[i + 1];
            swapped[i + 1] = s[i];
        }

        if (s.Length % 2 != 0)
        {
            swapped[s.Length - 1] = s[s.Length - 1];
        }

        return new string(swapped);
    }

    public static string GenerateSecretKey(int keySizeInBytes = 32)
    {
        var key = new byte[keySizeInBytes];
        using (var random = RandomNumberGenerator.Create())
        {
            random.GetBytes(key);
        }
        return Convert.ToBase64String(key);
    }
}
