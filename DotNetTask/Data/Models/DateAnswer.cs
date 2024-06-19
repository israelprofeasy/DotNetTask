using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class DateAnswer : Date
{
    [JsonProperty(PropertyName="answer")]
    public string Answer { get; set; }
}