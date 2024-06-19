using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class NumericAnswer : Numeric
{
    [JsonProperty(PropertyName="answer")]
    public int Answer { get; set; }
}