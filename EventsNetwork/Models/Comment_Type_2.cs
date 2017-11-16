namespace EventsNetwork
{
    public class Comment_Type_2
    {
        public string _id { get; set; }
        public string discussion_id { get; set; }
        public string slug { get; set; }
        public string posted { get; set; }
        public Author[] author { get; set; }
        public string text { get; set; }
        public Comment_Type_2[] replies { get; set; }
    }
}