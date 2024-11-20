using System.Text.RegularExpressions;

namespace Shared.Helpers;

public class SanitizeHelper
{
    public static string SanitizeJsonString(string input)
    {
        // Remove the triple backticks and the word "json"
        string result = Regex.Replace(input, @"```json|\n|```", string.Empty);

        // Trim any extra whitespace
        return result.Trim();
    }
}
