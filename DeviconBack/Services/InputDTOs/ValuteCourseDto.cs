using DeviconBack.Data.Entities;
using System.Globalization;
using System.Xml.Serialization;

namespace DeviconBack.Services.InputDTOs
{
    [XmlRoot("ValCurs")]
    public class ValuteCourseDto
    {
        [XmlAttribute("Date")]
        public string DateString { get; set; }

        [XmlIgnore]
        public DateTime Date => DateTime.ParseExact(DateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);

        [XmlElement("Valute")]
        public List<ValuteDto> Valutes { get; set; }
    }
}
