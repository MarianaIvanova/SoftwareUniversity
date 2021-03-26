using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        //DiagnoseId
        public int DiagnoseId { get; set; }
        //Name(up to 50 characters, unicode)
        [MaxLength(50)]
        public string Name { get; set; }
        //Comments(up to 250 characters, unicode)
        [MaxLength(250)]
        public string Comments { get; set; }
        //Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
