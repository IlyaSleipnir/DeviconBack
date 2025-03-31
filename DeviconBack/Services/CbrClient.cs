using System.Xml.Serialization;
using DeviconBack.Data.Entities;
using DeviconBack.Services.InputDTOs;
using DeviconBack.Services.Interfaces;

namespace DeviconBack.Services
{
    public class CbrClient : ICbrClient
    {
        private readonly HttpClient _httpClient;

        public CbrClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ValuteCourse?> LoadData(DateTime date)
        {
            var dateReq = $"date_req={date.ToString("dd/MM/yyyy")}";
            var query = new Uri($"{_httpClient.BaseAddress}?{dateReq}");
            
            try
            {
                var response = await _httpClient.GetAsync(query);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStreamAsync();

                var serializer = new XmlSerializer(typeof(ValuteCourseDto));

                var a =  serializer.Deserialize(result) is not ValuteCourseDto dto 
                    ? null 
                    : new ValuteCourse(dto);
                return a;
            }
            catch
            {
                return null;
            }

        }
    }
}
