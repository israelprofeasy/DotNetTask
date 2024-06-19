using DotNetTask.Data.Models;
using Newtonsoft.Json;

namespace DotNetTask.Data.DTOs;

public class ApplicationListDTO
{
    [JsonProperty(PropertyName="id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName="programId")]
    public string ProgramId { get; set; }
    [JsonProperty(PropertyName="personalInformation")]
    public PersonalInformation PersonalInformation { get; set; }
}