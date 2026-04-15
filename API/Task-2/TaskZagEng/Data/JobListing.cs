namespace TaskZagEng.Data
{
    public class JobListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; } 
        public string Location { get; set; } 
        public decimal Salary { get; set; }          
        public bool IsActive { get; set; }         
        public DateTime PostedAt { get; set; } 
    }
}
