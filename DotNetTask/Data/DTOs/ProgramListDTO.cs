using Newtonsoft.Json;

namespace DotNetTask.Data.DTOs;

public class ProgramListDTO
{
    [JsonProperty(PropertyName="id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName="programTitle")]
    public string ProgramTitle { get; set; }
    
    [JsonProperty(PropertyName="programDescription")]
    public string ProgramDescription { get; set; }
}