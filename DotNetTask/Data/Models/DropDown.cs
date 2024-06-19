using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class DropDown: QuestionModel
{
    [JsonProperty(PropertyName="choice")]
    public List<string> Choice { get; set; }
}