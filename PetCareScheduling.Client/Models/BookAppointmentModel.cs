using System.ComponentModel.DataAnnotations;

namespace PetCareScheduling.Client.Models
{
    public class BookAppointmentModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a service")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Please select a staff member")]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Please select an appointment date")]
        public DateTime AppointmentDate { get; set; } = DateTime.Today.AddDays(1);

        [Required(ErrorMessage = "Please select an appointment time")]
        public TimeSpan AppointmentTime { get; set; } = new TimeSpan(9, 0, 0);

        public string? Notes { get; set; }
    }
}
