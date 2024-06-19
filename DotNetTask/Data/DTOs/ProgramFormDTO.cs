using System.ComponentModel.DataAnnotations;
using DotNetTask.Data.Models;
using Newtonsoft.Json;

namespace DotNetTask.Data.DTOs;

public class ProgramFormDTO
{
    [Required]
    [JsonProperty(PropertyName="programTitle")]
    public string ProgramTitle { get; set; }
    [Required]
    [JsonProperty(PropertyName="programDescription")]
    public string ProgramDescription { get; set; }
    
    [JsonProperty(PropertyName="additionalQuestions")]
    public AdditionalQuestions AdditionalQuestions { get; set; }
}