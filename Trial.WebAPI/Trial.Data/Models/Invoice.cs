namespace Trial.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public decimal HourlyRate { get; set; }

        public decimal HoursWorked { get; set; }

        public decimal TotalAmount => HourlyRate * HoursWorked;

        public int MatterId { get; set; }

        public Matter Matter { get; set; }

        public List<Attorney> Attorneys { get; } = new();


        public bool IsActive { get; set; }
    }
}
