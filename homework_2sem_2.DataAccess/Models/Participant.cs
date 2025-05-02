using System.Text.Json.Serialization;

namespace homework_2sem_2.DataAccess.Models
{
    public class Participant
    {
        public Guid Id { get; set; }

        public ContactInfo? ContactInfo { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Ticket> Tickets { get; set; } = [];

    }

    public class ContactInfo
    {
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
