using Message.Converter;
using System.Text.Json.Serialization;

namespace Message.Commands
{
    public class AddProfessorCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime Birthday { get; set; }
        public Guid SemesterId { get; set; }
        public List<Guid> CoursesId { get; set; }
        public List<decimal> Salaries { get; set; }
    }
}
