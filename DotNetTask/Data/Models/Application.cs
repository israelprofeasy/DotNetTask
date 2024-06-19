using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class Application
{
    [JsonProperty(PropertyName="id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName="programId")]
    public string ProgramId { get; set; }
    [JsonProperty(PropertyName="personalInformation")]
    public PersonalInformation PersonalInformation { get; set; }
    [JsonProperty(PropertyName="additionalQuestions")]
    public AdditionalQuestionAnswers AdditionalQuestions { get; set; }
    
}