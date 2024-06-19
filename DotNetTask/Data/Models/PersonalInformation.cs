using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class PersonalInformation
{
    [Required]
    [JsonProperty(PropertyName="firstName")]
    public string FirstName { get; set; }
    [Required]
    [JsonProperty(PropertyName="lastName")]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    [JsonProperty(PropertyName="email")]
    public string Email { get; set; }
    
    [Phone]
    [JsonProperty(PropertyName="phone")]
    public string Phone { get; set; }
    
    [JsonProperty(PropertyName="nationality")]
    public string Nationality { get; set; }
    
    [JsonProperty(PropertyName="currentResidence")]
    public string CurrentResidence { get; set; }
    
    [JsonProperty(PropertyName="idNumber")]
    public string IDNumber { get; set; }
    
    [JsonProperty(PropertyName="dateOfBirth")]
    public DateTime DateOfBirth { get; set; }
    
    [JsonProperty(PropertyName="gender")]
    public string Gender { get; set; }
}