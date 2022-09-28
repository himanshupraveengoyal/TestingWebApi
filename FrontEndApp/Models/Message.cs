namespace FrontEndApp.Models
{
    public class MessageList
    {
        public IEnumerable<Message> MultipleMessages { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
    }
}
