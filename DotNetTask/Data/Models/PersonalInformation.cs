using System.ComponentModel.DataAnnotations;
using DotNetTask.Commons;
using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class PersonalInformation
{
    [Required(ErrorMessage = "First name is required")]
    [JsonProperty(PropertyName="firstName")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [JsonProperty(PropertyName="lastName")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email")]
    [JsonProperty(PropertyName="email")]
    public string Email { get; set; }
    
    [Phone(ErrorMessage = "Enter a valid phone number")]
    [JsonProperty(PropertyName="phone")]
    public string Phone { get; set; }
    
    [JsonProperty(PropertyName="nationality")]
    public string Nationality { get; set; }
    
    [JsonProperty(PropertyName="currentResidence")]
    public string CurrentResidence { get; set; }
    
    [JsonProperty(PropertyName="idNumber")]
    public string IDNumber { get; set; }
    
    [JsonProperty(PropertyName="dateOfBirth")]
    [DateOfBirthValidation(ErrorMessage = "Please enter a valid date of birth.")]
    public DateTime DateOfBirth { get; set; }
    
    [JsonProperty(PropertyName="gender")]
    [GenderValidation("Male", "Female", "Other", ErrorMessage = "Gender must be 'Male', 'Female', or 'Other'.")]
    public string Gender { get; set; }
}