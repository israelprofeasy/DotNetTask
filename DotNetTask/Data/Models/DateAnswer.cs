using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class DateAnswer : Date
{
    [JsonProperty(PropertyName="answer")]
    public DateTime Answer { get; set; }
}