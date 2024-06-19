using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class Yes_NoAnswer : Yes_No
{
    
    [JsonProperty(PropertyName="answer")]
    public string Answer { get; set; }
}