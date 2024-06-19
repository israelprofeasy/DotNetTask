using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class DropDownAnswer  :DropDown
{
    [JsonProperty(PropertyName="answer")]
    public string Answer { get; set; }
}