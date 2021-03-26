using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        //VisitationId
        public int VisitationId { get; set; }
        //Date
        public DateTime Date { get; set; }
        //Comments(up to 250 characters, unicode)
        [MaxLength(250)]
        public string Comments { get; set; }
        //Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
