using System.ComponentModel.DataAnnotations;

namespace DotNetTask.Commons;

public class WordCount : ValidationAttribute
{
    private readonly int _minWords;
    private readonly int _maxWords;

    public WordCount(int minWords, int maxWords)
    {
        _minWords = minWords;
        _maxWords = maxWords;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        string input = value as string;
        if (string.IsNullOrEmpty(input))
        {
            return new ValidationResult("The input string cannot be null or empty.");
        }

        char[] delimiters = new char[] { ' ', '\r', '\n', '\t', ',', '.', '!', '?', ';', ':' };
        string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        int wordCount = words.Length;

        if (wordCount < _minWords || wordCount > _maxWords)
        {
            return new ValidationResult($"The number of words in the string must be between {_minWords} and {_maxWords}.");
        }

        return ValidationResult.Success;
    }
}