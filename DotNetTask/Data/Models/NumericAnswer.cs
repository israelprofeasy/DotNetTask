using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class NumericAnswer : Numeric
{
    [JsonProperty(PropertyName="answer")]
    public string Answer { get; set; }
}