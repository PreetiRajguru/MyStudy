using System.Text.Json.Serialization;

namespace Trial.Services.DTO
{
    public class ClientDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
    }
}
