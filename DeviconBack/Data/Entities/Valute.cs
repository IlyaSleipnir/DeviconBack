using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using DeviconBack.Services.InputDTOs;

namespace DeviconBack.Data.Entities
{
    public class Valute
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int Nominal { get; set; }
        public string CharCode { get; set; }
        public decimal VunitRate { get; set; }
        [JsonIgnore]
        public ValuteCourse ValuteCourse { get; set; }

        public Valute() { }

        public Valute(ValuteDto valuteDto)
        {
            Value = valuteDto.Value;
            Nominal = valuteDto.Nominal;
            CharCode = valuteDto.CharCode;
            VunitRate = valuteDto.VunitRate;
        }
    }
}
