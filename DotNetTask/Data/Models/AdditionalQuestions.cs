using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class AdditionalQuestions
{
    
    [JsonProperty(PropertyName="dates")]
    public List<Date> Dates { get; set; }
    
    [JsonProperty(PropertyName="numerics")]
    public List<Numeric> Numerics { get; set; }
    
    [JsonProperty(PropertyName="dropDowns")]
    public List<DropDown> DropDowns { get; set; }
    
    [JsonProperty(PropertyName="paragraphs")]
    public List<Paragraph> Paragraphs { get; set; }
    
    [JsonProperty(PropertyName="multiChoices")]
    public List<MultiChoice> MultiChoices { get; set; }
    
    [JsonProperty(PropertyName="yesNo")]
    public List<Yes_No> YesNo { get; set; }
}