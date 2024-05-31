using System.Text.Json.Serialization;

namespace LibModels
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsVoted { get; set; }
        public string FullName { get { return Name + " " + SurName; } }
    }
}
