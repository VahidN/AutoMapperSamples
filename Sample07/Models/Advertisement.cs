namespace Sample07.Models
{
    public class Advertisement
    {
        public int Id { set; get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public string TitleWithOtherName { get; set; }
    }
}