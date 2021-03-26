using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
            this.Visitations = new HashSet<Visitation>();
            this.Diagnoses = new HashSet<Diagnose>();
        }
        //PatientId
        public int PatientId { get; set; }
        //FirstName(up to 50 characters, unicode)
        [MaxLength(50)]
        public string FirstName { get; set; }
        //LastName(up to 50 characters, unicode)
        [MaxLength(50)]
        public string LastName { get; set; }
        //Address(up to 250 characters, unicode)
        [MaxLength(250)]
        public string Address { get; set; }
        //Email(up to 80 characters, not unicode)
        [Column(TypeName = "varchar(80)")] //Check
        public string Email { get; set; }
        //HasInsurance
        public bool HasInsurance { get; set; }
        public ICollection<Visitation> Visitations { get; set; }
        public ICollection<Diagnose> Diagnoses { get; set; }
        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
