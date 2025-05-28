namespace PetCareScheduling.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
    }
}
