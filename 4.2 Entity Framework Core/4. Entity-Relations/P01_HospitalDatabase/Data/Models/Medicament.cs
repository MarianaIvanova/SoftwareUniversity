using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
        }
        //MedicamentId
        public int MedicamentId { get; set; }
        //Name(up to 50 characters, unicode)
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
