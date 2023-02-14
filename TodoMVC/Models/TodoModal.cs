namespace TodoMVC.Models
{
    public class TodoModal
    {
        public int id { get; set; }
        public string username { get; set; }
        public string todo { get; set; }
        public string working_queue { get; set; }
        public string completed_task { get; set; }
        public DateTime completedtime { get; set; }
        public int status { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }
}
