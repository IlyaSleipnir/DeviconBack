using System.Xml.Serialization;

namespace DeviconBack.Services.InputDTOs
{
    public class ValuteDto
    {
        [XmlElement("Value")]
        public string ValueString { get; set; }

        [XmlIgnore]
        public decimal Value => decimal.Parse(ValueString);

        //[XmlElement("Nominal")]
        public int Nominal { get; set; }

        //[XmlElement("CharCode")]
        public string CharCode { get; set; }

        [XmlElement("VunitRate")]
        public string VunitRateString { get; set; }

        [XmlIgnore]
        public decimal VunitRate => decimal.Parse(VunitRateString);
    }
}
