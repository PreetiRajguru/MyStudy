namespace Trial.Data.Models
{
    public class Attorney
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MatterId { get; set; }

        public Matter Matter { get; set; }

        public ICollection<Role> Roles { get; set; }

        public Rate Rate { get; set; }

        public ICollection<Jurisdiction> Jurisdictions { get; set; }

        public List<Invoice> Invoices { get; } = new();


        public bool IsActive { get; set; }

    }
}
