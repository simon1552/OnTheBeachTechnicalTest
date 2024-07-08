using Newtonsoft.Json;

namespace OnTheBeachTechnicalTest
{
    public class Flight
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("airline")]
        public string Airline { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("departure_date")]
        public string DepartureDate { get; set; }
    }
}
