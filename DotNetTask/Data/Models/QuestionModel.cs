using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class QuestionModel
{
    
    [JsonProperty(PropertyName="questionType")]
    public QuestionType QuestionType { get; set; }
    
    [JsonProperty(PropertyName="question")]
    public string Question { get; set; }
}

public enum QuestionType
{
    Paragraph,
    Dropdown,
    Date,
    Yes_No,
    Numeric,
    Multichoice
}