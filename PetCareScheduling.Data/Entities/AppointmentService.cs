namespace PetCareScheduling.Data.Entities
{
    public class AppointmentService
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public decimal Price { get; set; }  // Price at the time of booking
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        
        public virtual Appointment Appointment { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
