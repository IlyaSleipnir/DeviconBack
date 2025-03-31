using DeviconBack.Services.InputDTOs;

namespace DeviconBack.Data.Entities
{
    public class ValuteCourse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Valute> Valutes { get; set; }

        public ValuteCourse() {}

        public ValuteCourse(ValuteCourseDto valuteCourseDto)
        {
            Date = valuteCourseDto.Date;
            Valutes = valuteCourseDto.Valutes.Select(x => new Valute(x)).ToList();
        }
    }
}
