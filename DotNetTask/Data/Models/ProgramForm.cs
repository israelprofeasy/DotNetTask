using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class ProgramForm
{
    [JsonProperty(PropertyName="id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName="programTitle")]
    public string ProgramTitle { get; set; }
    
    [JsonProperty(PropertyName="programDescription")]
    public string ProgramDescription { get; set; }
    
    [JsonProperty(PropertyName="additionalQuestions")]
    public AdditionalQuestions AdditionalQuestions { get; set; }
}