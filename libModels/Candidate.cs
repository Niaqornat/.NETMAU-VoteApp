namespace LibModels
{
    public class Candidate : User
    {
        public long VoteCount { get; set; }
        public string ImageName { get { return "image_" + Id + ".jpg"; } }
    }
}
