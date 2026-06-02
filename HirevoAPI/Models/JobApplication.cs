namespace HirevoAPI.Models
{
    public class JobApplication
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
