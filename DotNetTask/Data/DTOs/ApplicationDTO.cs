using System.ComponentModel.DataAnnotations;
using DotNetTask.Data.Models;
using Newtonsoft.Json;

namespace DotNetTask.Data.DTOs;

public class ApplicationDTO
{
    [JsonProperty(PropertyName="programId")]
    [Required]
    public string ProgramId { get; set; }
    
    [JsonProperty(PropertyName="personalInformation")]
    public PersonalInformation PersonalInformation { get; set; }
    
    [JsonProperty(PropertyName="additionalQuestions")]
    public AdditionalQuestionAnswers AdditionalQuestions { get; set; }
}