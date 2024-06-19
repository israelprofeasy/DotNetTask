using Newtonsoft.Json;

namespace DotNetTask.Data.Models;

public class AdditionalQuestionAnswers
{
    
    [JsonProperty(PropertyName="dates")]
    public List<DateAnswer> Dates { get; set; }
    
    [JsonProperty(PropertyName="numerics")]
    public List<NumericAnswer> Numerics { get; set; }
    
    [JsonProperty(PropertyName="dropDowns")]
    public List<DropDownAnswer> DropDowns { get; set; }
    
    [JsonProperty(PropertyName="paragraphs")]
    public List<ParagraphAnswer> Paragraphs { get; set; }
    
    [JsonProperty(PropertyName="multiChoices")]
    public List<MultiChoiceAnswer> MultiChoices { get; set; }
    
    [JsonProperty(PropertyName="yesNo")]
    public List<Yes_NoAnswer> YesNo { get; set; }
}