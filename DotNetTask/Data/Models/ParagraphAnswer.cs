using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class ParagraphAnswer : Paragraph
{
    [JsonProperty(PropertyName="answer")]
    public string Answer { get; set; }
}