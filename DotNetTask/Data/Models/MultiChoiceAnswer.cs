using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class MultiChoiceAnswer : MultiChoice
{
    [JsonProperty(PropertyName="answer")]
    public List<string> Answer { get; set; }
}