using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public enum StatusEnum
    {
        pending = 0,
        Done
    }
    public class Order
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public StatusEnum Status { get; set; }
        public string DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public AppUser Doctor { get; set; }
        public string PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public AppUser Patient { get; set; }
    }
}
