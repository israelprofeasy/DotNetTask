using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class MultiChoice : QuestionModel
{
    [JsonProperty(PropertyName="choice")]
    public List<string> Choice { get; set; }
    [JsonProperty(PropertyName="MmxChoice")]
    public int MaxChoice { get; set; }
}