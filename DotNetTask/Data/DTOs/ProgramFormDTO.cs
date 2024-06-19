using System.ComponentModel.DataAnnotations;
using DotNetTask.Data.Models;
using Newtonsoft.Json;

namespace DotNetTask.Data.DTOs;

public class ProgramFormDTO
{
    [Required(ErrorMessage = "Program title is required")]
    [JsonProperty(PropertyName="programTitle")]
    public string ProgramTitle { get; set; }
    
    [Required(ErrorMessage = "Program description is required")]
    [JsonProperty(PropertyName="programDescription")]
    public string ProgramDescription { get; set; }
    
    [JsonProperty(PropertyName="additionalQuestions")]
    public AdditionalQuestions AdditionalQuestions { get; set; }
}