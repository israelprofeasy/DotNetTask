using DotNetTask.Commons;
using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class ParagraphAnswer : Paragraph
{
    [WordCount(5, 500, ErrorMessage = "The description must be between 5 and 500 words.")]
    [JsonProperty(PropertyName="answer")]
    public string Answer { get; set; }
}