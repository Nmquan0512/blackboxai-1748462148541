namespace PetCareScheduling.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Staff Staff { get; set; } = null!;
        public virtual ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
    }
}
